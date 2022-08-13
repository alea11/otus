using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace O3_AlgebraicAlgorithms.Fibo
{
    public class Fibo_A1 : IWork<BigInteger>
    {
        private Cancelation _cancelation;
        public BigInteger Run(string[] data, Cancelation cancelation)
        {
            _cancelation = cancelation;


            int N = int.Parse(data[0]);                    

            return GetFibo(N);
        }

        private BigInteger GetFibo(int N)
        {
            if (_cancelation.Cancel)
                return 0;
            if (N <= 1)
                return N;
            return GetFibo(N - 1) + GetFibo(N - 2);
        }

        public string Name
        { get { return "Fibo_A1 (рекурсивный алгоритм)"; } }
    }
}
