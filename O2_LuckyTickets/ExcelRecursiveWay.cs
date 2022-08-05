using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace O2_LuckyTickets
{
    public class ExcelRecursiveWay : IWork
    {
        private Cancelation _cancelation;
        public string Run(string[] data, Cancelation cancelation) //CancellationToken ct
        {
            _cancelation = cancelation;

            int N = int.Parse(data[0]);
            
            // пока только заглушка
            

                return "0";
        }

        public string Name
        { get { return "ExcelRecursiveWay"; } }
    }

}
