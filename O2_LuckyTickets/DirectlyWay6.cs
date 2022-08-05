
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace O2_LuckyTickets
{
    public class DirectlyWay6 : IWork
    {        
        public string Run(string[] data, Cancelation cancelation) //CancellationToken ct
        {
            int res = 0;
            for (int a1 = 0; a1 <= 9; a1++)
            {
                for (int a2 = 0; a2 <= 9; a2++)
                {
                    for (int a3 = 0; a3 <= 9; a3++)
                    {
                        int sumA = a1 + a2 + a3;
                        for (int b1 = 0; b1 <= 9; b1++)
                        {
                            for (int b2 = 0; b2 <= 9; b2++)
                            {
                                for (int b3 = 0; b3 <= 9; b3++)
                                {
                                    int sumB = b1 + b2 + b3;
                                    if (sumB == sumA)
                                        res += 1;
                                }
                            }
                        }
                    }
                }
            }
            return res.ToString();
        }

        public string Name
        { get { return "DirectlyWay6"; } }
    }
}
