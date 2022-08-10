using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3_AlgebraicAlgorithms.Fibo
{
    public class Fibo_A1 : IWork<ulong>
    {
        private Cancelation _cancelation;
        public ulong Run(string[] data, Cancelation cancelation)
        {
            _cancelation = cancelation;

            //double a = double.Parse(data[0].Replace('.',','));
            //long pow = long.Parse(data[1]);

            ulong res = 1;
            //for (int i = 0; i < pow; i++)
            //{
            //    if (_cancelation.Cancel) // работает, но замедление работы почти в 2 раза
            //        return 0;
            //    res *= a;
            //}                

            return res;

        }

        public string Name
        { get { return "Fibo_A1 ()"; } }
    }
}
