using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3_AlgebraicAlgorithms.Primes
{
    public class Primes_A5 : IWork<ulong>
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
                if (IsPrimeA5(n))
                    count++;
            }

            return count;
        }

        private bool IsPrimeA5(ulong n)
        {
            ulong lim = (ulong)Math.Sqrt(n);
            if (n == 2)
                return true;
            if (n % 2 == 0)
                return false;
            for (ulong d = 3; d <= lim; d += 2)
            {
                if (_cancelation.Cancel)
                    return false;
                if (n % d == 0)
                    return false;
            }

            return true;
        }

        public string Name
        { get { return "Primes_A5 (проверка на простоту - только до Sqrt(n))"; } }
    }
}