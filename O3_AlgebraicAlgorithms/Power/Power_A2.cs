using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O3_AlgebraicAlgorithms.Power
{
    public class Power_A2 : IWork<double>
    {
        private Cancelation _cancelation;

        // алгоритм возведения в степень через степень двойки с домножением
        public double Run(string[] data, Cancelation cancelation)
        {
            _cancelation = cancelation;

            double a = double.Parse(data[0].Replace('.', ','));
            long pow = long.Parse(data[1]);

            double res = pow == 0? 1 : a;
           
            long p2 = 0;  // отработанная степень после 1-го этапа

            for(long p = 2; p <= pow; p*=2) 
            {
                p2 = p;               
                res *= res;                 
            }

            // домножаем
            if (p2 > 0) 
                while (p2 < pow)
                {
                    if (_cancelation.Cancel)
                        return 0;
                    res *= a;
                    p2++;
                }          

            return res;

        }

        public string Name
        { get { return "Power_A2 (степень двойки с домножением)"; } }
    }
}
