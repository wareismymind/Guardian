using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wimm.Guardian
{
    internal static class BitHelpers
    {
        private static readonly int[] _popCountTableSigned;
        private static readonly int[] _popCountTableUnsigned;


        static BitHelpers()
        {
            _popCountTableSigned = new int[256];
            _popCountTableUnsigned = new int[256];

            for (int i = 0; i < 256; i++)
            {
                _popCountTableSigned[i] = KernighanPopCount(i);
            }
        }

        public static int PopCount(int toCount)
        {
            
            return _popCountTableSigned[toCount & 0xFF]
                + _popCountTableSigned[(toCount >> 8) & 0xFF]
                + _popCountTableSigned[(toCount >> 16) & 0xFF]
                + _popCountTableSigned[(toCount >> 24) & 0xFF];
        }

        public static int PopCount(long toCount)
        {
            return PopCount((int)toCount) + PopCount((int)(toCount >> 32));
        }





        public static int KernighanPopCount(int toCount)
        {
            var count = 0;

            while (toCount != 0)
            {
                toCount &= toCount - 1;
                count++;
            }

            return count;
        }

    }
}
