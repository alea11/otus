
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3_AlgebraicAlgorithms.Primes
{
    public class Primes_EraLin : IWork<uint>
    {
        private Cancelation _cancelation;
        
        public uint Run(string[] data, Cancelation cancelation)
        {
            _cancelation = cancelation;

            uint limit = uint.Parse(data[0]);            

            uint[] divs = new uint[limit+1]; // тут храним наименьший делитель числа, заданного индексом

            uint[] primes = new uint[limit/2+1]; 
            //List<uint> primes = new List<uint>(); // список найденных простых

            uint count = 0;
            for (uint i = 2; i <= limit; i++)
            {
                // проверяем , если пока не отмечено - то это простое
                if (divs[i] == 0)
                {
                    divs[i] = i;

                    //primes.Add(i);
                    primes[count] = i;

                    count++;
                }

                // отмечаем кратные
                int p = 0;               
                while((uint)p< count &&   primes[p] <=  divs[i] && primes[p] * i <= limit)
                {
                    divs[primes[p] * i] = primes[p];
                    p++;
                }               
            }

            return count;
        }


        public string Name
        { get { return "Primes_EraLin (проверка на простоту - решето Эратосфена, линейная сложность (без повторных проверок) )"; } }
    }
}
