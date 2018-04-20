using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace wimm.Guardian.UnitTests
{
    [TestClass]
    public class ArgumentTests
    {
        [TestMethod]
        public void Construct_NullName_Throws()
        {
            var ex =
                Assert.ThrowsException<ArgumentNullException>(() => new Argument<int>(0, null));
            Assert.AreEqual("name", ex.ParamName);
        }

        [TestMethod]
        public void Construct_ValidParameters_Constructs()
        {
            var _ = new Argument<int>(42, "name");
        }

        [TestMethod]
        public void Construct_NullValue_Constructs()
        {
            var _ = new Argument<string>(null, "name");
        }

        [TestMethod]
        public void Name_HasCorrectValue()
        {
            var name = "name";
            var argument = new Argument<int>(42, name);
            Assert.AreEqual(name, argument.Name);
        }

        [TestMethod]
        public void Value_ValueType_HasCorrectValue()
        {
            var value = 42;
            var argument = new Argument<int>(value, "name");
            Assert.AreEqual(value, argument.Value);
        }

        [TestMethod]
        public void Value_ReferenceType_ReferenceEqualsArgument()
        {
            var value = new object();
            var argument = new Argument<object>(value, "name");
            Assert.AreSame(value, argument.Value);
        }

        [TestMethod]
        public void Value_Null_IsNull()
        {
            var argument = new Argument<object>(null, "name");
            Assert.IsNull(argument.Value);
        }

        [TestMethod]
        public void IsNotNull_ValueIsNull_Throws()
        {
            var argument = new Argument<object>(null, "name");
            var ex = Assert.ThrowsException<ArgumentNullException>(() => argument.IsNotNull());
            Assert.AreEqual("name", ex.ParamName);
        }
        
        [TestMethod]
        public void IsNotNull_ValueIsNotNull_ReturnsSelf()
        {
            var argument = new Argument<object>(new object(), "name");
            Assert.AreSame(argument, argument.IsNotNull());
        }
    }
}
