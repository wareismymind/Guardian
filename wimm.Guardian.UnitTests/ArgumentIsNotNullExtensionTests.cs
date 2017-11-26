using System;
using Xunit;

namespace wimm.Guardian.UnitTests
{
    public class ArgumentIsNotNullExtensionTests
    {
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
