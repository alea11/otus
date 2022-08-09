using Interfaces;
using System;
using System.Collections.Generic;
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
            double a = double.Parse(data[0].Replace('.', ','));
            long pow = long.Parse(data[1]);

            double res = 1;
            double d = a;

            while(pow > 1)
            {                
                d *= d;
                pow /= 2;
                if(pow %2 == 1)
                    res *= d;
            }

            
            return res;
        }

        public string Name
        { get { return "Power_A3 (двоичное разложение показателя степени)"; } }
    }
}
