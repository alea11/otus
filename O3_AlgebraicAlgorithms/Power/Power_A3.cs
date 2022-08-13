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
    public class Power_A3 : IWork<double>
    {
        private Cancelation _cancelation;
        public double Run(string[] data, Cancelation cancelation)
        {
            _cancelation = cancelation;
            //double a = double.Parse(data[0].Replace('.', ','));
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(double));
            double d = (double)converter.ConvertFromString(null, CultureInfo.InvariantCulture, data[0]);
            long pow = long.Parse(data[1]);

            double res = 1;            

            while (pow >= 1)
            {
                if (pow % 2 == 1)
                    res *= d;
                d *= d;
                pow = pow >> 1; // /=2
            }            
            return res;            
        }        

        public string Name
        { get { return "Power_A3 (двоичное разложение показателя степени)"; } }
    }
}
