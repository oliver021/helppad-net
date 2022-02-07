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
    }
}
