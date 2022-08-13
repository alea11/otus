using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3_AlgebraicAlgorithms.Primes
{
    public class Primes_A3 : IWork<ulong>
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
                if (IsPrimeA3(n))
                    count++;
            }
             
            return count;
        }

        private bool IsPrimeA3(ulong n)
        {
            ulong lim = n / 2;
            for (ulong d = 2; d <= lim; d++)
            {
                if (_cancelation.Cancel)
                    return false;
                if (n % d == 0)
                    return false;
            }

            return true;
        }

        public string Name
        { get { return "Primes_A3  (проверка на простоту - только до n/2)"; } }
    }
}