using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3_AlgebraicAlgorithms.Primes
{
    public class Primes_Era : IWork<ulong>
    {
        private Cancelation _cancelation;
                 
        public ulong Run(string[] data, Cancelation cancelation)
        {
            _cancelation = cancelation;

            ulong limit = ulong.Parse(data[0]);
            ulong len = (limit / 32) + 1;

            UInt32[] divs = new UInt32[len];// тут храним биты - признак того что число не простое (вычеркиваем числа), по 32 в одном элементе

            ulong count = 0;
            for(ulong p = 2; p<= limit; p++)
            {
                if (_cancelation.Cancel)
                    return 0;
                // индекс в массиве и смещение
                ulong idx = p >> 5; // /32
                int b = (int)( p - (idx << 5)); // *32 - т.е. получили остаток от деления (p-2)  на 32

                // проверяем соответствующий бит (число не вычеркнуто, то это простое)
                if ( ((divs[idx] >> b) & 1 )== 0 )
                {
                    count++;
                    for (ulong num = p*p; num <= limit; num +=p) // проход по кратным найденного простого, начиная от его квадрата 
                    {
                        // индекс в массиве и смещение
                        ulong numIdx = num >> 5; // /32
                        int numB = (int)(num - (numIdx << 5)); // *32 - т.е. получили остаток от деления (num-2)  на 32
                        // устанавливаем соответствующий бит
                        divs[numIdx] |= (UInt32)(1 << numB);
                    }
                }
            }

            return count;
        }

        

        public string Name
        { get { return "Primes_Era (проверка на простоту - решето Эратосфена)"; } }
    }
}
