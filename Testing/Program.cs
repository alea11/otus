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
        // пути к папкам с данными тестирования (относительно места сборки)
        private const string path_02 = "..\\..\\..\\TestingFiles\\1.Tickets";
        private const string path_03_Power = "..\\..\\..\\TestingFiles\\3.Power";
        private const string path_03_Fibo = "..\\..\\..\\TestingFiles\\4.Fibo";
        private const string path_03_Primes = "..\\..\\..\\TestingFiles\\5.Primes";

        static void Main(string[] args)
        {
            Console.WriteLine("Select tests: \n\rLuckyTickets: \t1\r\nAlgebraicAlgorithms: \t2");
            char section = Console.ReadKey().KeyChar;

            Console.WriteLine();
            switch (section)
            {
                case '1':
                    RunTests_2();
                    break;
                case '2':
                    RunTests_3();
                    break;
                default:
                    return;
            }

            

            Console.WriteLine("\n\rpress any key");
            Console.ReadKey();
        }

        static void RunTests_2()
        {
            Tester<int> tester1 = new Tester<int>(new O2_LuckyTickets.DirectlyWay6(), path_02, 2, 2);
            tester1.Run();

            Tester<int> tester2 = new Tester<int>(new O2_LuckyTickets.DirectlyWay6_a(), path_02, 2, 2);
            tester2.Run();

            Tester<long> tester3 = new Tester<long>(new O2_LuckyTickets.RecursiveWay(), path_02, 0, 4, maxDuration: 20000);
            tester3.Run();

            Tester<long> tester4 = new Tester<long>(new O2_LuckyTickets.RecursiveWay_a(), path_02, 0, 4, maxDuration: 20000);
            tester4.Run();

            Tester<ulong> tester5 = new Tester<ulong>(new O2_LuckyTickets.ExcelWay(), path_02);
            tester5.Run();

            Tester<ulong> tester6 = new Tester<ulong>(new O2_LuckyTickets.ExcelRecursiveWay(), path_02, maxDuration: 20000);
            tester6.Run();
        }

        static void RunTests_3()
        {
            Tester<double> tester1 = new Tester<double>(new O3_AlgebraicAlgorithms.Power.Power_A1(), path_03_Power, maxDuration: 20000);
            tester1.Run();

            Tester<double> tester2 = new Tester<double>(new O3_AlgebraicAlgorithms.Power.Power_A2(), path_03_Power, maxDuration: 20000);
            tester2.Run();

            Tester<double> tester25 = new Tester<double>(new O3_AlgebraicAlgorithms.Power.Power_A25(), path_03_Power, maxDuration: 20000);
            tester25.Run();

            Tester<double> tester3 = new Tester<double>(new O3_AlgebraicAlgorithms.Power.Power_A3(), path_03_Power, maxDuration: 20000);
            tester3.Run();



        }
    }
}
