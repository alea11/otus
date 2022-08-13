using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    // пока заглушка
    public class BigInt
    {
        private ulong[] _digits;
        private bool _sign;

        public BigInt(int length)
        {
            _digits = new ulong[length];
        }

        public BigInt(string snum)
        {
            snum = snum.Trim();
            if (snum.StartsWith("-"))
            {
                _sign = true;
                snum = snum.Substring(1).Trim();
            }
            if(snum.StartsWith("0x", true, CultureInfo.InvariantCulture))
            {
                // 16-ричное представление
                snum = snum.Substring(2).Trim();
                

            }
            else
            {
                // 10-десятичное представление

            }
        }
    }
}
