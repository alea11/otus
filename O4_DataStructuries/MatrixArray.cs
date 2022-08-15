using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O4_DataStructuries
{
    public class MatrixArray<T> : IArray<T>
    {
        private IArray<T[]> _array;
        private const int _lvector = 8; // показатель степени 2 
        private int _vector; // размер внутреннего массива - степень 2
        private int indexMask; // маска для вычленения внутреннего индекса
        private int _size;

        public MatrixArray()
        {
            _array = new FactorArray<T[]> ();
            _vector = 1 << _lvector;
            indexMask = _vector - 1;
            _size = 0;
        }        

        public void Add(T item)
        {
            if(Size == _array.Size << _lvector) // * _vector
            {
                _array.Add(new T[_vector]);
            }
            _array.Get(_size >> _lvector)[_size & indexMask] = item; // старшая и младшая части индекса (== _size)
            _size++;

        }
        public void Add(T item, int index)
        {
            throw new NotSupportedException();
        }

        public T Get(int index)
        {
            return _array.Get(index >> _lvector)[index & indexMask]; // старшая и младшая части индекса
        }

        public int Size { get { return _size; } } 

        public bool IsEmpty
        {
            get { return Size == 0; }
        }
    }
}
