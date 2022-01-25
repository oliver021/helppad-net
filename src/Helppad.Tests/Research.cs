using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Helppad.Tests
{
    class Research
    {
        private const int MillisecondsDelay = 2200;

        [Test]
        public void TestSimpleCancel()
        {
            // manual cancellation
            var src = new CancellationTokenSource(MillisecondsDelay);
            var bm = new Stopwatch();
            bm.Start();
            while (!src.IsCancellationRequested)
            {}
            bm.Stop();
            Console.WriteLine("exit 1 {0}", bm.ElapsedMilliseconds);

            // for func
            var cancellation = Paralleling.WithGraceful(MillisecondsDelay);
            var bm2 = new Stopwatch();
            bm2.Start();
            while (!cancellation.IsCancellationRequested)
            { }
            bm2.Stop();
            Console.WriteLine("exit 2 {0}", bm2.ElapsedMilliseconds);
        }

        [Test]
        public void TestComplete()
        {
            Task.CompletedTask.ContinueWith(delegate {
                Console.WriteLine("The first...");
            });

            var delay = Task.Delay(1000);
            
            delay.GetAwaiter().OnCompleted(delegate {
                Console.WriteLine("The second...");
            });

            delay.Wait();
        }
    }
}
