using Interfaces;
using O4_DataStructuries.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O4_DataStructuries
{
    public class VectorArrayTest : ArrayTest, IWork
    {        
        public void Run(string[] data, Cancelation cancelation)
        {            
            int mode = int.Parse(data[0]); // 1 - добавление, 2 - вставка в 0-ю позицию, 3 - удаление из 0-й позиции
            int vector = int.Parse(data[1]);
            int total = int.Parse(data[2]);

            IArray<int> arr = new VectorArray<int>(vector);
            base.Run(arr, mode, total, cancelation);
        }

        public string Name
        {  get {  return $"VectorArrayTest ({_operation})"; } }
    }
}
