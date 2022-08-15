using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O4_DataStructuries
{

    public class SingleArrayTest : IWork
    {
        private Cancelation _cancelation;
        public void Run(string[] data, Cancelation cancelation)
        {
            _cancelation = cancelation;
            int total = int.Parse(data[0]);

            IArray<int> arr = new SingleArray<int>();

            for(int i = 0; i<total; i++)
            {
                arr.Add(i);
            }
        }

        public string Name
        { get { return "SingleArrayTest (добавление элементов)"; } }
    }
}
