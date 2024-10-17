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
        public void TestNullCharDirectionThrowsArgumentException()
        {
            var parser = new DirectionParser();
            Assert.ThrowsException<ArgumentException>(
                () => parser.ParseDirection(null));
        }

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
    }
}