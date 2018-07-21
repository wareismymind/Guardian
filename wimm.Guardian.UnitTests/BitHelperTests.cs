using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wimm.Guardian.UnitTests
{
    [TestClass]
    public class BitHelperTests
    {



        [DataTestMethod]
        [DataRow(1,1)]
        [DataRow(0, 0)]
        [DataRow(-0, 0)]
        [DataRow(-1, 32)]
        [DataRow(127, 7)]
        [DataRow(-128,25)]
        [DataRow(int.MaxValue, 31)]
        [DataRow(int.MinValue, 1)]
        public void KernighanPopCount_ValidInt_ReturnsValidNumberOfBits(int input, int result)
        {
            Assert.AreEqual(result, BitHelpers.KernighanPopCount(input));
        }

        [DataTestMethod]
        [DataRow(1, 1)]
        [DataRow(0, 0)]
        [DataRow(-0, 0)]
        [DataRow(-1, 32)]
        [DataRow(127, 7)]
        [DataRow(-128, 25)]
        [DataRow(int.MaxValue, 31)]
        [DataRow(int.MinValue, 1)]
        public void Popcount_ValidInt_ReturnsValidNumberOfBits(int input, int result)
        {
            Assert.AreEqual(result, BitHelpers.PopCount(input));
        }



        [DataTestMethod]
        [DataRow(1L, 1)]
        [DataRow(0L, 0)]
        [DataRow(-0L, 0)]
        [DataRow(-1L, 64)]
        [DataRow(127L, 7)]
        [DataRow(-128L, 57)]
        [DataRow(long.MaxValue, 63)]
        [DataRow(long.MinValue, 1)]
        public void Popcount_ValidLong_ReturnsValidNumberOfBits(long input, int result)
        {
            Assert.AreEqual(result, BitHelpers.PopCount(input));
        }


    }
}
