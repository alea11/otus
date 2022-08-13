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
    public class Power_A1 : IWork<double>
    {
        private Cancelation _cancelation;
        public double Run(string[] data, Cancelation cancelation)
        {
            _cancelation = cancelation;

            //double a = double.Parse(data[0].Replace('.',','), NumberStyles.Number); //
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(double));
            double a = (double)converter.ConvertFromString(null, CultureInfo.InvariantCulture, data[0]);
            
            long pow = long.Parse(data[1]);

            double res = 1;
            for (int i = 0; i < pow; i++)
            {
                if (_cancelation.Cancel) // работает, но замедление работы почти в 2 раза
                    return 0;
                res *= a;
            }                

            return res;

        }

        public string Name
        { get { return "Power_A1 (умножение в цикле)"; } }
    }
}
