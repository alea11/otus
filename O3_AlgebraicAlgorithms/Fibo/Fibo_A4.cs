using Interfaces;
using AR = Interfaces.Arithmetic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace O3_AlgebraicAlgorithms.Fibo
{
    public class Fibo_A4 : IWork<BigInteger>
    {

        private Cancelation _cancelation;
        public BigInteger Run(string[] data, Cancelation cancelation)
        {
            //test();
            _cancelation = cancelation;

            int N = int.Parse(data[0]);

            if (N == 0)
                return 0;

            SimplifiedMatrix2<BigInteger> res = new SimplifiedMatrix2<BigInteger>(1, 0, 1); // сначала еденичная матрица
            SimplifiedMatrix2<BigInteger> d = new SimplifiedMatrix2<BigInteger>(1, 1, 0); // матрица с первыми 3-мя элементами ряда 

            int pow = N - 1;
            while (pow >= 1)
            {
                if (pow % 2 == 1)
                    res = res.Mul(d);
                if (_cancelation.Cancel)
                    break;
                d = d.Mul(d);
                pow = pow >> 1; // /=2
            }
            return res.A11;

        }

        public string Name
        { get { return "Fibo_A4 (степенной алгоритм)"; } }

        private void test()
        {
            SimplifiedMatrix2<BigInteger> a = new SimplifiedMatrix2<BigInteger>(3, 2, 1);
            SimplifiedMatrix2<BigInteger> e = new SimplifiedMatrix2<BigInteger>(1, 1, 0);
            SimplifiedMatrix2<BigInteger> b = new SimplifiedMatrix2<BigInteger>(5, 3, 2);
            SimplifiedMatrix2<BigInteger> e0 = new SimplifiedMatrix2<BigInteger>(1, 0, 1);

            SimplifiedMatrix2<BigInteger> r = a.Mul(e);
            SimplifiedMatrix2<BigInteger> r1 = a.Mul(a);
            SimplifiedMatrix2<BigInteger> r2 = a.Mul(b);
            SimplifiedMatrix2<BigInteger> r3 = b.Mul(a);
            SimplifiedMatrix2<BigInteger> r4 = b.Mul(e0);
        }


        class SimplifiedMatrix2<T>  // симметричная относительно диагонали, 2*2 матрица. только операция умножения
        {
            public readonly T A11;
            public readonly T A12;
            public readonly T A22;

            public SimplifiedMatrix2(T a11, T a12, T a22)
            {
                A11 = a11;
                A12 = a12;
                A22 = a22;
            }

            public SimplifiedMatrix2<T> Mul(SimplifiedMatrix2<T> m)
            {
                return new SimplifiedMatrix2<T>(
                    AR.Add(AR.Mul(this.A11, m.A11), AR.Mul(this.A12, m.A12)),
                    AR.Add(AR.Mul(this.A11, m.A12), AR.Mul(this.A12, m.A22)),
                    AR.Add(AR.Mul(this.A12, m.A12), AR.Mul(this.A22, m.A22))
                    );
            }

        }



    }
}
