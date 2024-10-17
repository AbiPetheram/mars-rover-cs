using Microsoft.VisualStudio.TestTools.UnitTesting;
using FirstProject.input.parsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.input.parsing.Tests
{
    [TestClass()]
    public class CoordinateParserTests
    {
        [TestMethod()]
        public void TestNullCoordinateThrowsIllegalArgumentException()
        {
            var parser = new CoordinateParser();
            Assert.ThrowsException<ArgumentException>(
                () => parser.ParseCoordinates(null));
        }
    }
}