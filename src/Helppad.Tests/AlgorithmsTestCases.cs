using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Helppad.Tests
{
    public class AlgorithmsTestCases
    {
        [Test]
        public void CountChars()
        {
            // Arrange
            string str = "Hello World";
            char c = 'o';

            // Act
            int count = Algorithms.String.Count(str, c);

            // Assert
            Assert.AreEqual(2, count);

            // Arrange
            str = "Hello World";
            c = 'l';

            // Act
            count = Algorithms.String.Count(str, c);

            // Assert
            Assert.AreEqual(3, count);

            // Arrange
            str = "Hello World";
            c = 'z';

            // Act
            count = Algorithms.String.Count(str, c);

            // Assert
            Assert.AreEqual(0, count);
        }

        [Test]
        public void CountSubstrings()
        {
            // Arrange
            string str = "Hello World";
            string substr = "llo";
            
            // Act
            int count = Algorithms.String.Count(str, substr);

            // Assert
            Assert.AreEqual(2, count);

            // Arrange
            str = "Hello World";
            substr = "llo";

            // Act
            count = Algorithms.String.Count(str, substr);

            // Assert
            Assert.AreEqual(2, count);
        }

        [Test]
        public void GetAdjacentWords()
        {
            // Arrange
            string str = "Hello guys, how are you? I am fine, thank you. These things are great, true?";
            string word = "are";

            // Act
            string[] occurs = Algorithms.String.GetAdjacentWords(str, word);

            // Assert: array should have four elements
            Assert.AreEqual(4, occurs.Length);
        }
    }
}