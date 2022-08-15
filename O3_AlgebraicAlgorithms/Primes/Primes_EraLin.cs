
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

            uint[] divs = new uint[limit/2+1]; // тут храним наименьший делитель числа, заданного индексом

            uint primescount = limit / 4; // грубая оценка
            if (primescount < 25) 
                primescount = 25;
            uint[] primes = new uint[primescount]; 
            //List<uint> primes = new List<uint>(); // список найденных простых

            uint count = 1;
            for (uint i = 3; i <= limit; i+=2) // проходим только по нечетным
            {
                uint idx = (i - 3) >> 1; // индекс в рабочем массиве учитывает что начали от 3 и проходим только по нечетным
                // проверяем , если пока не отмечено - то это простое
                if (divs[idx] == 0)
                {
                    divs[idx] = i;

                    //primes.Add(i);
                    primes[count] = i;

                    count++;
                }

                // отмечаем кратные
                int p = 1;   // пропускаем 0-й элемент (не учитываем необрабатываемую 2)            
                while((uint)p< count &&   primes[p] <=  divs[idx] && primes[p] * i <= limit)
                {
                    divs[((primes[p] * i) -3) >>1] = primes[p]; // (индекс в рабочем массиве учитывает что начали от 3 и проходим только по нечетным)
                    p++;
                }               
            }

            return count;
        }


        public string Name
        { get { return "Primes_EraLin (проверка на простоту - решето Эратосфена, линейная сложность (без повторных проверок) )"; } }
    }
}
