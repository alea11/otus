using Interfaces;
using O4_DataStructuries.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O4_DataStructuries.Queues
{
    public class FixedPriorityQueue<T> : IPriorityQueue<T>
    {
        private FactorArray<T>[] _prioritiesArr;

        public FixedPriorityQueue(int prioritiescount)
        {
            _prioritiesArr = new FactorArray<T>[prioritiescount];
            for (int i = 0; i < prioritiescount; i++)
                _prioritiesArr[i] = new FactorArray<T>();
        }
        public void Enqueue(int priority, T item)
        {
            _prioritiesArr[priority].Add(item);
        }
        public bool TryDequeue(out T item)
        {
            // находим первый непустой контейнер, и забираем оттуда первый элемент

            item = default(T);

            int prioritiescount = _prioritiesArr.Length;
            int idx = 0;
            while (idx < prioritiescount && _prioritiesArr[idx].IsEmpty)
            {
                idx++;
            }
            if (idx < prioritiescount)
            {
                item = _prioritiesArr[idx].Remove(0);
                return true;
            }
            return false;

        }
    }
}
