using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Helppad.Tests
{
    public class FunctionalTestCase
    {
        [Test]
        public void OnceTest()
        {
            // Arrange
            // declare a callable function
            Func<int, int> add = (x) => x + 1;

            // Act
            // call the function with Helppad.Once
            var result = Functional.Once(add);

            // Assert
            // the result should be Func<int, int>
            Assert.AreEqual(typeof(Func<int, int>), result.GetType());

            // the result should be 2
            Assert.AreEqual(2, result(1));

            // now testing the crash exception
            // Arrange
            // declare a callable function passing a true in the second parameter
            result = Functional.Once(add, true);

            // Act
            // call and exception should be thrown
            Assert.Throws<AlreadyCalledException>(() => result(1));
        }
    }
}