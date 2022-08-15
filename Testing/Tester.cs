using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interfaces;

namespace Testing
{
    class Tester<T> //where T: IFormattable, IComparable
    {        
        private string _checkFilesPath;
        private int _maxDuration;
        private IWork<T> _work;
        private int _minTestNumber;
        private int _maxTestNumber;

        //private CancellationTokenSource _cts = new CancellationTokenSource();
        

        public Tester(IWork<T> work, string checkFilesPath, int minTestNumber = 0, int maxTestNumber = 0, int maxDuration = 0)
        {
            _work = work;
            _checkFilesPath = checkFilesPath;
            _maxDuration = maxDuration;
            _minTestNumber = minTestNumber;
            _maxTestNumber = maxTestNumber;

            if (_minTestNumber < 0 || _maxTestNumber < _minTestNumber)
                throw new Exception("invalid test number range.");

            if(maxDuration < 0)
                throw new Exception("invalid MaxDuration.");
        }

        public void Run()
        {
            Console.WriteLine($"\r\nMethod: {_work.Name}");
            for (int testNumber = _minTestNumber; _maxTestNumber > 0 ? testNumber <= _maxTestNumber : true; testNumber++)
            {
                string inFile = Path.Combine(_checkFilesPath, $"test.{testNumber}.in");
                string outFile = Path.Combine(_checkFilesPath, $"test.{testNumber}.out");

                if (!File.Exists(inFile) || !File.Exists(outFile))
                {
                    // если диапазон номеров тестов указан - пропускаем тест по отсутствующему файлу
                    if (_maxTestNumber > 0)
                    {
                        Console.WriteLine($"Test #{testNumber}: - skipped");
                        continue;
                    }
                    else // если диапазон номеров тестов НЕ определен , то отсутствие файлов - это признак завершения
                    {
                        break;
                    }
                }

                Console.Write($"Test #{testNumber}:   ");

                /////////////////////////////////////
                // Загрузка данных

                string[] data = File.ReadAllLines(inFile);
                string strExpect = File.ReadAllText(outFile).Trim();//.Replace('.',',');
                T expect;
                try
                {                
                    if (typeof(T).Equals(typeof(BigInteger)))                
                    {
                        long loadingDuration = 0;
                        BigInteger e = 0;                    

                        Cancelation loadingCancelation = new Cancelation();
                        if (_maxDuration > 0)
                        {
                            using (Timer t1 = new Timer(OnTimeout, loadingCancelation, _maxDuration, Timeout.Infinite))
                            {
                                e.Load(strExpect, loadingCancelation, ref loadingDuration);
                            }

                            if (loadingCancelation.Cancel == true)
                            {
                                Console.WriteLine($"BigInteger loading terminated by timeout, duration: {loadingDuration} ms");
                                continue;
                            }
                        }
                        else
                        {
                            e.Load(strExpect, loadingCancelation, ref loadingDuration);
                        }
                        expect = (T)(object)e;
                        Console.Write($"BigInteger loading duration: {loadingDuration} ms,  ");

                    }
                    else
                    {
                        TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
                        expect = (T)converter.ConvertFromString(null, CultureInfo.InvariantCulture, strExpect);
                        //expect = (T)Convert.ChangeType(strExpect, typeof(T));
                    }
                }
                catch (Exception exc)
                {
                    string errmsg = exc.InnerException == null ? exc.Message : exc.InnerException.Message;
                    Console.WriteLine($"Exception on loading data: {errmsg}");
                    continue;
                }

                /////////////////////////////////////
                // Вычисления
                long duration = 0;
                T actual;

                if(_Run(data, out actual,  ref duration) == true)
                    Console.WriteLine($"{actual.Equals(expect)},  duration: {duration} ms, result: {actual}");
            }
        }

        public void CustomRun(string[] inp, T expect)
        {
            Console.WriteLine($"\r\nMethod: {_work.Name}");
            Console.Write($"Custom test. input: ({string.Join(", ", inp)}),  ");

            long duration = 0;
            T actual;

            if (_Run(inp, out actual, ref duration) == true)
                Console.WriteLine($"{actual.Equals(expect)},  duration: {duration} ms, result: {actual}");

        }

        private bool _Run(string[] data, out T actual, ref long duration)
        {
            Cancelation cancelation = new Cancelation();
           
            if (_maxDuration > 0)
            {
                using (Timer t1 = new Timer(OnTimeout, cancelation, _maxDuration, Timeout.Infinite))
                {
                    actual = RunTest(data, cancelation, ref duration);
                }

                if (cancelation.Cancel == true)
                {
                    Console.WriteLine($"Terminated by timeout, duration: {duration} ms");
                    return false;
                }
            }
            else
            {
                actual = RunTest(data, cancelation, ref duration);
            }
            return true;
        }

        private void OnTimeout(object state)
        {
            Cancelation cancelation = state as Cancelation;
            cancelation.Cancel = true;
        }
       

        private T RunTest(string[] data, Cancelation cancelation,  ref long duration)
        {
            T res = default(T);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
            {
                res = _work.Run(data, cancelation);
            }
            catch(Exception exc)
            {
                string errmsg = exc.InnerException == null ? exc.Message : exc.InnerException.Message;
                Console.WriteLine($"Exception:  {errmsg}");
            }
          
            sw.Stop();
            duration = sw.ElapsedMilliseconds;

            return res;
        }
       
        
    }
}
