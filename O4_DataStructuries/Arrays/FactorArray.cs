using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O4_DataStructuries.Arrays
{
    public class FactorArray<T> : IArray<T>
    {
        private T[] _array;
        int _factor;
        int _size;
        
        public FactorArray()
        {
            _factor = 2;
            _array = new T[10];
            _size = 0;
        }

        public void Add(T item)
        {
            if (Size == _array.Length)
                Resize();
            _size++;
            _array[Size - 1] = item;
        }
        public void Add(T item, int index)
        {
            if (Size == _array.Length)
                Resize(tailIndex: index);
            else
            {
                for (int i = _size - 1; i >= index; i--)
                    _array[i + 1] = _array[i];
            }
            _size++;
            _array[index] = item;
        }

        public T Remove(int index)
        {
            T item = _array[index];

            if (Size == _array.Length / (_factor * 2))
                // если после нескольких удалений размер неиспользуемой области увеличился в  _factor * 2 - то сокращаем это соотношение до _factor                
                ReduceSize(tailIndex: index);
            else
            {
                // поэлементный перенос 'хвоста' массива на 1 позицию влево 
                for (int i = index; i < Size - 1; i++)
                    _array[i] = _array[i + 1];
            }
            _size--;

            return item;
        }

        public T Get(int index)
        {
            return _array[index];
        }

        public int Size { get { return _size; } }

        public bool IsEmpty
        {
            get { return Size == 0; }
        }

        private void Resize()
        {
            T[] newArray = new T[Size * _factor];
            if (!IsEmpty)
                Array.Copy(_array, newArray, Size);
            _array = newArray;
        }

        /// <summary>
        /// Resize с разделением исходного массива
        /// </summary>
        /// <param name="tailIndex">индекс (в исходном массиве) первого сдвигаемого элемента</param>
        private void Resize(int tailIndex)
        {
            T[] newArray = new T[Size * _factor];
            if (!IsEmpty)
            {
                if (tailIndex > 0)
                    Array.Copy(_array, 0, newArray, 0, tailIndex);
                if (tailIndex < Size)
                    Array.Copy(_array, tailIndex, newArray, tailIndex + 1, Size - tailIndex);
            }
            _array = newArray;
        }

        /// <summary>
        /// Сокращение массива  с разделением исходного массива и сдвигом 'хвоста' влево
        /// </summary>
        /// <param name="tailIndex">индекс (в исходном массиве) первого сдвигаемого элемента</param>
        private void ReduceSize(int tailIndex)
        {
            T[] newArray = new T[Size * _factor];

            if (tailIndex > 0)
                Array.Copy(_array, 0, newArray, 0, tailIndex);
            if (tailIndex < Size - 1)
                Array.Copy(_array, tailIndex + 1, newArray, tailIndex, Size - 1 - tailIndex);
            _array = newArray;
        }
    }
}
