using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRoverCS.input;
using MarsRoverCS.input.parsing;

namespace MarsRoverCSTest.input.parsing.Tests
{
    [TestClass()]
    public class CoordinateParserTests
    {
        [TestMethod()]
        public void TestNullCoordinateThrowsArgumentException()
        {
            var parser = new CoordinateParser();
            Assert.ThrowsException<ArgumentException>(
                () => parser.ParseCoordinates(null));
        }

        [TestMethod()]
        public void TestArrayOfOneCoordinateThrowsArgumentException()
        {
            var parser = new CoordinateParser();
            Assert.ThrowsException<ArgumentException>(
                () => parser.ParseCoordinates(new string[] {"1"}));
        }


        [TestMethod()]
        public void TestAlphabeticalCharacterThrowsArgumentException()
        {
            var parser = new CoordinateParser();
            Assert.ThrowsException<ArgumentException>(
                () => parser.ParseCoordinates(new string[] { "1", "A" }));
        }

        [TestMethod()]
        public void TestThreeNumbersInputThrowsArgumentException()
        {
            var parser = new CoordinateParser();
            Assert.ThrowsException<ArgumentException>(
                () => parser.ParseCoordinates(new string[] { "1", "2", "2" }));
        }

        [TestMethod()]
        public void TestCoordinatesReturnedWhenTwoNumbersInput()
        {
            var parser = new CoordinateParser();
            var result = parser.ParseCoordinates(new string[] { "1", "2" });
            Assert.AreEqual(new Coordinates(1, 2), result);
        }

        [TestMethod()]
        public void TestCoordinatesReturnedWhenTwoDoubleDigitNumbersInput()
        {
            var parser = new CoordinateParser();
            var result = parser.ParseCoordinates(new string[] { "12", "26" });
            Assert.AreEqual(new Coordinates(12, 26), result);
        }

    }
}