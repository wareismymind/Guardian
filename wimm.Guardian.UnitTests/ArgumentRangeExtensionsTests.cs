using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace wimm.Guardian.UnitTests
{
    [TestClass]
    public class ArgumentRangeExtensionsTests
    {
        [TestMethod]
        public void IsLessThan_NullArgumentValue_Throws()
        {
            var argument = new Argument<string>("name", null);
            Assert.ThrowsException<InvalidOperationException>(() => argument.IsLessThan(""));
        }

        [TestMethod]
        public void IsLessThan_NullValue_Throws()
        {
            var argument = new Argument<string>("", "name");
            var ex = 
                Assert.ThrowsException<ArgumentNullException>(
                    () => argument.IsLessThan(null as string));
            Assert.AreEqual("value", ex.ParamName);
        }

        [TestMethod]
        public void IsLessThan_ArgumentValueIsLessThanValue_ReturnsTarget()
        {
            var argument = new Argument<int>("name", 0);
            Assert.AreEqual(argument, argument.IsLessThan(1));
        }

        [TestMethod]
        public void IsLessThan_ArgumentValueEqualsValue_Throws()
        {
            var name = "name";
            var argument = new Argument<int>(name, 0);
            var ex = 
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => argument.IsLessThan(0));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsLessThan_ArgumentValueIsGreaterThanValue_Throws()
        {
            var name = "name";
            var argument = new Argument<int>(name, 1);
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => argument.IsLessThan(0));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsNotLessThan_NullArgumentValue_Throws()
        {
            var argument = new Argument<string>("name", null);
            Assert.ThrowsException<InvalidOperationException>(() => argument.IsNotLessThan(""));
        }

        [TestMethod]
        public void IsNotLessThan_NullValue_Throws()
        {
            var argument = new Argument<string>("name", "");
            var ex = 
                Assert.ThrowsException<ArgumentNullException>(
                    () => argument.IsNotLessThan(null as string));
            Assert.AreEqual("value", ex.ParamName);
        }

        [TestMethod]
        public void IsNotLessThan_ArgumentValueIsLessThanValue_Throws()
        {
            var name = "name";
            var argument = new Argument<int>(name, 0);
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => argument.IsNotLessThan(1));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsNotLessThan_ArgumentValueEqualsValue_ReturnsTarget()
        {
            var argument = new Argument<int>("name", 0);
            Assert.AreEqual(argument, argument.IsNotLessThan(0));
        }

        [TestMethod]
        public void IsNotLessThan_ArgumentValueIsGreaterThanValue_ReturnsTarget()
        {
            var argument = new Argument<int>("name", 1);
            Assert.AreEqual(argument, argument.IsNotLessThan(0));
        }

        [TestMethod]
        public void IsGreaterThan_NullArgumentValue_Throws()
        {
            var argument = new Argument<string>("name", null);
            Assert.ThrowsException<InvalidOperationException>(() => argument.IsGreaterThan(""));
        }

        [TestMethod]
        public void IsGreaterThan_NullValue_Throws()
        {
            var argument = new Argument<string>("name", "");
            var ex = 
                Assert.ThrowsException<ArgumentNullException>(
                    () => argument.IsGreaterThan(null as string));
            Assert.AreEqual("value", ex.ParamName);
        }

        [TestMethod]
        public void IsGreaterThan_ArgumentValueIsLessThanValue_Throws()
        {
            var name = "name";
            var argument = new Argument<int>(name, 0);
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => argument.IsGreaterThan(1));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsGreaterThan_ArgumentValueEqualsValue_Throws()
        {
            var name = "name";
            var argument = new Argument<int>(name, 0);
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => argument.IsGreaterThan(0));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsGreaterThan_ArgumentValueIsGreaterThanValue_ReturnsTarget()
        {
            var argument = new Argument<int>("name", 1);
            Assert.AreEqual(argument, argument.IsGreaterThan(0));
        }

        [TestMethod]
        public void IsNotGreaterThan_NullArgumentValue_Throws()
        {
            var argument = new Argument<string>("name", null);
            Assert.ThrowsException<InvalidOperationException>(() => argument.IsNotGreaterThan(""));
        }

        [TestMethod]
        public void IsNotGreaterThan_NullValue_Throws()
        {
            var argument = new Argument<string>("name", "");
            var ex = 
                Assert.ThrowsException<ArgumentNullException>(
                    () => argument.IsNotGreaterThan(null as string));
            Assert.AreEqual("value", ex.ParamName);
        }

        [TestMethod]
        public void IsNotGreaterThan_ArgumentValueIsLessThanValue_ReturnsTarget()
        {
            var argument = new Argument<int>("name", 0);
            Assert.AreEqual(argument, argument.IsNotGreaterThan(1));
        }

        [TestMethod]
        public void IsNotGreaterThan_ArgumentValueEqualsValue_ReturnsTarget()
        {
            var argument = new Argument<int>("name", 0);
            Assert.AreEqual(argument, argument.IsNotGreaterThan(0));
        }

        [TestMethod]
        public void IsNotGreaterThan_ArgumentValueIsGreaterThanValue_Throws()
        {
            var name = "name";
            var argument = new Argument<int>(name, 1);
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(() => argument.IsNotGreaterThan(0));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsInRange_NullArgumentValue_Throws()
        {
            var argument = new Argument<string>("name", null);
            Assert.ThrowsException<InvalidOperationException>(() => argument.IsInRange("", ""));
        }

        [TestMethod]
        public void IsInRange_NullMin_Throws()
        {
            var argument = new Argument<string>("name", "");
            var ex = 
                Assert.ThrowsException<ArgumentNullException>(
                    () => argument.IsInRange(null, ""));
            Assert.AreEqual("min", ex.ParamName);
        }

        [TestMethod]
        public void IsInRange_NullMax_Throws()
        {
            var argument = new Argument<string>("name", "");
            var ex =
                Assert.ThrowsException<ArgumentNullException>(
                    () => argument.IsInRange("", null));
            Assert.AreEqual("max", ex.ParamName);
        }

        [TestMethod]
        public void IsInRange_ArgumentValueIsLessThanMin_Throws()
        {
            var name = "name";
            var argument = new Argument<int>(name, 0);
            var ex = 
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => argument.IsInRange(1, 3));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsInRange_ArgumentValueEqualsMin_ReturnsTarget()
        {
            var argument = new Argument<int>("name", 1);
            Assert.AreEqual(argument, argument.IsInRange(1, 3));
        }

        [TestMethod]
        public void IsInRange_ArgumentValueIsBetweenMinAndMax_ReturnsTarget()
        {
            var argument = new Argument<int>("name", 2);
            Assert.AreEqual(argument, argument.IsInRange(1, 3));
        }

        [TestMethod]
        public void IsInRange_ArgumentValueEqualsMax_ReturnsTarget()
        {
            var argument = new Argument<int>("name", 3);
            Assert.AreEqual(argument, argument.IsInRange(1, 3));
        }

        [TestMethod]
        public void IsInRange_ArgumentValueIsGreaterThanMax_Throws()
        {
            var name = "name";
            var argument = new Argument<int>(name, 4);
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => argument.IsInRange(1, 3));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsNotInRange_NullArgumentValue_Throws()
        {
            var argument = new Argument<string>("name", null);
            Assert.ThrowsException<InvalidOperationException>(() => argument.IsNotInRange("", ""));
        }

        [TestMethod]
        public void IsNotInRange_NullMin_Throws()
        {
            var argument = new Argument<string>("name", "");
            var ex =
                Assert.ThrowsException<ArgumentNullException>(
                    () => argument.IsNotInRange(null, ""));
            Assert.AreEqual("min", ex.ParamName);
        }

        [TestMethod]
        public void IsNotInRange_NullMax_Throws()
        {
            var argument = new Argument<string>("name", "");
            var ex =
                Assert.ThrowsException<ArgumentNullException>(
                    () => argument.IsNotInRange("", null));
            Assert.AreEqual("max", ex.ParamName);
        }

        [TestMethod]
        public void IsNotInRange_ArgumentValueIsLessThanMin_ReturnsTarget()
        {
            var argument = new Argument<int>("name", 0);
            Assert.AreEqual(argument, argument.IsNotInRange(1, 3));
        }

        [TestMethod]
        public void IsNotInRange_ArgumentValueEqualsMin_Throws()
        {
            var name = "name";
            var argument = new Argument<int>(name, 1);
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => argument.IsNotInRange(1, 3));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsNotInRange_ArgumentValueIsBetweenMinAndMax_Throws()
        {
            var name = "name";
            var argument = new Argument<int>(name, 2);
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => argument.IsNotInRange(1, 3));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsNotInRange_ArgumentValueEqualsMax_Throws()
        {
            var name = "name";
            var argument = new Argument<int>(name, 3);
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => argument.IsNotInRange(1, 3));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsNotInRange_ArgumentValueIsGreaterThanMax_ReturnsTarget()
        {
            var argument = new Argument<int>("name", 4);
            Assert.AreEqual(argument, argument.IsNotInRange(1, 3));
        }

        [TestMethod]
        public void IsBetween_NullArgumentValue_Throws()
        {
            var argument = new Argument<string>("name", null);
            Assert.ThrowsException<InvalidOperationException>(() => argument.IsBetween("", ""));
        }

        [TestMethod]
        public void IsBetween_NullFloor_Throws()
        {
            var argument = new Argument<string>("name", "");
            var ex =
                Assert.ThrowsException<ArgumentNullException>(
                    () => argument.IsBetween(null, ""));
            Assert.AreEqual("floor", ex.ParamName);
        }

        [TestMethod]
        public void IsBetween_NullCeiling_Throws()
        {
            var argument = new Argument<string>("name", "");
            var ex =
                Assert.ThrowsException<ArgumentNullException>(
                    () => argument.IsBetween("", null));
            Assert.AreEqual("ceiling", ex.ParamName);
        }

        [TestMethod]
        public void IsBetween_ArgumentValueIsLessThanA_Throws()
        {
            var name = "name";
            var argument = new Argument<int>(name, 0);
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => argument.IsBetween(1, 3));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsBetween_ArgumentValueEqualsA_Throws()
        {
            var name = "name";
            var argument = new Argument<int>(name, 1);
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => argument.IsBetween(1, 3));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsBetween_ArgumentValueIsBetweenAAndB_ReturnsTarget()
        {
            var argument = new Argument<int>("name", 2);
            Assert.AreEqual(argument, argument.IsBetween(1, 3));
        }

        [TestMethod]
        public void IsBetween_ArgumentValueEqualsB_Throws()
        {
            var name = "name";
            var argument = new Argument<int>(name, 3);
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => argument.IsBetween(1, 3));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsBetween_ArgumentValueIsGreaterThanB_Throws()
        {
            var name = "name";
            var argument = new Argument<int>(name, 4);
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => argument.IsBetween(1, 3));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsNotBetween_NullArgumentValue_Throws()
        {
            var argument = new Argument<string>("name", null);
            Assert.ThrowsException<InvalidOperationException>(() => argument.IsNotBetween("", ""));
        }

        [TestMethod]
        public void IsNotBetween_NullFloor_Throws()
        {
            var argument = new Argument<string>("name", "");
            var ex =
                Assert.ThrowsException<ArgumentNullException>(
                    () => argument.IsNotBetween(null, ""));
            Assert.AreEqual("floor", ex.ParamName);
        }

        [TestMethod]
        public void IsNotBetween_NullCeiling_Throws()
        {
            var argument = new Argument<string>("name", "");
            var ex =
                Assert.ThrowsException<ArgumentNullException>(
                    () => argument.IsNotBetween("", null));
            Assert.AreEqual("ceiling", ex.ParamName);
        }

        [TestMethod]
        public void IsNotBetween_ArgumentValueIsLessThanA_ReturnsTarget()
        {
            var argument = new Argument<int>("name", 0);
            Assert.AreEqual(argument, argument.IsNotBetween(1, 3));
        }

        [TestMethod]
        public void IsNotBetween_ArgumentValueEqualsA_ReturnsTarget()
        {
            var argument = new Argument<int>("name", 1);
            Assert.AreEqual(argument, argument.IsNotBetween(1, 3));
        }

        [TestMethod]
        public void IsNotBetween_ArgumentValueIsBetweenAAndB_Throws()
        {
            var name = "name";
            var argument = new Argument<int>(name, 2);
            var ex =
                Assert.ThrowsException<ArgumentOutOfRangeException>(
                    () => argument.IsNotBetween(1, 3));
            Assert.AreEqual(name, ex.ParamName);
        }

        [TestMethod]
        public void IsNotBetween_ArgumentValueEqualsB_ReturnsTarget()
        {
            var argument = new Argument<int>("name", 3);
            Assert.AreEqual(argument, argument.IsNotBetween(1, 3));
        }

        [TestMethod]
        public void IsNotBetween_ArgumentValueIsGreaterThanB_ReturnsTarget()
        {
            var argument = new Argument<int>("name", 4);
            Assert.AreEqual(argument, argument.IsNotBetween(1, 3));
        }
    }
}
