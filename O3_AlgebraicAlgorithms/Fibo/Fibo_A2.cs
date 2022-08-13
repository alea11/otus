using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace O3_AlgebraicAlgorithms.Fibo
{
    public class Fibo_A2 : IWork<BigInteger>
    {
        private Cancelation _cancelation;
        public BigInteger Run(string[] data, Cancelation cancelation)
        {
            _cancelation = cancelation;


            int N = int.Parse(data[0]);

            BigInteger fA = 0;
            BigInteger fB = 1;
            if (N == 0)
                return fA;

            for(int i=1;i<N;i++)
            {
                BigInteger t = fB;
                fB = fA + fB;
                fA = t;
            }
            return fB ;
        }

       

        public string Name
        { get { return "Fibo_A2 (итеративный алгоритм)"; } }
    }
}
