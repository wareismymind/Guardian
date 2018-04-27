using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace wimm.Guardian.UnitTests
{
    public abstract class NumericExtensionsTests<T>
        where T : IComparable<T>
    {
        protected abstract T Zero { get; }
        protected abstract T Negative { get; }
        protected abstract T Positive { get; }

        [TestMethod]
        public void IsPositive_NullTarget_Throws()
        {
            var ex =
                Assert.ThrowsException<ArgumentNullException>(
                    () => (null as Argument<T>).IsPositive());
            Assert.AreEqual("target", ex.ParamName);
        }

        [TestMethod]
        public void IsPositive_Negative_Throws()
        {
            var name = "name";
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => new Argument<T>(name, Negative).IsPositive());
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsPositive_Zero_Throws()
        {
            var name = "name";
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => new Argument<T>(name, Zero).IsPositive());
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsPositive_Positive_ReturnsTarget()
        {
            var argument = new Argument<T>("name", Positive);
            Assert.AreSame(argument, argument.IsPositive());
        }

        [TestMethod]
        public void IsNegative_NullTarget_Throws()
        {
            var ex =
                Assert.ThrowsException<ArgumentNullException>(
                    () => (null as Argument<T>).IsNegative());
            Assert.AreEqual("target", ex.ParamName);
        }

        [TestMethod]
        public void IsNegative_Negative_ReturnsTarget()
        {
            var argument = new Argument<T>("name", Negative);
            Assert.AreSame(argument, argument.IsNegative());
        }

        [TestMethod]
        public void IsNegative_Zero_Throws()
        {
            var name = "name";
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => new Argument<T>(name, Zero).IsNegative());
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsNegative_Positive_Throws()
        {
            var name = "name";
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => new Argument<T>(name, Positive).IsNegative());
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsNotPositive_NullTarget_Throws()
        {
            var ex =
                Assert.ThrowsException<ArgumentNullException>(
                    () => (null as Argument<T>).IsNotPositive());
            Assert.AreEqual("target", ex.ParamName);
        }

        [TestMethod]
        public void IsNotPositive_Negative_ReturnsTarget()
        {
            var argument = new Argument<T>("name", Negative);
            Assert.AreSame(argument, argument.IsNotPositive());
        }

        [TestMethod]
        public void IsNotPositive_Zero_ReturnsTarget()
        {
            var argument = new Argument<T>("name", Zero);
            Assert.AreSame(argument, argument.IsNotPositive());
        }

        [TestMethod]
        public void IsNotPositive_Positive_Throws()
        {
            var name = "name";
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => new Argument<T>(name, Positive).IsNotPositive());
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsNotNegative_NullTarget_Throws()
        {
            var ex =
                Assert.ThrowsException<ArgumentNullException>(
                    () => (null as Argument<T>).IsNotNegative());
            Assert.AreEqual("target", ex.ParamName);
        }

        [TestMethod]
        public void IsNotNegative_Negative_Throws()
        {
            var name = "name";
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => new Argument<T>(name, Negative).IsNotNegative());
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsNotNegative_Zero_ReturnsTarget()
        {
            var argument = new Argument<T>("name", Zero);
            Assert.AreSame(argument, argument.IsNotNegative());
        }

        [TestMethod]
        public void IsNotNegative_Positive_ReturnsTarget()
        {
            var argument = new Argument<T>("name", Positive);
            Assert.AreSame(argument, argument.IsNotNegative());
        }
    }

    [TestClass]
    public class NumericSByteExtensionsTests : NumericExtensionsTests<sbyte>
    {
        protected override sbyte Negative => -1;
        protected override sbyte Positive => 1;
        protected override sbyte Zero => 0;
    }

    [TestClass]
    public class NumericShortExtensionsTests : NumericExtensionsTests<short>
    {
        protected override short Negative => -1;
        protected override short Positive => 1;
        protected override short Zero => 0;
    }

    [TestClass]
    public class NumericIntExtensionsTests : NumericExtensionsTests<int>
    {
        protected override int Negative => -1;
        protected override int Positive => 1;
        protected override int Zero => 0;
    }

    [TestClass]
    public class NumericLomgExtensionsTests : NumericExtensionsTests<long>
    {
        protected override long Negative => -1;
        protected override long Positive => 1;
        protected override long Zero => 0;
    }
}
