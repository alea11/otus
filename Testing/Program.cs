using Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
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
            Console.WriteLine("Select tests:\r\n");
            Console.WriteLine("1 - LuckyTickets");
            Console.WriteLine("2 - AlgebraicAlgorithms");
            Console.WriteLine("3 - DataStructuries");

            char selection = Console.ReadKey().KeyChar;

            Console.WriteLine();
            switch (selection)
            {
                case '1':
                    RunTests_2();
                    break;
                case '2':

                    Console.WriteLine("\r\nSelect subtests:\r\n");
                    Console.WriteLine("1 - Power");
                    Console.WriteLine("2 - Fibo");
                    Console.WriteLine("3 - Primes");                    

                    char subselection = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    switch (subselection)
                    {
                        case '1':
                            RunTests_3A();
                            break;
                        case '2':
                            RunTests_3B();
                            break;
                        case '3':
                            RunTests_3C();
                            break;
                        default:
                            return;
                    }

                    break;
                case '3':

                    RunTests_4();

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

        static void RunTests_3A()
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

        static void RunTests_3B()
        {
            Console.WriteLine("\r\nSelect algorithm:\r\n");
            Console.WriteLine("1 - Рекурсия");
            Console.WriteLine("2 - Иттерационный");
            Console.WriteLine("4 - По формуле золотого сечения");
            Console.WriteLine("8 - Матричный, степенной");
            Console.WriteLine("либо комбинация из этих 4-х по правилу сложения битовых флагов: (1 ... F)");

            char selection = Console.ReadKey().KeyChar;
            Console.WriteLine();

            string sflaggs = $"{selection}";
            int flaggs;
            if(int.TryParse(sflaggs, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out flaggs))
            {
                if((flaggs & 1) == 1)
                {
                    Tester<BigInteger> tester1 = new Tester<BigInteger>(new O3_AlgebraicAlgorithms.Fibo.Fibo_A1(), path_03_Fibo, 0, 7, maxDuration: 20000);
                    tester1.Run();
                }

                if ((flaggs & 2) == 2)
                {
                    Tester<BigInteger> tester2 = new Tester<BigInteger>(new O3_AlgebraicAlgorithms.Fibo.Fibo_A2(), path_03_Fibo, 0, 11, maxDuration: 20000);
                    tester2.Run();
                    tester2.CustomRun(new string[] { "80" }, 23416728348467685);
                }

                if ((flaggs & 4) == 4)
                {
                    Tester<ulong> tester3 = new Tester<ulong>(new O3_AlgebraicAlgorithms.Fibo.Fibo_A3(), path_03_Fibo, 0, 11, maxDuration: 20000);
                    tester3.Run();
                    tester3.CustomRun(new string[] { "80" }, 23416728348467685);
                }

                if ((flaggs & 8) == 8)
                {
                    Tester<BigInteger> tester4 = new Tester<BigInteger>(new O3_AlgebraicAlgorithms.Fibo.Fibo_A4(), path_03_Fibo, maxDuration: 140000);
                    tester4.Run();
                }
            }
            else
                Console.WriteLine("Непонятный выбор.");


        }
         
        static void RunTests_3C()
        {
            Console.WriteLine("\r\nSelect algorithm:\r\n");
            Console.WriteLine("1...6 - A1...A6");
            Console.WriteLine("7 - Решето Эратосфена");
            Console.WriteLine("8 - Решето Эратосфена - линейный");

            char selection = Console.ReadKey().KeyChar;
            Console.WriteLine();

            switch (selection)
            {
                case '1':
                    Tester<ulong> tester1 = new Tester<ulong>(new O3_AlgebraicAlgorithms.Primes.Primes_A1(), path_03_Primes, 0, 9, maxDuration: 20000);
                    tester1.Run();
                    break;
                case '2':
                    Tester<ulong> tester2 = new Tester<ulong>(new O3_AlgebraicAlgorithms.Primes.Primes_A2(), path_03_Primes, 0, 11, maxDuration: 20000);
                    tester2.Run();
                    break;
                case '3':
                    Tester<ulong> tester3 = new Tester<ulong>(new O3_AlgebraicAlgorithms.Primes.Primes_A3(), path_03_Primes, 0, 11, maxDuration: 20000);
                    tester3.Run();
                    break;
                case '4':
                    Tester<ulong> tester4 = new Tester<ulong>(new O3_AlgebraicAlgorithms.Primes.Primes_A4(), path_03_Primes, 0, 11, maxDuration: 20000);
                    tester4.Run();
                    break;
                case '5':
                    Tester<ulong> tester5 = new Tester<ulong>(new O3_AlgebraicAlgorithms.Primes.Primes_A5(), path_03_Primes, 0, 12, maxDuration: 20000);
                    tester5.Run();
                    break;
                case '6':
                    Tester<ulong> tester6 = new Tester<ulong>(new O3_AlgebraicAlgorithms.Primes.Primes_A6(), path_03_Primes, maxDuration: 20000); //, 0, 12
                    tester6.Run();
                    break;

                case '7':
                    Tester<ulong> tester8 = new Tester<ulong>(new O3_AlgebraicAlgorithms.Primes.Primes_Era(), path_03_Primes, maxDuration: 50000); // , 0, 13
                    tester8.Run();
                    break;
                case '8':
                    Tester<uint> tester9 = new Tester<uint>(new O3_AlgebraicAlgorithms.Primes.Primes_EraLin(), path_03_Primes, maxDuration: 20000); //, 0, 13
                    tester9.Run();
                    break;

                     
                default:
                    return;
            }
        }

        static void RunTests_4()
        {
            Console.WriteLine("\r\nSelect operation:\r\n");
            Console.WriteLine("1 - Add");
            Console.WriteLine("2 - Insert");
            Console.WriteLine("3 - Add + Remove");

            char selection = Console.ReadKey().KeyChar;
            Console.WriteLine();

            string mode = selection.ToString();
            

            SimplyTester tester1 = new SimplyTester(new O4_DataStructuries.SingleArrayTest());
            tester1.CustomRun(new string[] { mode, "100" });
            tester1.CustomRun(new string[] { mode, "1000" });
            tester1.CustomRun(new string[] { mode, "10000" });            
            tester1.CustomRun(new string[] { mode, "100000" });

            SimplyTester tester2 = new SimplyTester(new O4_DataStructuries.VectorArrayTest());
            tester2.CustomRun(new string[] { mode, "100", "100" });
            tester2.CustomRun(new string[] { mode, "100", "1000" });
            tester2.CustomRun(new string[] { mode, "100", "10000" });
            if (mode == "1")
            {
                tester2.CustomRun(new string[] { mode, "100", "100000" });            
                tester2.CustomRun(new string[] { mode, "100", "1000000" });
            }
                

            SimplyTester tester3 = new SimplyTester(new O4_DataStructuries.FactorArrayTest());
            tester3.CustomRun(new string[] { mode, "100" });
            tester3.CustomRun(new string[] { mode, "1000" });
            tester3.CustomRun(new string[] { mode, "10000" });
            tester3.CustomRun(new string[] { mode, "100000" });
            if (mode == "1")
            {
                tester3.CustomRun(new string[] { mode, "1000000" });
                tester3.CustomRun(new string[] { mode, "10000000" });
                tester3.CustomRun(new string[] { mode, "100000000" });
            }

            SimplyTester tester4 = new SimplyTester(new O4_DataStructuries.MatrixArrayTest());
            tester4.CustomRun(new string[] { mode, "100" });
            tester4.CustomRun(new string[] { mode, "1000" });
            tester4.CustomRun(new string[] { mode, "10000" });
            tester4.CustomRun(new string[] { mode, "100000" });
            if (mode == "1")
            {
                tester4.CustomRun(new string[] { mode, "1000000" });
                tester4.CustomRun(new string[] { mode, "10000000" });
                tester4.CustomRun(new string[] { mode, "100000000" });
            }

            SimplyTester tester5 = new SimplyTester(new O4_DataStructuries.ArrayListTest());
            tester5.CustomRun(new string[] { mode, "100" });
            tester5.CustomRun(new string[] { mode, "1000" });
            tester5.CustomRun(new string[] { mode, "10000" });
            tester5.CustomRun(new string[] { mode, "100000" });
            tester5.CustomRun(new string[] { mode, "1000000" });
            if (mode == "1")
            {
                tester5.CustomRun(new string[] { mode, "10000000" });
                tester5.CustomRun(new string[] { mode, "100000000" });
            }
        }
    }
}
