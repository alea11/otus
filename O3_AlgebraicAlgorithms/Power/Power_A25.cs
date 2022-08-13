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
    public class Power_A25 : IWork<double>
    {
        private Cancelation _cancelation;

        // алгоритм возведения в степень через степень двойки с рекурсивным домножением на результаты возведения в меньшие степени двойки 
        public double Run(string[] data, Cancelation cancelation)
        {
            _cancelation = cancelation;

            //double a = double.Parse(data[0].Replace('.', ','));
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(double));
            double a = (double)converter.ConvertFromString(null, CultureInfo.InvariantCulture, data[0]);
            long pow = long.Parse(data[1]);

            return PowPow2(a, ref pow);


        }

        double PowPow2(double a, ref long pow)
        {
            double res = pow == 0 ? 1 : a;
            long p = 0;

            for (p = 2; p <= pow; p *= 2)
            {                
                res *= res;
            }

            pow = pow - (p>>1); //остается еще  'добрать' степень. перед этом отменяем последнеее удвоение степени (уже лишнее для результата, но было нужным для проверки цикла)
            if (pow <= 0)
                return res;
            return res * PowPow2(a, ref pow);            
        }

        public string Name
        { get { return "Power_A25 (рекурсивное перемножением блоков по степеням двойки)"; } }
    }
}
