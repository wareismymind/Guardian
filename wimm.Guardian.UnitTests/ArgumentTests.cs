using System;
using System.Reflection;
using Moq;
using Xunit;

namespace wimm.Guardian.UnitTests
{
    public class ArgumentTests
    {
        [Fact(DisplayName = "Argument throws for null subject")]
        public void Argument_Throws_For_Null_Subject()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => new Argument<int>(null));
            Assert.Equal("subject", ex.ParamName);
        }

        [Fact(DisplayName = "Argument inherits ISubject property values from subject")]
        public void Argument_Inherits_Properties_From_ISubject()
        {
            var name = "name";
            var value = 42;
            var subject = new Mock<ISubject<int>>();
            subject.SetupGet(s => s.Name).Returns(name);
            subject.SetupGet(s => s.Value).Returns(value);
            var argument = new Argument<int>(subject.Object);

            foreach (var propertyInfo in typeof(ISubject<int>).GetProperties())
            {
                Assert.Equal(
                    propertyInfo.GetValue(subject.Object), propertyInfo.GetValue(argument));
            }
        }

        [Fact(DisplayName = "IsNotNull throws when Argument value is null")]
        public void IsNotNull_Throws_When_Argument_Value_Is_Null()
        {
            var subject = new Mock<ISubject<object>>();
            subject.SetupGet(s => s.Value).Returns(null);
            var argument = new Argument<object>(subject.Object);
            Assert.Throws<ArgumentNullException>(() => argument.IsNotNull());
        }

        [Fact(DisplayName = "IsNotNull thrown exceptions have correct ParamName")]
        public void IsNotNull_Thrown_Exceptions_Have_Correct_ParamName()
        {
            var subject = new Mock<ISubject<object>>();
            subject.SetupGet(s => s.Name).Returns("arg");
            subject.SetupGet(s => s.Value).Returns(null);
            var argument = new Argument<object>(subject.Object);
            var ex = Assert.Throws<ArgumentNullException>(() => argument.IsNotNull());
            Assert.Equal("arg", ex.ParamName);
        }

        [Fact(DisplayName = "IsNotNull does not throw an when Argument value is not null")]
        public void IsNotNull_Does_Not_Throw_When_Argument_Value_Is_Not_Null()
        {
            var subject = new Mock<ISubject<object>>();
            subject.SetupGet(s => s.Value).Returns(new object());
            var argument = new Argument<object>(subject.Object);
            argument.IsNotNull();
        }

        [Fact(DisplayName = "IsNotNull returns target")]
        public void IsNotNull_Returns_Target()
        {
            var subject = new Mock<ISubject<object>>();
            subject.SetupGet(s => s.Value).Returns(new object());
            var argument = new Argument<object>(subject.Object);
            var returned = argument.IsNotNull();
            Assert.Same(argument, returned);
        }

        [Fact(DisplayName = "If throws for null condition")]
        public void If_Throws_For_Null_Condition()
        {
            var subject = new Mock<ISubject<object>>();
            var argument = new Argument<object>(subject.Object);
            var ex =
                Assert.Throws<ArgumentNullException>(() => argument.If(null, s => { }));
            Assert.Equal("condition", ex.ParamName);
        }

        [Fact(DisplayName = "If throws for null consequence")]
        public void If_Throws_For_Null_Consequence()
        {
            var subject = new Mock<ISubject<object>>();
            var argument = new Argument<object>(subject.Object);
            var ex = Assert.Throws<ArgumentNullException>(() => argument.If(v => true, null));
            Assert.Equal("consequence", ex.ParamName);
        }

        [Fact(DisplayName = "If does not execute consequence when condition is false")]
        public void If_Does_Not_Execute_Consequence_When_Condition_Is_False()
        {
            var subject = new Mock<ISubject<int>>();
            var argument = new Argument<int>(subject.Object);
            var ran = false;
            argument.If(v => false, s => ran = true);
            Assert.False(ran);
        }

        [Fact(DisplayName = "If executes consequence when condition is true")]
        public void If_Executes_Consequence_When_Condition_Is_True()
        {
            var subject = new Mock<ISubject<int>>();
            var argument = new Argument<int>(subject.Object);
            var ran = false;
            argument.If(v => true, s => ran = true);
            Assert.True(ran);
        }

        [Fact(DisplayName = "If returns target")]
        public void If_Returns_Target()
        {
            var subject = new Mock<ISubject<int>>();
            var argument = new Argument<int>(subject.Object);
            var returned = argument.If(v => false, s => { });
            Assert.Same(returned, returned);
        }

        [Fact(DisplayName = "IfNot throws for null condition")]
        public void IfNot_Throws_For_Null_Condition()
        {
            var subject = new Mock<ISubject<object>>();
            var argument = new Argument<object>(subject.Object);
            var ex = 
                Assert.Throws<ArgumentNullException>(() => argument.IfNot(null, s => { }));
            Assert.Equal("condition", ex.ParamName);
        }

        [Fact(DisplayName = "IfNot throws for null consequence")]
        public void IfNot_Throws_For_Null_Consequence()
        {
            var subject = new Mock<ISubject<object>>();
            var argument = new Argument<object>(subject.Object);
            var ex = Assert.Throws<ArgumentNullException>(() => argument.IfNot(v => true, null));
            Assert.Equal("consequence", ex.ParamName);
        }

        [Fact(DisplayName = "IfNot executes consequence when condition is false")]
        public void IfNot_Executes_Consequence_When_Condition_Is_False()
        {
            var subject = new Mock<ISubject<int>>();
            var argument = new Argument<int>(subject.Object);
            var ran = false;
            argument.IfNot(v => false, s => ran = true);
            Assert.True(ran);
        }

        [Fact(DisplayName = "IfNot does not execute consequence when condition is true")]
        public void IfNot_Does_Not_Execute_Consequence_When_Condition_Is_True()
        {
            var subject = new Mock<ISubject<int>>();
            var argument = new Argument<int>(subject.Object);
            var ran = false;
            argument.IfNot(v => true, s => ran = true);
            Assert.False(ran);
        }

        [Fact(DisplayName = "IfNot returns target")]
        public void IfNot_Returns_Target()
        {
            var subject = new Mock<ISubject<int>>();
            var argument = new Argument<int>(subject.Object);
            var returned = argument.IfNot(v => true, s => { });
            Assert.Same(argument, returned);
        }

        [Fact(DisplayName = "Argument extension throws for null subject.")]
        public void Argument_Extension_Throws_For_Null_Subject()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => (null as ISubject<int>).Argument());
            Assert.Equal("target", ex.ParamName);
        }

        [Fact(DisplayName = "Argument extension returns equivalent ISubject")]
        public void Argument_Extension_Returns_Equialvent_ISubject()
        {
            var name = "name";
            var value = 42;
            var subject = new Mock<ISubject<int>>();
            subject.SetupGet(s => s.Name).Returns(name);
            subject.SetupGet(s => s.Value).Returns(value);
            var argument = subject.Object.Argument();

            foreach (var propertyInfo in typeof(ISubject<int>).GetProperties())
            {
                Assert.Equal(
                    propertyInfo.GetValue(subject.Object), propertyInfo.GetValue(argument));
            }
        }
    }
}
