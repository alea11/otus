using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Interfaces;

namespace Testing
{
    class Tester<T>
    {        
        private string _checkFilesPath;
        private int _maxDuration;
        private IWork<T> _work;
        private int _minTestNumber;
        private int _maxTestNumber;

        private CancellationTokenSource _cts = new CancellationTokenSource();
        

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
                Cancelation cancelation = new Cancelation();

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

                    
                string[] data = File.ReadAllLines(inFile);
                string strExpect = File.ReadAllText(outFile).Trim().Replace('.',',');
                T expect = (T)Convert.ChangeType(strExpect, typeof(T));
                long duration = 0;

                T actual;                

                if (_maxDuration > 0)
                {
                    using(Timer t1 = new Timer(OnTimeout, cancelation, _maxDuration, Timeout.Infinite))
                    {
                        actual = RunTest(data, cancelation, ref duration);
                    }
                    
                    if (cancelation.Cancel == true)
                    {                        
                        Console.WriteLine($"Test #{testNumber}:  Terminated by timeout, duration: {duration} ms");
                        continue;
                    }
                }
                else
                {
                    actual = RunTest(data, cancelation, ref duration);
                }                

                Console.WriteLine($"Test #{testNumber}:  {actual.Equals(expect)}, result: {actual},  duration: {duration} ms");
            }
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
