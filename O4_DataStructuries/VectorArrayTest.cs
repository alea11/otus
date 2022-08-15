using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O4_DataStructuries
{
    public class VectorArrayTest : IWork
    {
        private Cancelation _cancelation;
        public void Run(string[] data, Cancelation cancelation)
        {
            _cancelation = cancelation;
            int vector = int.Parse(data[0]);
            int total = int.Parse(data[1]);

            IArray<int> arr = new VectorArray<int>(vector);

            for (int i = 0; i < total; i++)
            {
                arr.Add(i);
            }
        }

        public string Name
        { get { return "VectorArrayTest (добавление элементов)"; } }
    }
}
