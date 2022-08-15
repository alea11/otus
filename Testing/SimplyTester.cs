using Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Testing
{
    class SimplyTester
    {
        private int _maxDuration;
        private IWork _work;        

        public SimplyTester(IWork work, int maxDuration = 0)
        {
            _work = work;            
            _maxDuration = maxDuration;
           
            if (maxDuration < 0)
                throw new Exception("invalid MaxDuration.");
        }

        public void CustomRun(string[] inp)
        {
            Console.WriteLine($"\r\nMethod: {_work.Name}");
            Console.Write($"Custom test. input: ({string.Join(", ", inp)}),  ");

            long duration = 0;
          
            if (_Run( inp , ref duration) == true)
                Console.WriteLine($"duration: {duration} ms");
        }

        private bool _Run(string[] data, ref long duration)
        {
            Cancelation cancelation = new Cancelation();

            if (_maxDuration > 0)
            {
                using (Timer t1 = new Timer(OnTimeout, cancelation, _maxDuration, Timeout.Infinite))
                {
                    RunTest(data, cancelation, ref duration);
                }

                if (cancelation.Cancel == true)
                {
                    Console.WriteLine($"Terminated by timeout, duration: {duration} ms");
                    return false;
                }
            }
            else
            {
                RunTest(data, cancelation, ref duration);
            }
            return true;
        }

        private void OnTimeout(object state)
        {
            Cancelation cancelation = state as Cancelation;
            cancelation.Cancel = true;
        }


        private void RunTest(string[] data, Cancelation cancelation, ref long duration)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
            {
                _work.Run(data, cancelation);
            }
            catch (Exception exc)
            {
                string errmsg = exc.InnerException == null ? exc.Message : exc.InnerException.Message;
                Console.WriteLine($"Exception:  {errmsg}");
            }

            sw.Stop();
            duration = sw.ElapsedMilliseconds;            
        }

    }
}
