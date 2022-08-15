using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IWork
    {
        void Run(string[] data, Cancelation cancelation);
        string Name { get; }
    }

    public interface IWork<T>
    {        
        T Run(string[] data, Cancelation cancelation); //CancellationToken ct
        string Name { get; }
    }
}
