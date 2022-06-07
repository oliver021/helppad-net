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

        [Test]
        public void TestCamelCase()
        {
            string[] test = String.SplitCamelCase("thisIsBob");
            if (test is null)
            {
                Assert.Fail();
            }

            Console.WriteLine(string.Join(" ", test));
            Assert.AreEqual(3, test.Length);
            Assert.AreEqual("this", test[0]);
            Assert.AreEqual("is", test[1]);
            Assert.AreEqual("Bob", test[2]);
        }

        [Test]
        public void TestJoinCamelCase()
        {
            string test = String.JoinCamelCase(new string[] { "this", "is", "Bob" });
            if (test is null)
            {
                Assert.Fail();
            }
            Assert.AreEqual("thisIsBob", test);            
        }

        [Test]
        public void TestParseDashCaseToCamelCase()
        {
            string test = String.ParseDashCaseToCamelCase("this-is-Bob");
            if (test is null)
            {
                Assert.Fail();
            }

            Assert.AreEqual("thisIsBob", test);
        }
    }
}
