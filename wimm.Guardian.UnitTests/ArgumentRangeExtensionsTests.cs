using System;
using Moq;
using Xunit;

namespace wimm.Guardian.UnitTests
{
    public class ArgumentRangeExtensionsTests
    {
        [Fact(DisplayName = "IsLessThan throws for null target")]
        public void IsLessThan_Throws_For_Null_Target()
        {
            Assert.Throws<ArgumentNullException>(() => (null as Argument<int>).IsLessThan(0));
        }

        [Fact(DisplayName = "IsLessThan throws for null value")]
        public void IsLessThan_Throws_For_Null_Value()
        {
            var subject = new Mock<ISubject<string>>();
            subject.SetupGet(s => s.Value).Returns(null as string);
            var argument = new Argument<string>(subject.Object);
            Assert.Throws<ArgumentNullException>(() => argument.IsLessThan(null as string));
        }

        [Fact(DisplayName = "IsLessThan does not throw when less than.")]
        public void IsLessThan_Does_Not_Throw_When_Less_Than()
        {
            var subject = new Mock<ISubject<int>>();
            subject.SetupGet(s => s.Value).Returns(0);
            var argument = new Argument<int>(subject.Object);
            argument.IsLessThan(1);
        }

        [Fact(DisplayName = "IsLessThan throws when equal")]
        public void IsLessThan_Throws_When_Equal()
        {
            var subject = new Mock<ISubject<int>>();
            subject.SetupGet(s => s.Value).Returns(0);
            var argument = new Argument<int>(subject.Object);
            Assert.Throws<ArgumentOutOfRangeException>(() => argument.IsLessThan(0));
        }

        [Fact(DisplayName = "IsLessThan throws when greater than.")]
        public void IsLessThan_Throws_When_Greater_Than()
        {
            var subject = new Mock<ISubject<int>>();
            subject.SetupGet(s => s.Value).Returns(1);
            var argument = new Argument<int>(subject.Object);
            Assert.Throws<ArgumentOutOfRangeException>(() => argument.IsLessThan(0));
        }

        [Fact(DisplayName = "IsNotLessThan throws for null target")]
        public void IsNotLessThan_Throws_For_Null_Target()
        {
            Assert.Throws<ArgumentNullException>(() => (null as Argument<int>).IsNotLessThan(0));
        }

        [Fact(DisplayName = "IsNotLessThan throws for null value")]
        public void IsNotLessThan_Throws_For_Null_Value()
        {
            var subject = new Mock<ISubject<string>>();
            subject.SetupGet(s => s.Value).Returns(null as string);
            var argument = new Argument<string>(subject.Object);
            Assert.Throws<ArgumentNullException>(() => argument.IsNotLessThan(null as string));
        }

        [Fact(DisplayName = "IsNotLessThan throws when less than.")]
        public void IsNotLessThan_Throws_When_Less_Than()
        {
            var subject = new Mock<ISubject<int>>();
            subject.SetupGet(s => s.Value).Returns(0);
            var argument = new Argument<int>(subject.Object);
            Assert.Throws<ArgumentOutOfRangeException>(() => argument.IsNotLessThan(1));
        }

        [Fact(DisplayName = "IsNotLessThan does not throw when equal.")]
        public void IsNotLessThan_Does_Not_Throw_When_Equal()
        {
            var subject = new Mock<ISubject<int>>();
            subject.SetupGet(s => s.Value).Returns(0);
            var argument = new Argument<int>(subject.Object);
            argument.IsNotLessThan(0);
        }

        [Fact(DisplayName = "IsNotLessThan does not throw when greater than.")]
        public void IsNotLessThan_Does_Not_Throw_When_Greater_Than()
        {
            var subject = new Mock<ISubject<int>>();
            subject.SetupGet(s => s.Value).Returns(1);
            var argument = new Argument<int>(subject.Object);
            argument.IsNotLessThan(0);
        }

        [Fact(DisplayName = "IsGreaterThan throws for null target")]
        public void IsGreaterThan_Throws_For_Null_Target()
        {
            Assert.Throws<ArgumentNullException>(() => (null as Argument<int>).IsGreaterThan(0));
        }

        [Fact(DisplayName = "IsGreaterThan throws for null value")]
        public void IsGreaterThan_Throws_For_Null_Value()
        {
            var subject = new Mock<ISubject<string>>();
            subject.SetupGet(s => s.Value).Returns(null as string);
            var argument = new Argument<string>(subject.Object);
            Assert.Throws<ArgumentNullException>(() => argument.IsGreaterThan(null as string));
        }

        [Fact(DisplayName = "IsGreaterThan throws when less than.")]
        public void IsGreaterThan_Throws_When_Less_Than()
        {
            var subject = new Mock<ISubject<int>>();
            subject.SetupGet(s => s.Value).Returns(0);
            var argument = new Argument<int>(subject.Object);
            Assert.Throws<ArgumentOutOfRangeException>(() => argument.IsGreaterThan(1));
        }

        [Fact(DisplayName = "IsGreaterThan throws when equal.")]
        public void IsGreaterThan_Throws_When_Equal()
        {
            var subject = new Mock<ISubject<int>>();
            subject.SetupGet(s => s.Value).Returns(0);
            var argument = new Argument<int>(subject.Object);
            Assert.Throws<ArgumentOutOfRangeException>(() => argument.IsGreaterThan(0));
        }

        [Fact(DisplayName = "IsGreaterThan does not throw when greater than.")]
        public void IsGreaterThan_Does_Not_Throw_When_Greater_Than()
        {
            var subject = new Mock<ISubject<int>>();
            subject.SetupGet(s => s.Value).Returns(1);
            var argument = new Argument<int>(subject.Object);
             argument.IsGreaterThan(0);
        }

        [Fact(DisplayName = "IsNotGreaterThan throws for null target")]
        public void IsNotGreaterThan_Throws_For_Null_Target()
        {
            Assert.Throws<ArgumentNullException>(
                () => (null as Argument<int>).IsNotGreaterThan(0));
        }

        [Fact(DisplayName = "IsNotGreaterThan throws for null value")]
        public void IsNotGreaterThan_Throws_For_Null_Value()
        {
            var subject = new Mock<ISubject<string>>();
            subject.SetupGet(s => s.Value).Returns(null as string);
            var argument = new Argument<string>(subject.Object);
            Assert.Throws<ArgumentNullException>(() => argument.IsNotGreaterThan(null as string));
        }

        [Fact(DisplayName = "IsNotGreaterThan does not throw when less than.")]
        public void IsNotGreaterThan_Throws_When_Less_Than()
        {
            var subject = new Mock<ISubject<int>>();
            subject.SetupGet(s => s.Value).Returns(0);
            var argument = new Argument<int>(subject.Object);
            argument.IsNotGreaterThan(1);
        }

        [Fact(DisplayName = "IsNotGreaterThan does not throw when equal.")]
        public void IsNotGreaterThan_Does_Not_Throw_When_Equal()
        {
            var subject = new Mock<ISubject<int>>();
            subject.SetupGet(s => s.Value).Returns(0);
            var argument = new Argument<int>(subject.Object);
            argument.IsNotGreaterThan(0);
        }

        [Fact(DisplayName = "IsNotGreaterThan throws when greater than.")]
        public void IsNotGreaterThan_Does_Not_Throw_When_Greater_Than()
        {
            var subject = new Mock<ISubject<int>>();
            subject.SetupGet(s => s.Value).Returns(1);
            var argument = new Argument<int>(subject.Object);
            Assert.Throws<ArgumentOutOfRangeException>(() => argument.IsNotGreaterThan(0));
        }
    }
}
