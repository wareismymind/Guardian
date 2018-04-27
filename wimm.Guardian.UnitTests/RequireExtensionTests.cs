using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace wimm.Guardian.UnitTests
{
    [TestClass]
    public class RequireExtensionTests
    {
        [TestMethod]
        public void Require_NullName_Throws()
        {
            var ex = Assert.ThrowsException<ArgumentNullException>(() => 42.Require(null));
            Assert.AreEqual("name", ex.ParamName);
        }

        [TestMethod]
        public void Require_Returns_A_Valid_ISubject()
        {
            var name = "name";
            var value = 42;
            var expected = new Argument<int>(name, value);
            Assert.AreEqual(expected, value.Require(name));
        }
        
        [TestMethod]
        public void Require_AllowsNullSubject()
        {
            Assert.IsNull((null as object).Require("name").Value);
        }
    }
}
