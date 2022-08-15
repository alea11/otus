using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O4_DataStructuries.Arrays
{
    public class SpaceArray<T> : IArray<T>
    {
        private IArray<Floor> _array;
        //private const int _lvector = 8; // показатель степени 2 
        private int _vector; // размер внутреннего массива - степень 2
        private int _halfVector;
        //private int indexMask; // маска для вычленения внутреннего индекса

        private int _edge; // граница заполнения внутренних массивов при добавлении
        private int _size;

        public SpaceArray(int edgePercent)
        {
            _array = new FactorArray<Floor>();
            _vector = 256;
            _halfVector = _vector / 2;
            _edge = _vector / 100 * edgePercent;
            if (_edge <= 0 || _edge > _vector)
                throw new Exception("Invalid Edge");
            _size = 0;
        }

        public void Add(T item)
        {
            // добавляем в конец последнего массива. Если позиция вставки превышает  _edge - то пишем в новый массив - 'этаж'
            int arrayNum = 0, innerIndex = 0;
            Floor floor;
            if(_array.IsEmpty)
            {                
                floor = AddNewFloor();
            }
            else
            {                
                // находим индекс(-ы) последнего элемента                
                if (TryFindIndex(_size-1, out arrayNum, out innerIndex))
                {
                    if (innerIndex >= _edge)
                    {
                        floor = AddNewFloor();
                        innerIndex = 0;
                    }                        
                    else
                    {
                        floor = _array.Get(arrayNum);
                        innerIndex ++;
                    }                                        
                }
                else
                    throw new IndexOutOfRangeException($"index: {_size - 1},  arrayNum: {arrayNum}, innerIndex: {innerIndex}");                
            }

            floor.Array[innerIndex] = item;
            floor.Size++;
            _size++;
        }

        private Floor AddNewFloor()
        {
            T[] arr = new T[_vector];
            Floor floor = new Floor(arr, _size);
            _array.Add(floor);
            return floor;
        }

        private Floor AddNewFloor(int num,  int startIdx)
        {
            T[] arr = new T[_vector];
            Floor floor = new Floor(arr, startIdx);
            _array.Add(floor, num);
            return floor;
        }

        public void Add(T item, int index)
        {
            // вставка не в конец последнего массива.
            // - Определяем соотв. массив, и если он не заполнен - добавляем туда, а если заполнен - создаем новый, куда переносим половину элементов из предыдущего и добавляем новый элемент
            // После вставки - в цикле инкремент стартового индекса всех последующих этажей.  

            int arrayNum = 0, innerIndex = 0;
            Floor floor;

            // находим индекс(-ы) элемента                
            if (TryFindIndex(index, out arrayNum, out innerIndex))
            {
                if (innerIndex == _vector)
                {
                    Floor prevFloor = _array.Get(arrayNum);
                    arrayNum++;
                    floor = AddNewFloor(num: arrayNum, startIdx: prevFloor.StartIndex + _halfVector);
                    Array.Copy(prevFloor.Array, _halfVector, floor.Array, 0, _vector - _halfVector);
                    prevFloor.Size = _halfVector;
                    floor.Size = _vector - _halfVector;
                    innerIndex = _vector - _halfVector;
                }
                else
                {
                    floor = _array.Get(arrayNum);
                    innerIndex++;
                }
            }
            else
                throw new IndexOutOfRangeException($"index: {index},  arrayNum: {arrayNum}, innerIndex: {innerIndex}");
            

            floor.Array[innerIndex] = item;
            floor.Size++;
            _size++;

            for (int i = arrayNum + 1; i < _array.Size; i++)
            {
                _array.Get(i).StartIndex++;
            }
        }

        public T Remove(int index)
        {
            int arrayNum = 0, innerIndex = 0;
            Floor floor;
            T item;
            // находим индекс(-ы) элемента                
            if (TryFindIndex(index, out arrayNum, out innerIndex))
            {
                item = _array.Get(arrayNum).Array[innerIndex];

                floor = _array.Get(arrayNum);
                if(floor.Size >1)
                {
                    for (int i = innerIndex; i < floor.Size - 1; i++)
                        floor.Array[i] = floor.Array[i + 1];
                    floor.Size--;
                }
                else
                {
                    _array.Remove(arrayNum);
                }
                
            }
            else
                throw new IndexOutOfRangeException($"index: {index},  arrayNum: {arrayNum}, innerIndex: {innerIndex}");
            
            _size--;

            for (int i = arrayNum + 1; i < _array.Size; i++)
            {
                _array.Get(i).StartIndex--;
            }
            return item;
        }

        public T Get(int index)
        {
            int arrayNum, innerIndex;
            if (TryFindIndex(index, out arrayNum, out innerIndex))
            {
                return _array.Get(arrayNum).Array[innerIndex];
            }
            else
                throw new IndexOutOfRangeException($"index: {index},  arrayNum: {arrayNum}, innerIndex: {innerIndex}");
        }
        public int Size { get { return _size; } }

        public bool IsEmpty { get { return _size == 0; } }

        // пока в цикле, но можно оптимизировать - искать бинарным поиском
        private bool TryFindIndex(int index, out int arrayNum, out int innerIndex)
        {
            arrayNum = 0;
            innerIndex = 0;
            for (arrayNum = 0; arrayNum < _array.Size; arrayNum++)
            {
                Floor aas = _array.Get(arrayNum);
                if (index < aas.StartIndex + aas.Size)
                {
                    innerIndex = index - aas.StartIndex;
                    return true;
                }                
            }
            return false;
        }

        class Floor
        {
            public readonly T[] Array;
            public int Size{ get; set; }
            public int StartIndex{ get; set; }

            public Floor(T[] array, int startIndex, int size = 0)
            {
                Array = array;
                StartIndex = startIndex;
            }
        }
    }
}
