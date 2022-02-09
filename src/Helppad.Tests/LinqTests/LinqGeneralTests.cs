using NUnit.Framework;
using System;
using System.Linq;

namespace Helppad.Tests.LinqTests
{
    class LinqGeneralTests
    {
        [Test]
        public void LinqTakeLast()
        {
            var elms1 = new[] { 3, 22, 55, 1, 21 };
            var elms2 = new[] {55, 1, 21 };

            Assert.AreEqual(elms1.TakeLast(3), elms2);
        }

        [Test]
        public void LinqAgreggateFor()
        {
            var elms1 = new[] { 3, 3, 3, 3 };

            Assert.AreEqual(elms1.AgreggateFor((pull, initial) => {
                while (true)
                {
                    var iteration = pull.Invoke();

                    if (iteration.Has is false)
                    {
                        break;
                    }

                    initial += iteration.Current;
                }

                return initial;
            },0), 12);

            Assert.AreEqual(elms1.Take(3).AgreggateFor((pull, initial) => {
                while (true)
                {
                    var iteration = pull.Invoke();

                    if (iteration.Has is false)
                    {
                        break;
                    }

                    initial *= iteration.Current;
                }

                return initial;
            }, 1), 27);
        }
    }
}
