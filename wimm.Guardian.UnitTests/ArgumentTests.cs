﻿using System;
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
            Assert.Throws<ArgumentNullException>(() => new Argument<int>(null));
        }

        [Fact(DisplayName = "Argument inherits ISubject property values from subject")]
        public void Argument_Has_Same_Name_Subject()
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

        [Fact(DisplayName = "Argument extension throws for null subject.")]
        public void Argument_Extension_Throws_For_Null_Subject()
        {
            Assert.Throws<ArgumentNullException>(() => (null as ISubject<int>).Argument());
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

        [Fact(DisplayName = "IsNotNull throws for null valued Argument")]
        public void IsNotNull_Throws_For_Null_Valued_Argument()
        {
            var name = "name";
            var ex = Assert.Throws<ArgumentNullException>(
                () => (null as object).Require(name).Argument().IsNotNull());
            Assert.Equal(name, ex.ParamName);
        }

        [Fact(DisplayName = "IsNotNull does not throw for non-null valued Argument")]
        public void IsNotNull_Does_Not_Throw_For_NonNull_Valued_Argument()
        {
            "value".Require("name").Argument().IsNotNull();
        }

        [Fact(DisplayName = "IsNotNull returns target")]
        public void IsNotNull_Returns_Target()
        {
            var argument = "value".Require("name").Argument();
            var returned = argument.IsNotNull();
            Assert.Same(argument, returned);
        }
    }
}
