using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Helppad.Tests
{
    class ListenerProcessTestCase
    {
        [Test]
        public void TestListenerProcess()
        {
            int target = 0;
            int[] set = SimpleToolkit.FillArray(new[] { 11, 3, 7, 55, 55 }, 40);
            
            // create listener
            var listener = Paralleling.CreateProcess<int>((x, cts) => {
                cts.ThrowIfCancellationRequested();
                Interlocked.Add(ref target, x);
            });
            
            // post all number from set
            Parallel.ForEach(set, num =>
            {
                listener.Post(num);
            });

            // wait
            listener.WhenFreeAsync().Wait();

            // test
            Assert.AreEqual(target, set.Sum());
        }
    }
}
