using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace O2_LuckyTickets
{
    public class RecursiveWay : IWork
    {
        private Cancelation _cancelation;

        public string Run(string[] data, Cancelation cancelation) //CancellationToken ct
        {
            _cancelation = cancelation;

            //с накоплением результата внутри функции
            return GetLuckyCount(int.Parse(data[0]), 0, 0).ToString();

            // с внешним накоплением результата
            //GetLuckyCount_(int.Parse(data[0]), 0, 0).ToString();
            //return count;
        }

        // вариант с внешним накоплением результата (как на вебинаре)
        private long count = 0;
        void GetLuckyCount_(int N, int sumA, int sumB)
        {
            if (_cancelation.Cancel)
                return;

            if (N == 0)
            {
                if (sumA == sumB) count++;
            }

            long res = 0;
            for (int a = 0; a <= 9; a++)
                for (int b = 0; b <= 9; b++)
                {
                    GetLuckyCount_(N - 1, sumA + a, sumB + b);
                }            
        }



        // вариант с накоплением результата внутри функции
        long GetLuckyCount(int N, int sumA, int sumB )
        {
            if(_cancelation.Cancel)
                return 0;

            if (N == 0)
            {
                return (sumA == sumB) ? 1 : 0;
            }

            long res = 0;
            for (int a = 0; a <= 9; a++)
                for (int b = 0; b <= 9; b++)
                {
                    res += GetLuckyCount(N - 1, sumA + a, sumB + b);
                }
            return res;
        }

        public string Name
        { get { return "RecursiveWay"; } }
    }
}
