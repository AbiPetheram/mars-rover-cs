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
        public void TestNullCharDirectionThrowsIllegalArgumentException()
        {
            var parser = new DirectionParser();
            Assert.ThrowsException<ArgumentException>(
                () => parser.ParseDirection(null));
        }

        [TestMethod()]
        public void TestEmptyCharDirectionThrowsIllegalArgumentException()
        {
            var parser = new DirectionParser();
            Assert.ThrowsException<ArgumentException>(
                () => parser.ParseDirection(" "));
        }
    }
}