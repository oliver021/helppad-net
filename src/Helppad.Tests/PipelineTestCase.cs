using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Helppad.Tests
{
    class PipelineTestCase
    {
        [Test]
        public void Test()
        {
            var pipeline = PipelineBuilder.Create<int[]>(x => x[0] = 1)
                .Pipe(x => { x[1] = 2; })
                .Pipe(x => { x[2] = 5; })
                .Transform(x => string.Join(',', x))
                .Build();

            var elms = new int[3];
            Console.WriteLine(pipeline.Run(elms));
        }

        [Test]
        public void TestAsync()
        {
            Pipeline<int[], string> pipeline = GetPipelineForAsyncCases();

            var elms = new int[3];
            Console.WriteLine(pipeline.Run(elms));
        }

        [Test]
        public void TestAsync2()
        {
            Pipeline<int[], string> pipeline = GetPipelineForAsyncCases();

            var elms = new int[3];
            Assert.CatchAsync<InvalidOperationException>(async delegate {
                await pipeline.RunAsync(elms);
            });
        }

        private static Pipeline<int[], string> GetPipelineForAsyncCases()
        {
            return PipelineBuilder.Create<int[]>(x => x[0] = 1)
                            .Pipe(x => { x[1] = 2; })
                            .Pipe(async x =>
                            {
                                await Task.Delay(500);
                                x[2] = 5;
                            })
                            .Pipe(x => x[1] *= 3)
                            .Pipe(x => Task.FromResult(string.Join(',', x)))
                            .Build();
        }
    }
}
