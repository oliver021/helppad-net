using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Helppad.Tests.LinqTests
{
    class LinqEquals
    {
        [Test]
        public void TestLinqContainsSequence()
        {
            var elms1 = new[] { 11, 22, 12, 6, 7, 887, 55, 43, 21 };
            var elms2 = new[] { 12, 6, 7, 887 };

            Assert.AreEqual(2, elms1.ContainsSequence(elms2));
        }

        [Test]
        public void TestLinqStartWith()
        {
            var elms1 = new[] { 11, 22, 12, 6, 7, 887, 55, 43, 21 };
            var elms2 = new[] { 12, 6, 7, 887 };

            Assert.AreEqual(2, elms1.ContainsSequence(elms2));
        }

        [Test]
        public void TestLinqEndsWith()
        {
            var elms1 = new[] { 3, 22, 12, 6, 72, 55, 43, 21 };
            var elms2 = new[] { 55, 43, 21 };

            Assert.IsTrue(elms1.EndsWith(elms2));
        }
    }
}
