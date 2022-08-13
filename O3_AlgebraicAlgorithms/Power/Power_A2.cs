using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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

            //double a = double.Parse(data[0].Replace('.', ','));
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(double));
            double a = (double)converter.ConvertFromString(null, CultureInfo.InvariantCulture, data[0]);

            long pow = long.Parse(data[1]);

            double res = pow == 0? 1 : a;
           
            long p = 0;

            for (p = 2; p <= pow; p*=2) 
            {                         
                res *= res;                 
            }

            p = p >> 1; // отмена последнего удвоения степени (уже лишнего для результата, но было нужным для проверки цикла)

            // домножаем
            if (p > 0)
                while (p < pow) 
                {
                    if (_cancelation.Cancel)
                        return 0;
                    res *= a;
                    p++;
                }          

            return res;

        }

        public string Name
        { get { return "Power_A2 (степень двойки с домножением)"; } }
    }
}
