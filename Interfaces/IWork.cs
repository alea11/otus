﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IWork
    {        
        string Run(string[] data, Cancelation cancelation); //CancellationToken ct
        string Name { get; }
    }
}
