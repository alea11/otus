using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IPriorityQueue<T>
    {
        void Enqueue(int priority, T item);
        bool TryDequeue(out T item);
    }
}
