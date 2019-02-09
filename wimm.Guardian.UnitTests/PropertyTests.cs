using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wimm.Guardian.UnitTests
{
    [TestClass]
    public class PropertyTests
    {
        [TestMethod]
        public void Property_ExpressionAccessesProperty_ReturnsPropertyName()
        {
            var dummy = new Dummy(123);
            var underTest = dummy.Require(nameof(dummy)).Property(x => x.Doot);
            Assert.AreEqual("dummy.Doot", underTest.Name);
        }

        [TestMethod]
        public void Property_ExpressionAccessProperty_ReturnsPropertyValue()
        {
            var dummy = new Dummy(123);
            var underTest = dummy.Require(nameof(dummy)).Property(x => x.Doot);
            Assert.AreEqual(123, underTest.Value);
        }


        [TestMethod]
        public void Property_ExpressionDoesNotAccessProperty_Throws()
        {
            var dummy = new Dummy(123);
            Assert.ThrowsException<InvalidProgramException>(() => dummy.Require(nameof(dummy)).Property(x => 5));
        }


        private class Dummy
        {
            public int Doot { get; }

            public Dummy(int doot)
            {
                Doot = doot;
            }
        }
    }
}
