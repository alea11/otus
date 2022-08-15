using Interfaces;
using O4_DataStructuries.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O4_DataStructuries.Queues
{
    public class InfinityPriorityQueue<T> : IPriorityQueue<T>
    {
        private FactorArray<PriorityItem> _array;
        private int _count = 0;

        public  InfinityPriorityQueue()
        {
            _array = new FactorArray<PriorityItem>();            
        }

        public void Enqueue(int priority, T item)
        {
            PriorityItem priorityItem = new PriorityItem { Priority = priority, Item = item };

            // находим индекс вставки в соответствии с приоритетом
            int idx = FindNextPriorityIndex(priority, 0, _array.Size-1);
            _array.Add(priorityItem, idx);            
            _count++;
        }

        public bool TryDequeue(out T item)
        {
            item = default(T);

            if (!_array.IsEmpty)
            {
                PriorityItem priorityItem = _array.Remove(0);
                item = priorityItem.Item;
                _count--;
                return true;
            }  

            return false;
        }

        // рекурсивный поиск позиции элемента с наименьшим превышающим искомый приоритетом ("наименьшим превышающим..." - имеется ввиду значение, чем значение больше - приоритет ниже )
        // на каждом следующем уровне делим диапазон вдвое, выбираем нужный по условию
        private int FindNextPriorityIndex(int priority, int startIdx, int endIdx)
        {
            if (startIdx >= endIdx)
                return startIdx;
            int leftPriority = _array.Get(startIdx).Priority;
            int rightPriority = _array.Get(endIdx).Priority;

            if (priority < leftPriority)
                return startIdx;

            if (priority >= rightPriority)
                return endIdx + 1;

            int midIdx = (startIdx + endIdx) / 2;
            int midPriority = _array.Get(midIdx).Priority;

            if (priority < midPriority)
                return FindNextPriorityIndex(priority, startIdx, midPriority);

            return FindNextPriorityIndex(priority, midIdx+1, endIdx);
        }

        class PriorityItem
        { 
            public int Priority { get; set; } 
            public T Item{ get; set; }
        }
    }
}
