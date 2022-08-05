using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otus_2_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            Program p = new Program();


            sw.Start();
            int count2 = p.LuckyTikets6_2();
            sw.Stop();

            Console.WriteLine($"t2: {count2}, {sw.ElapsedMilliseconds} мс");
            sw.Reset();
            
            sw.Start();
            int count3 = p.LuckyTikets6_3();
            sw.Stop();

            Console.WriteLine($"t3: {count3}, {sw.ElapsedMilliseconds} мс");            
            sw.Reset();

            //sw.Start();
            //long count4 = p.GetLuckyCount(4, 0,0);
            //sw.Stop();

            //Console.WriteLine($"t4: {count4}, {sw.ElapsedMilliseconds} мс");
            //sw.Reset();

            sw.Start();
            long count5 = p.GetLuckyCount2(5, 0, 0);
            sw.Stop();

            Console.WriteLine($"t5: {count5}, {sw.ElapsedMilliseconds} мс");


            Console.ReadKey();
        }

        int c1()
        {
            int res = 0;
            for (int i = 0; i <= 1000000; i++)
            {

            }
            return res;
        }

        private bool partsEqual(int num, int length)
        {
            int m = 1000;
            int a = num % m;
            int b = num / m;

            //int a1 = 

            return false;
        }

        int LuckyTikets6_2()
        {
            int res = 0;
            for(int a1=0; a1<=9;a1++)
            {
                for (int a2 = 0; a2 <= 9; a2++)
                {
                    for (int a3 = 0; a3 <= 9; a3++)
                    {
                        int sumA = a1 + a2 + a3;
                        for (int b1 = 0; b1 <= 9; b1++)
                        {
                            for (int b2 = 0; b2 <= 9; b2++)
                            {
                                for (int b3 = 0; b3 <= 9; b3++)
                                {
                                    int sumB = b1 + b2 + b3;
                                    if (sumB == sumA)
                                        res+=1;
                                }
                            }
                        }
                    }
                }
            }
            return res;
        }

        int LuckyTikets6_3()
        {
            int res = 0;
            for (int a1 = 0; a1 <= 9; a1++)
            {
                for (int a2 = 0; a2 <= 9; a2++)
                {
                    for (int a3 = 0; a3 <= 9; a3++)
                    {
                        int sumA = a1 + a2 + a3;
                        for (int b1 = 0; b1 <= 9; b1++)
                        {
                            for (int b2 = 0; b2 <= 9; b2++)
                            {
                                int b3 = sumA - b1 - b2;
                                
                                if (b3 >=0 && b3<=9)
                                    res += 1;
                                
                            }
                        }
                    }
                }
            }
            return res;
        }

       

        
        long GetLuckyCount(int N, int sumA, int sumB)
        {
            if(N ==0)
            {
                return (sumA == sumB) ? 1 : 0;                   
            }

            long res = 0;
            for(int a=0; a<=9; a++)
                for(int b=0; b<=9; b++)
                {
                    res += GetLuckyCount(N-1, sumA+a, sumB+b);
                }
            return res;
        }

        long GetLuckyCount2(int N, int sumA, int sumB)
        {
            long res = 0;
            for (int a = 0; a <= 9; a++)
            {
                int nextSumA = sumA + a;
                for (int b = 0; b <= 9; b++)
                {
                    int nextSumB = sumB + b;
                  
                    if(N==1)
                    {
                        if (nextSumA == nextSumB)
                            res += 1;
                    }
                    else
                        res += GetLuckyCount2(N - 1, nextSumA, nextSumB);
                }
            }
                
            return res;
        }
    }
}
