using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O4_DataStructuries
{
    public class ArrayTest
    {
        private Cancelation _cancelation;
        protected int _mode;
        protected string _operation;

        protected void Run(IArray<int> array, int mode, int total, Cancelation cancelation)
        {
            _cancelation = cancelation;
            _mode = mode; // 1 - добавление, 2 - вставка в 0-ю позицию, 3 - удаление из 0-й позиции

            switch (_mode)
            {
                case 1:
                    _operation = "добавление элементов";
                    for (int i = 0; i < total; i++)
                    {
                        array.Add(i);
                    }
                    break;
                case 2:
                    _operation = "вставка элементов";
                    for (int i = 0; i < total; i++)
                    {
                        array.Add(i, 0);
                    }
                    break;
                case 3:
                    _operation = "добавление элементов + удаление элементов";
                    for (int i = 0; i < total; i++)
                    {
                        array.Add(i);
                    }
                    for (int i = 0; i < total; i++)
                    {
                        array.Remove(0);
                    }
                    break;

            }
        }
    }
}
