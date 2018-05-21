using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wimm.Guardian.UnitTests
{
    [TestClass]
    public class StringExtensionTests
    {
        private const string _name = "paramName";

        [TestMethod]
        public void IsNotNullOrWhitespace_TargetNull_Throws()
        {
            var underTest = new Argument<string>(_name, null);

            var ex = Assert.ThrowsException<ArgumentNullException>(
                () => underTest.IsNotNullOrWhitespace());

            Assert.AreEqual(_name, ex.ParamName);
        }

        [TestMethod]
        public void IsNotNullOrWhitespace_IsWhitespace_Throws()
        {
            var underTest = new Argument<string>(_name, "\t");

            var ex = Assert.ThrowsException<ArgumentException>(
                () => underTest.IsNotNullOrWhitespace());

                Assert.AreEqual(_name, ex.ParamName);
        }

        [TestMethod]
        public void IsNotNullOrWhitespace_IsEmpty_Throws()
        {
            var underTest = new Argument<string>(_name, string.Empty);

            var ex = Assert.ThrowsException<ArgumentException>(
                () => underTest.IsNotNullOrWhitespace());

            Assert.AreEqual(_name, ex.ParamName);
        }

        [TestMethod]
        public void IsNotNullOrWhitespace_IsValid_ReturnsTarget()
        {
            var underTest = new Argument<string>(_name, "valid");
            var ret = underTest.IsNotNullOrWhitespace();

            Assert.AreEqual(underTest, ret);
        }

        [TestMethod]
        public void IsNotWhitespace_IsWhitespace_Throws()
        {
            var underTest = new Argument<string>(_name, "\t");

            var ex = Assert.ThrowsException<ArgumentException>(
                () => underTest.IsNotWhitespace());

            Assert.AreEqual(_name, ex.ParamName);
        }
        
        [TestMethod]
        public void IsNotWhitespace_IsEmpty_Throws()
        {
            var underTest = new Argument<string>(_name, string.Empty);

            var ex = Assert.ThrowsException<ArgumentException>(
            () => underTest.IsNotWhitespace());

            Assert.AreEqual(_name, ex.ParamName);
        }

        [TestMethod]
        public void IsNotWhitespace_IsNull_ReturnsTarget()
        {
            var underTest = new Argument<string>(_name, null);
            var ret = underTest.IsNotWhitespace();

            Assert.AreEqual(underTest, ret);
        }

        [TestMethod]
        public void IsNotWhitespace_IsValid_ReturnsTarget()
        {
            var underTest = new Argument<string>(_name, "valid");
            var ret = underTest.IsNotWhitespace();

            Assert.AreEqual(underTest, ret);
        }

        [TestMethod]
        public void IsNotEmpty_IsEmpty_Throws()
        {
            var underTest = new Argument<string>(_name, string.Empty);

            var ex = Assert.ThrowsException<ArgumentException>(
            () => underTest.IsNotEmpty());

            Assert.AreEqual(_name, ex.ParamName);
        }

        [TestMethod]
        public void IsNotEmpty_IsNull_ReturnsTarget()
        {
            var underTest = new Argument<string>(_name, null);
            var ret = underTest.IsNotEmpty();

            Assert.AreEqual(underTest, ret);
        }

        [TestMethod]
        public void IsNotEmpty_IsWhitespace_ReturnsTarget()
        {
            var underTest = new Argument<string>(_name, "\t");
            var ret = underTest.IsNotEmpty();

            Assert.AreEqual(underTest, ret);
        }

        [TestMethod]
        public void IsNotEmpty_IsValid_ReturnsTarget()
        {
            var underTest = new Argument<string>(_name, "valid");
            var ret = underTest.IsNotEmpty();

            Assert.AreEqual(underTest, ret);
        }

    }
}
