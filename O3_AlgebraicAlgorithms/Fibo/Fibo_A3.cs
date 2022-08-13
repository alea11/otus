using Interfaces;
using AR = Interfaces.Arithmetic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace O3_AlgebraicAlgorithms.Fibo
{
    public class Fibo_A3 : IWork<ulong>
    {
        
        private Cancelation _cancelation;
        public ulong Run(string[] data, Cancelation cancelation)
        {            
            _cancelation = cancelation;

            int N = int.Parse(data[0]);

            if (N == 0)
                return 0;

            double f = (Math.Sqrt(5) +1)/ 2;

            return (ulong)Math.Floor(Math.Pow(f, N) / Math.Sqrt(5) + 0.5);

          
            
        }

        public string Name
        { get { return "Fibo_A3 (алгоритм по формуле золотого сечения)"; } }

        
        
    }
}
