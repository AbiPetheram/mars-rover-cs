using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverCS.input.parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverCS.input.parsing.Tests
{
    [TestClass()]
    public class DirectionParserTests
    {

        [TestMethod()]
        public void TestEmptyCharDirectionThrowsArgumentException()
        {
            var parser = new DirectionParser();
            Assert.ThrowsException<ArgumentException>(
                () => parser.ParseDirection(" "));
        }

        [TestMethod()]
        public void TestNumberDirectionThrowsArgumentException()
        {
            var parser = new DirectionParser();
            Assert.ThrowsException<ArgumentException>(
                () => parser.ParseDirection("1"));
        }

        [TestMethod()]
        public void TestSpecialCharacterThrowsArgumentException()
        {
            var parser = new DirectionParser();
            Assert.ThrowsException<ArgumentException>(
                () => parser.ParseDirection("%"));
        }

        [TestMethod()]
        public void TestNorthDirection()
        {
            var parser = new DirectionParser();
            var result = parser.ParseDirection("N");
            Assert.AreEqual(CompassDirection.N, result);
        }

        [TestMethod()]
        public void TestEastDirection()
        {
            var parser = new DirectionParser();
            var result = parser.ParseDirection("E");
            Assert.AreEqual(CompassDirection.E, result);
        }

        [TestMethod()]
        public void TestSouthDirection()
        {
            var parser = new DirectionParser();
            var result = parser.ParseDirection("S");
            Assert.AreEqual(CompassDirection.S, result);
        }


        [TestMethod()]
        public void TestWestDirection()
        {
            var parser = new DirectionParser();
            var result = parser.ParseDirection("W");
            Assert.AreEqual(CompassDirection.W, result);
        }

        [TestMethod()]
        public void TestLowerCaseValidDirection()
        {
            var parser = new DirectionParser();
   
            Assert.AreEqual(CompassDirection.W, parser.ParseDirection("w"));
            Assert.AreEqual(CompassDirection.E, parser.ParseDirection("e"));
            Assert.AreEqual(CompassDirection.N, parser.ParseDirection("n"));
            Assert.AreEqual(CompassDirection.S, parser.ParseDirection("s"));
        }

    }
}