using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace O2_LuckyTickets
{
    public class RecursiveWay_a : IWork
    {        
        private Cancelation _cancelation;
        public string Run(string[] data, Cancelation cancelation)
        {
            _cancelation = cancelation;
            return GetLuckyCount2(int.Parse(data[0]), 0, 0).ToString();
        }

        long GetLuckyCount2(int N, int sumA, int sumB)
        {            
            long res = 0;
            for (int a = 0; a <= 9; a++)
            {
                int nextSumA = sumA + a;
                for (int b = 0; b <= 9; b++)
                {
                    if(_cancelation.Cancel)
                        return 0;

                    int nextSumB = sumB + b;

                    if (N == 1)
                    {
                        if (nextSumA == nextSumB)
                            res += 1;
                    }
                    else
                        res += GetLuckyCount2(N - 1, nextSumA, nextSumB);
                }
            }

            return res;
        }

        public string Name
        { get { return "RecursiveWay_a"; } }
    }
}
