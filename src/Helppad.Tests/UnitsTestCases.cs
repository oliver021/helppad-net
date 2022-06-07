using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Helppad.Algorithms;

namespace Helppad.Tests
{
    class UnitsTestCases
    {
        [Test]
        public void TestLengthUnits()
        {
            // LengthUnits
            Assert.AreEqual(1, (int)LengthUnits.Meter);

            /* miles to km */
            // Arange
            var miles = 2.1;

            // Act
            // convert miles to km
            var km = UnitsConveter.ConvertLength(miles, LengthUnits.Mile, LengthUnits.Kilometer);

            // Assert
            // assert conversion result
            Assert.AreEqual(3.3, km);

            /* centimeter to feet */
            // Arange
            var centimeter = 2.1;
            
            // Act
            // convert centimeter to feet
            var feet = UnitsConveter.ConvertLength(centimeter, LengthUnits.Centimeter, LengthUnits.Foot);

            // Assert
            // assert conversion result
            Assert.AreEqual(0.06, feet);
        }
    }
}