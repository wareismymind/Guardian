using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace wimm.Guardian.UnitTests
{
    [TestClass]
    public class EnumArgumentExtensionsTests
    {
        [TestMethod]
        public void IsDefinedEnum_ValueUndefined_Throws()
        {
            var underTest = new Argument<TestEnum>("Doot", (TestEnum)(int.MaxValue));
            Assert.ThrowsException<EnumArgumentOutOfRangeException>(() => underTest.IsDefinedEnum());
        }

        [TestMethod]
        public void IsDefinedEnum_ValueNotEnum_Throws()
        {
            var underTest = new Argument<DateTime>("Doot", DateTime.Now);
            Assert.ThrowsException<TypeArgumentException>(() => underTest.IsDefinedEnum());
        }

        [TestMethod]
        public void IsDefinedEnum_ValueDefined_ReturnsSameValue()
        {
            var underTest = new Argument<TestEnum>("Doot", TestEnum.Yes);
            var res = underTest.IsDefinedEnum();

            Assert.AreEqual(res.Value, underTest.Value);
        }

        [TestMethod]
        public void IsFlagCombo_NoFlagAttribute_Throws()
        {
            var underTest = TestEnum.Yes.Require("Doot");
            Assert.ThrowsException<TypeArgumentException>(() => underTest.IsFlagCombo());
        }

        [TestMethod]
        public void IsFlagCombo_IsNotFlagCombo_Throws()
        {
            var underTest = ((LongFlags)0x1000).Require("MoreDoot");
            Assert.ThrowsException<ArgumentException>(() => underTest.IsFlagCombo());
        }

        [TestMethod]
        public void IsFlagCombo_DuplicateEnumValues_ReturnsValueCopy()
        {
            var underTest = AliasedFlags.First.Require("SuchDoot");
            var res = underTest.IsFlagCombo();

            Assert.AreEqual(underTest.Value, res.Value);
        }


        [TestMethod]
        public void IsFlagCombo_IsFlagCombo_ReturnsValueCopy()
        {
            var underTest = (ValidSequential.First | ValidSequential.Second).Require("SoMuchDoot");
            var res = underTest.IsFlagCombo();

            Assert.AreEqual(underTest.Value, res.Value);
        }

        private enum TestEnum
        {
            Yes,
            No
        }

        [Flags]
        private enum ValidSequential
        {
            First = 0x1,
            Second = 0x10
        }

        [Flags]
        private enum AliasedFlags
        {
            First = 0x1,
            Second = First
        }

        [Flags]
        private enum LongFlags :long
        {
            First = 0x1,
            Second = 0x01
        }
    }


}
