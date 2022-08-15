using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IArray<T>
    {
        void Add(T item);
        void Add(T item, int index);

        T Get(int index);
        int Size { get;  } //private set;

        bool IsEmpty { get; }
    }
}
/*
 *  фиксированный
 * динамический
 * разреженный
 * 
 * ассоциативный - исп хэшкод как ссылку
 *      кей-валуе - хорош для массива с редким заполнением
 *      
 *      параллельный
 *      
 *      
 *      
 *      списки одно и двунапр
 *      
 *      стэк
 *      
 *      очередь
 *      очередь с приоритетами - ограниченный список приоритетов
                и       неограниченный - хранение в виде односвязного списка
 */