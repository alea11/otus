using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3_AlgebraicAlgorithms.Primes
{
    public class Primes_A1 : IWork<ulong>
    {
        private Cancelation _cancelation;
        public ulong Run(string[] data, Cancelation cancelation)
        {
            _cancelation = cancelation;

            ulong limit = ulong.Parse(data[0]);

            return GetPrimesCount(limit);
        }

        private ulong GetPrimesCount(ulong limit)
        {
            ulong count = 0;
            for (ulong n = 2; n <= limit; n++)
            {
                if (_cancelation.Cancel)
                    return 0;
                if (IsPrimeA1(n))
                    count++;
            }
                
            return count;
        }

        private bool IsPrimeA1(ulong n)
        {
            int dividers = 0;
            for (ulong d = 1; d <= n; d++)
            {
                if (_cancelation.Cancel)
                    return false;
                if (n % d == 0)
                    dividers++;
            }
                
            return dividers == 2;
        }

        public string Name
        { get { return "Primes_A1  (проверка на простоту - по количеству делителей)"; } }
    }
}
