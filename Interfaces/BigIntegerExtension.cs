using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public static class BigIntegerExtension
    {
        static Cancelation _cancelation = null;
        static BigInteger b10 = new BigInteger(10);

        // пока работаем только с целыми
        public static void Load(this ref BigInteger num, string str, Cancelation cancelation, ref long duration)
        {
            _cancelation = cancelation;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            
            num = _Load(str);
            sw.Stop();
            duration = sw.ElapsedMilliseconds;
        }

        /// <summary>
        ///  Рекурсивная загрузка числа из строки - делим ее на 2 части, которые загружаем раздельно (старшую половину домножаем на 10 в соотв. степени) и т.д.
        /// </summary>
        
        static private BigInteger _Load(string str)
        {
            if (_cancelation.Cancel)
                return 0;
            if (str.Length <= 15)
                return BigInteger.Parse(str);
            int poz = str.Length / 2;
            string str0 = str.Substring(poz);
            string str1 = str.Substring(0, poz);

            return _Load(str0) + _Load(str1) * Pow10(str.Length - poz);
        }

        private static Dictionary<int, BigInteger> _pows10 = new Dictionary<int, BigInteger>();
        private static BigInteger Pow10(int pow)
        {
            if (_cancelation.Cancel)
                return 0;
            BigInteger val;            
            if (_pows10.ContainsKey(pow))
                val = _pows10[pow];
            else
            {
                //val = new BigInteger(10).Pow(pow);
                val = b10.Pow(pow);
                _pows10.Add(pow, val);
            }
            return val;           
            
        }

        /// <summary>
        /// Возведение в степень алгоритмом разложения степени по степеням 2
        /// </summary>
        /// <param name="a"></param>
        /// <param name="pow"></param>
        /// <returns></returns>
        public static BigInteger Pow(this BigInteger a,   int pow)
        {
            BigInteger res = 1;
            while (pow >= 1)
            {
                if (pow % 2 == 1)
                    res *= a;
                a *= a;
                pow = pow >> 1; // /=2
            }
            return res;
        }

                 

              
    }
}
