using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace wimm.Guardian.UnitTests
{
    [TestClass]
    public class GenericExtensionTest
    {

        [TestMethod]
        public void HasAttribute_DoesNotHaveAttribute_Throws()
        {
            var underTest = new NoAttribute();
            Assert.ThrowsException<TypeArgumentException>(() =>
                underTest.Require(nameof(underTest)).HasAttribute(typeof(SerializableAttribute)));
        }

        [TestMethod]
        public void HasAttribute_TypeHasAttribute_ReturnsType()
        {
            var underTest = new TestClass();
            var value = underTest.Require(nameof(underTest)).HasAttribute(typeof(SerializableAttribute));
            Assert.AreSame(underTest, value.Value);
        }

        [TestMethod]
        public void IsEnum_IsNotEnum_Throws()
        {
            const int underTest = 3;
            Assert.ThrowsException<TypeArgumentException>(() =>underTest.Require(nameof(underTest)).IsEnum());
        }

        [TestMethod]
        public void IsEnum_IsEnum_ReturnsArgument()
        {
            var underTest = TestEnum.Value;
            var res = underTest.Require(nameof(underTest)).IsEnum();

            Assert.AreEqual(underTest, res.Value);
        }

        public enum TestEnum
        {
            Value
        }

        [Serializable]
        private class TestClass
        {
            public int i;
        }

        private class NoAttribute
        {
            public int i;
        }
    }
}
