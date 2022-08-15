using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O4_DataStructuries.Arrays
{
    // обертка над List<T>
    public class ArrayList<T> : IArray<T>
    {
        private List<T> _list = new List<T>();
        public void Add(T item)
        {
            _list.Add(item);
        }
        public void Add(T item, int index)
        {
            _list.Insert( index, item);
        }

        public T Remove(int index)
        {
            T item = _list[index];
            _list.RemoveAt(index);
            return item;
        }

        public T Get(int index)
        {
            return _list[index];
        }
        public int Size { get { return _list.Count; } }

        public bool IsEmpty { get {return _list.Count==0; } }

    }
}
