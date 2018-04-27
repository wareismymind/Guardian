using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace wimm.Guardian.UnitTests
{
    [TestClass]
    public class NumericExtensionsTestsForNonNumericTypes
    {
        private readonly Argument<NonNumericComparable> _argument =
            new Argument<NonNumericComparable>("name", null);

        [TestMethod]
        public void IsPositive_NonNumericType_ThrowsTypeArgumentException()
        {
            AssertMethodThrowsTypeArgumentException(() => _argument.IsPositive());
        }

        [TestMethod]
        public void IsNegative_NonNumericType_ThrowsTypeArgumentException()
        {
            AssertMethodThrowsTypeArgumentException(() => _argument.IsNegative());
        }

        [TestMethod]
        public void IsNotPositive_NonNumericType_ThrowsTypeArgumentException()
        {
            AssertMethodThrowsTypeArgumentException(() => _argument.IsNotPositive());
        }

        [TestMethod]
        public void IsNotNegative_NonNumericType_ThrowsTypeArgumentException()
        {
            AssertMethodThrowsTypeArgumentException(() => _argument.IsNotNegative());
        }

        private void AssertMethodThrowsTypeArgumentException(
            Action action)
        {
            var ex = Assert.ThrowsException<TypeArgumentException>(action);
            Assert.AreEqual("T", ex.TypeParamName);
            Assert.AreEqual(typeof(NonNumericComparable), ex.Type);
        }

        public class NonNumericComparable : IComparable<NonNumericComparable>
        {
            public int CompareTo(NonNumericComparable other)
            {
                throw new NotImplementedException();
            }
        }
    }
}
