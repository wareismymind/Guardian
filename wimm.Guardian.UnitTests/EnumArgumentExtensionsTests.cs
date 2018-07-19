using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wimm.Guardian.UnitTests
{
    [TestClass]
    public class EnumArgumentExtensionsTests
    {
        [TestMethod]
        public void IsDefined_ValueUndefined_Throws()
        {
            var underTest = new Argument<TestEnum>("Doot", (TestEnum)(int.MaxValue));
            Assert.ThrowsException<EnumArgumentOutOfRangeException>(() => underTest.IsDefined());
        }

        [TestMethod]
        public void IsDefined_ValueNotEnum_Throws()
        {
            var underTest = new Argument<DateTime>("Doot", DateTime.Now);
            Assert.ThrowsException<TypeArgumentException>(() => underTest.IsDefined());
        }

        [TestMethod]
        public void IsDefined_ValueDefined_ReturnsSameValue()
        {
            var underTest = new Argument<TestEnum>("Doot", TestEnum.Yes);
            var res = underTest.IsDefined();

            Assert.AreEqual(res.Value, underTest.Value);
        }

        private enum TestEnum
        {
            Yes,
            No
        }
    }


}
