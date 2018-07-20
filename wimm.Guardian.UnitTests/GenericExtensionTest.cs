using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Serializable]
        private class TestClass
        {
            public int i = 0;
        }

        private class NoAttribute
        {
            public int i = 0;
        }
    }
}
