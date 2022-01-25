using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helppad.Tests
{
    class TestString
    {
        [Test]
        public void TestRandomString1()
        {
            string test = SimpleToolkit.RandomString(8);
            if (test is null)
            {
                Assert.Fail();
            }
            Console.WriteLine(test);
            Assert.AreEqual(8, test.Length);
        }

        [Test]
        public void TestRandomString2()
        {
            string test = SimpleToolkit.RandomString(18, SimpleToolkit.HexChars);
            if (test is null)
            {
                Assert.Fail();
            }
            Console.WriteLine(test);
            Assert.AreEqual(18, test.Length);
        }
    }
}
