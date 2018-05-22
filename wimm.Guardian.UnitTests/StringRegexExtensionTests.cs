using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace wimm.Guardian.UnitTests
{
    [TestClass]
    public class StringRegexExtensionTests
    {

        private readonly Argument<string> _validArgument = new Argument<string>("my_name", "my_value");
        
        [TestMethod]
        public void IsMatchString_PatternNull_Throws()
        {
            
            var ex = Assert.ThrowsException<ArgumentNullException>(
                () => _validArgument.IsMatch(null as string));

            Assert.AreEqual("pattern", ex.ParamName);
        }

        [TestMethod]
        public void IsMatchString_PattenInvalid_Throws()
        {
            var ex = Assert.ThrowsException<ArgumentException>(
                () => _validArgument.IsMatch("["));

            Assert.AreEqual("pattern", ex.ParamName);
        }

        [TestMethod]
        public void IsMatchString_IsNotMatch_Throws()
        {
            var ex = Assert.ThrowsException<ArgumentException>(
                () => _validArgument.IsMatch("blerg"));

            Assert.AreEqual("my_name", ex.ParamName);
        }

        [TestMethod]
        public void IsMatchString_IsMatch_ReturnsTarget()
        {
            var res = _validArgument.IsMatch(_validArgument.Value);

            Assert.AreEqual(_validArgument, res);
        }

        [TestMethod]
        public void IsMatchRegex_RegexNull_Throws()
        {
            var ex = Assert.ThrowsException<ArgumentNullException>(
                () => _validArgument.IsMatch(null as Regex));

            Assert.AreEqual("regex", ex.ParamName);
        }

        [TestMethod]
        public void IsMatchRegex_IsNotMatch_Throws()
        {
            var ex = Assert.ThrowsException<ArgumentException>(
                () => _validArgument.IsMatch(new Regex("blerg")));

            Assert.AreEqual(_validArgument.Name, ex.ParamName);
        }

        [TestMethod]
        public void IsMatchRegex_IsValid_ReturnsTarget()
        {
            var res =_validArgument.IsMatch(new Regex(_validArgument.Value));

            Assert.AreEqual(_validArgument, res);
        }

    }
}
