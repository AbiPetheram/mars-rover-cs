using Microsoft.VisualStudio.TestTools.UnitTesting;
using FirstProject.input.parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}