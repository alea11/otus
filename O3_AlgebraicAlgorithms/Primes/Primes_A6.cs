using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3_AlgebraicAlgorithms.Primes
{
    public class Primes_A6 : IWork<ulong>
    {
        private Cancelation _cancelation;
        public ulong Run(string[] data, Cancelation cancelation)
        {
            _cancelation = cancelation;

            ulong limit = ulong.Parse(data[0]);

            return GetPrimesCount(limit);
        }

        ulong[] _primes;
        
        private ulong GetPrimesCount(ulong limit)
        {
            ulong c = limit /2 +1;
            _primes = new ulong[c];
            ulong count = 0;
            if(limit >= 2)
                _primes[count++] = 2;

            for (ulong n = 3; n <= limit; n++)
            {
                if (_cancelation.Cancel)
                    return 0;
                if (IsPrimeA6(n))
                    _primes[count++] = n; // тут еще можно оптимизировать затраты памяти - можно не сохранять числа  большие чем sqrt(n)
            }

            return count;
        }

        private bool IsPrimeA6(ulong n)
        {
            // проверяем делимость только на каждое из простых, сохраненных на предыдущих проходах
            ulong lim = (ulong)Math.Sqrt(n);
            
            for (int i= 0; _primes[i] <= lim; i++)
            {
                if (_cancelation.Cancel)
                    return false;
                if (n % _primes[i] == 0)
                    return false;
            }

            return true;
        }

        public string Name
        { get { return "Primes_A6 (проверка на простоту - по делимости только на уже полученные простые)"; } }
    }
}
