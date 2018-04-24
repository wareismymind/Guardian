using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace wimm.Guardian.UnitTests
{
    public abstract class NumericExtensionsTests<T>
    {
        protected abstract T Zero { get; }
        protected abstract T Negative { get; }
        protected abstract T Positive { get; }

        protected abstract Argument<T> CallIsPositive(Argument<T> argument);
        protected abstract Argument<T> CallIsNegative(Argument<T> argument);
        protected abstract Argument<T> CallIsNotPositive(Argument<T> argument);
        protected abstract Argument<T> CallIsNotNegative(Argument<T> argument);

        [TestMethod]
        public void IsPositive_NullTarget_Throws()
        {
            var ex =
                Assert.ThrowsException<ArgumentNullException>(
                    () => CallIsPositive(null as Argument<T>));
            Assert.AreEqual("target", ex.ParamName);
        }

        [TestMethod]
        public void IsPositive_Negative_Throws()
        {
            var name = "name";
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => CallIsPositive(new Argument<T>(Negative, name)));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsPositive_Zero_Throws()
        {
            var name = "name";
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => CallIsPositive(new Argument<T>(Zero, name)));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsPositive_Positive_ReturnsTarget()
        {
            var argument = new Argument<T>(Positive, "name");
            Assert.AreSame(argument, CallIsPositive(argument));
        }

        [TestMethod]
        public void IsNegative_NullTarget_Throws()
        {
            var ex =
                Assert.ThrowsException<ArgumentNullException>(
                    () => CallIsNegative(null as Argument<T>));
            Assert.AreEqual("target", ex.ParamName);
        }

        [TestMethod]
        public void IsNegative_Negative_ReturnsTarget()
        {
            var argument = new Argument<T>(Negative, "name");
            Assert.AreSame(argument, CallIsNegative(argument));
        }

        [TestMethod]
        public void IsNegative_Zero_Throws()
        {
            var name = "name";
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => CallIsNegative(new Argument<T>(Zero, name)));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsNegative_Positive_Throws()
        {
            var name = "name";
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => CallIsNegative(new Argument<T>(Positive, name)));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsNotPositive_NullTarget_Throws()
        {
            var ex =
                Assert.ThrowsException<ArgumentNullException>(
                    () => CallIsNotPositive(null as Argument<T>));
            Assert.AreEqual("target", ex.ParamName);
        }

        [TestMethod]
        public void IsNotPositive_Negative_ReturnsTarget()
        {
            var argument = new Argument<T>(Negative, "name");
            Assert.AreSame(argument, CallIsNotPositive(argument));
        }

        [TestMethod]
        public void IsNotPositive_Zero_ReturnsTarget()
        {
            var argument = new Argument<T>(Zero, "name");
            Assert.AreSame(argument, CallIsNotPositive(argument));
        }

        [TestMethod]
        public void IsNotPositive_Positive_Throws()
        {
            var name = "name";
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => CallIsNotPositive(new Argument<T>(Positive, name)));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsNotNegative_NullTarget_Throws()
        {
            var ex =
                Assert.ThrowsException<ArgumentNullException>(
                    () => CallIsNotNegative((null as Argument<T>)));
            Assert.AreEqual("target", ex.ParamName);
        }

        [TestMethod]
        public void IsNotNegative_Negative_Throws()
        {
            var name = "name";
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => CallIsNotNegative(new Argument<T>(Negative, name)));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsNotNegative_Zero_ReturnsTarget()
        {
            var argument = new Argument<T>(Zero, "name");
            Assert.AreSame(argument, CallIsNotNegative(argument));
        }

        [TestMethod]
        public void IsNotNegative_Positive_ReturnsTarget()
        {
            var argument = new Argument<T>(Positive, "name");
            Assert.AreSame(argument, CallIsNotNegative(argument));
        }
    }

    [TestClass]
    public class NumericSByteExtensionsTests : NumericExtensionsTests<sbyte>
    {
        protected override sbyte Negative => -1;
        protected override sbyte Positive => 1;
        protected override sbyte Zero => 0;

        protected override Argument<sbyte> CallIsNegative(Argument<sbyte> argument) => argument.IsNegative();
        protected override Argument<sbyte> CallIsNotNegative(Argument<sbyte> argument) => argument.IsNotNegative();
        protected override Argument<sbyte> CallIsPositive(Argument<sbyte> argument) => argument.IsPositive();
        protected override Argument<sbyte> CallIsNotPositive(Argument<sbyte> argument) => argument.IsNotPositive();
    }

    [TestClass]
    public class NumericShortExtensionsTests : NumericExtensionsTests<short>
    {
        protected override short Negative => -1;
        protected override short Positive => 1;
        protected override short Zero => 0;

        protected override Argument<short> CallIsNegative(Argument<short> argument) => argument.IsNegative();
        protected override Argument<short> CallIsNotNegative(Argument<short> argument) => argument.IsNotNegative();
        protected override Argument<short> CallIsPositive(Argument<short> argument) => argument.IsPositive();
        protected override Argument<short> CallIsNotPositive(Argument<short> argument) => argument.IsNotPositive();
    }

    [TestClass]
    public class NumericIntExtensionsTests : NumericExtensionsTests<int>
    {
        protected override int Negative => -1;
        protected override int Positive => 1;
        protected override int Zero => 0;

        protected override Argument<int> CallIsNegative(Argument<int> argument) => argument.IsNegative();
        protected override Argument<int> CallIsNotNegative(Argument<int> argument) => argument.IsNotNegative();
        protected override Argument<int> CallIsPositive(Argument<int> argument) => argument.IsPositive();
        protected override Argument<int> CallIsNotPositive(Argument<int> argument) => argument.IsNotPositive();
    }

    [TestClass]
    public class NumericLomgExtensionsTests : NumericExtensionsTests<long>
    {
        protected override long Negative => -1;
        protected override long Positive => 1;
        protected override long Zero => 0;

        protected override Argument<long> CallIsNegative(Argument<long> argument) => argument.IsNegative();
        protected override Argument<long> CallIsNotNegative(Argument<long> argument) => argument.IsNotNegative();
        protected override Argument<long> CallIsPositive(Argument<long> argument) => argument.IsPositive();
        protected override Argument<long> CallIsNotPositive(Argument<long> argument) => argument.IsNotPositive();
    }
}
