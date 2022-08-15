using Interfaces;
using O4_DataStructuries.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O4_DataStructuries
{
    public class MatrixArrayTest : ArrayTest, IWork
    {        
        public void Run(string[] data, Cancelation cancelation)
        {            
            int mode = int.Parse(data[0]); // 1 - добавление, 2 - вставка в 0-ю позицию, 3 - удаление из 0-й позиции
            int total = int.Parse(data[1]);

            IArray<int> arr = new MatrixArray<int>();

            base.Run(arr, mode, total, cancelation);
        }

        public string Name
        { get { return $"MatrixArrayTest ({_operation})"; } }
    }
}
