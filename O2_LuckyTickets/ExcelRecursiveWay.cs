using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2_LuckyTickets
{
    public class ExcelRecursiveWay : IWork
    {
        private Cancelation _cancelation;
        public string Run(string[] data, Cancelation cancelation)
        {
            _cancelation = cancelation;

            int N = int.Parse(data[0]);
            ulong result = 0;

            // массив частичных сумм(по каждому варианту сумм цифр половинки записи числа)            
            long[] partSums = GetPartSums(N-1);


            // общее к-во "счастливых" комбинаций : по каждому значению суммы цифр к-во комбинаций равно квадрату числа комбинаций в половинках (сопоставление каждого варианта с каждым)
            // , ну и накапливаем количества комбинаций для каждого из значений суммм цифр
            foreach (ulong psum in partSums)
            {
                result += (psum * psum);
            }

            return result.ToString();
        }

        private long[] GetPartSums(int N)
        {
            if(N==0)
            {
                // на первом шаге (для одноразрядных чисел)  вариантов сумм цифр по каждому значению (0...9) - ровно по одному
                return new long[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            }
            else
            {
                // массив частичных сумм на предыдущей иттерации
                long[] partSumsRrev = GetPartSums(N - 1);


                // на последующих шагах (для последующих разрядностей) для каждого варианта сумм цифр
                // - к-во чисел определяется накоплением к-ва цифр по вариантам предыдущего шага по 10 вариантам добавляемой цифры со сдвигом на номер строки
                long[] partSums = new long[partSumsRrev.Length + 9];
                for (int row = 0; row <= 9; row++)
                {
                    for (int i = 0; i < partSumsRrev.Length; i++)
                    {
                        partSums[row + i] += partSumsRrev[i];
                    }
                }

                return partSums;
            }
        }

        public string Name
        { get { return "ExcelRecursiveWay"; } }
    }

}
