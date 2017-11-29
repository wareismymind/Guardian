using System;
using Moq;
using Xunit;

namespace wimm.Guardian.UnitTests
{
    public class ISubjectTests
    {
        [Fact(DisplayName = "If throws for null target")]
        public void If_Throws_For_Null_Target()
        {
            var subject = null as ISubject<object>;
            var ex =
                Assert.Throws<ArgumentNullException>(() => subject.If(v => true, s => { }));
            Assert.Equal("target", ex.ParamName);
        }

        [Fact(DisplayName = "If throws for null condition")]
        public void If_Throws_For_Null_Condition()
        {
            var subject = new Mock<ISubject<object>>();
            var ex =
                Assert.Throws<ArgumentNullException>(() => subject.Object.If(null, s => { }));
            Assert.Equal("condition", ex.ParamName);
        }

        [Fact(DisplayName = "If throws for null consequence")]
        public void If_Throws_For_Null_Consequence()
        {
            var subject = new Mock<ISubject<object>>();
            var ex = Assert.Throws<ArgumentNullException>(
                () => subject.Object.If(v => true, null));
            Assert.Equal("consequence", ex.ParamName);
        }

        [Fact(DisplayName = "If does not execute consequence when condition is false")]
        public void If_Does_Not_Execute_Consequence_When_Condition_Is_False()
        {
            var subject = new Mock<ISubject<int>>();
            var ran = false;
            subject.Object.If(v => false, s => ran = true);
            Assert.False(ran);
        }

        [Fact(DisplayName = "If executes consequence when condition is true")]
        public void If_Executes_Consequence_When_Condition_Is_True()
        {
            var subject = new Mock<ISubject<int>>();
            var ran = false;
            subject.Object.If(v => true, s => ran = true);
            Assert.True(ran);
        }

        [Fact(DisplayName = "If returns target")]
        public void If_Returns_Target()
        {
            var subject = new Mock<ISubject<int>>();
            var returned = subject.Object.If(v => false, s => { });
            Assert.Same(subject.Object, returned);
        }

        [Fact(DisplayName = "IfNot throws for null target")]
        public void IfNot_Throws_For_Null_Target()
        {
            var subject = null as ISubject<object>;
            var ex = 
                Assert.Throws<ArgumentNullException>(() => subject.IfNot(v => true, s => { }));
            Assert.Equal("target", ex.ParamName);
        }

        [Fact(DisplayName = "IfNot throws for null condition")]
        public void IfNot_Throws_For_Null_Condition()
        {
            var subject = new Mock<ISubject<object>>();
            var ex = 
                Assert.Throws<ArgumentNullException>(() => subject.Object.IfNot(null, s => { }));
            Assert.Equal("condition", ex.ParamName);
        }

        [Fact(DisplayName = "IfNot throws for null consequence")]
        public void IfNot_Throws_For_Null_Consequence()
        {
            var subject = new Mock<ISubject<object>>();
            var ex = Assert.Throws<ArgumentNullException>(
                () => subject.Object.IfNot(v => true, null));
            Assert.Equal("consequence", ex.ParamName);
        }

        [Fact(DisplayName = "IfNot executes consequence when condition is false")]
        public void IfNot_Executes_Consequence_When_Condition_Is_False()
        {
            var subject = new Mock<ISubject<int>>();
            var ran = false;
            subject.Object.IfNot(v => false, s => ran = true);
            Assert.True(ran);
        }

        [Fact(DisplayName = "IfNot does not execute consequence when condition is true")]
        public void IfNot_Does_Not_Execute_Consequence_When_Condition_Is_True()
        {
            var subject = new Mock<ISubject<int>>();
            var ran = false;
            subject.Object.IfNot(v => true, s => ran = true);
            Assert.False(ran);
        }

        [Fact(DisplayName = "IfNot returns target")]
        public void IfNot_Returns_Target()
        {
            var subject = new Mock<ISubject<int>>();
            var returned = subject.Object.IfNot(v => true, s => { });
            Assert.Same(subject.Object, returned);
        }
    }
}
