using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        // путь к папке с данными тестирования заданий по 2-й лекции
        private const string path_02 = "..\\..\\..\\TestingFiles\\1.Tickets"; // если идти из места сборки
        static void Main(string[] args)
        {  
            Tester tester = new Tester( new O2_LuckyTickets.DirectlyWay6(), path_02, 2, 2);
            tester.Run();

            tester = new Tester(new O2_LuckyTickets.DirectlyWay6_a(), path_02, 2, 2);
            tester.Run();
            
            tester = new Tester(new O2_LuckyTickets.RecursiveWay(), path_02, 0, 4, maxDuration: 20000);
            tester.Run();
            
            tester = new Tester(new O2_LuckyTickets.RecursiveWay_a(), path_02 , 0, 4, maxDuration: 20000);
            tester.Run();

            tester = new Tester(new O2_LuckyTickets.ExcelWay(), path_02);
            tester.Run();

            tester = new Tester(new O2_LuckyTickets.ExcelRecursiveWay(), path_02, maxDuration: 20000);
            tester.Run();

            Console.WriteLine("\n\rpress any key");
            Console.ReadKey();
        }
    }
}
