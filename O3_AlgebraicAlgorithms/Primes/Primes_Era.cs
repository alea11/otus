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
            ulong len = (limit / 64) + 1; // /32 и еще на 2 - храним флаги только по нечетным

            UInt32[] divs = new UInt32[len];// тут храним биты - признак того что число не простое (вычеркиваем числа), по 32 в одном элементе

            ulong count = 1; // уже подсчитано число 2 
            for(ulong p = 3; p<= limit; p+=2)
            {
                if (_cancelation.Cancel)
                    return 0;
                // индекс в массиве и смещение
                ulong idx = (p -3) >> 6; // /64
                int b = (int)(( ((p-3)>>1) - (idx << 6))); // *32 - т.е. получили остаток от деления p-3  на 32

                // проверяем соответствующий бит (число не вычеркнуто, то это простое)
                if ( ((divs[idx] >> b) & 1 )== 0 )
                {
                    count++;
                    ulong p2 = p << 1;
                    for (ulong num = p*p; num <= limit; num +=p2) // проход по кратным найденного простого, начиная от его квадрата (кроме четных)
                    {
                        // индекс в массиве и смещение
                        ulong numIdx = (num-3) >> 6; // /64
                        int numB = (int)((((num-3)>>1) - (numIdx << 6))); // *32 - т.е. получили остаток от деления (num-3)  на 32
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
