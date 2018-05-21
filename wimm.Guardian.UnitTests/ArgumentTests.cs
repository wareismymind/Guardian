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
                Assert.ThrowsException<ArgumentNullException>(() => new Argument<int>(null, 0));
            Assert.AreEqual("name", ex.ParamName);
        }

        [TestMethod]
        public void Construct_ValidParameters_Constructs()
        {
            var _ = new Argument<int>("name", 42);
        }

        [TestMethod]
        public void Construct_NullValue_Constructs()
        {
            var _ = new Argument<string>("name", null);
        }

        [TestMethod]
        public void Name_HasCorrectValue()
        {
            var name = "name";
            var argument = new Argument<int>(name, 42);
            Assert.AreEqual(name, argument.Name);
        }

        [TestMethod]
        public void Value_ValueType_HasCorrectValue()
        {
            var value = 42;
            var argument = new Argument<int>("name", value);
            Assert.AreEqual(value, argument.Value);
        }

        [TestMethod]
        public void Value_ReferenceType_ReferenceEqualsArgument()
        {
            var value = new object();
            var argument = new Argument<object>("name", value);
            Assert.AreSame(value, argument.Value);
        }

        [TestMethod]
        public void Value_Null_IsNull()
        {
            var argument = new Argument<object>("name", null);
            Assert.IsNull(argument.Value);
        }

        [TestMethod]
        public void IsNotNull_ValueIsNull_Throws()
        {
            var argument = new Argument<object>("name", null);
            var ex = Assert.ThrowsException<ArgumentNullException>(() => argument.IsNotNull());
            Assert.AreEqual("name", ex.ParamName);
        }
        
        [TestMethod]
        public void IsNotNull_ValueIsNotNull_ReturnsSelf()
        {
            var argument = new Argument<object>("name", new object());
            Assert.AreEqual(argument, argument.IsNotNull());
        }
    }
}
