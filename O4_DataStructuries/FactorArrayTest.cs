using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O4_DataStructuries
{
    public class FactorArrayTest : IWork
    {
        private Cancelation _cancelation;
        public void Run(string[] data, Cancelation cancelation)
        {
            _cancelation = cancelation;            
            int total = int.Parse(data[0]);

            IArray<int> arr = new FactorArray<int>();

            for (int i = 0; i < total; i++)
            {
                arr.Add(i);
            }
        }

        public string Name
        { get { return "FactorArrayTest (добавление элементов)"; } }
    }
}
