using System;
using Xunit;

namespace wimm.Guardian.UnitTests
{
    public class RequireExtensionTests
    {
        [Fact(DisplayName = "Require throws for null name")]
        public void Require_Throws_For_Null_Name()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => 42.Require(null));
            Assert.Equal("name", ex.ParamName);
        }

        [Fact(DisplayName = "Require returns a valid ISubject")]
        public void Require_Returns_A_Valid_ISubject()
        {
            var name = "name";
            var value = 42;
            var subject = value.Require(name);
            Assert.Equal(value, subject.Value);
            Assert.Equal(name, subject.Name);
        }

        [Fact(DisplayName = "Require returns a valid ISubject when value is null")]
        public void Require_Returns_A_Valid_ISubject_When_Value_Is_Null()
        {
            var subject = (null as object).Require("name");
            Assert.Null(subject.Value);
        }
    }
}
