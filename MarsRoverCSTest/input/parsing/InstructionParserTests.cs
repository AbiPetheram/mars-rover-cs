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
    public class InstructionParserTests
    {
        [TestMethod()]
        public void TestNullInstructionThrowsArgumentException()
        {
            var parser = new InstructionParser();
            Assert.ThrowsException<ArgumentException>(
                () => parser.ParseInstructions(null));
        }

        [TestMethod()]
        public void TestEmptyStringInstructionThrowsArgumentException()
        {
            var parser = new InstructionParser();
            Assert.ThrowsException<ArgumentException>(
                () => parser.ParseInstructions(""));
        }

        [TestMethod()]
        public void TestNumericalInstructionThrowsArgumentException()
        {
            var parser = new InstructionParser();
            Assert.ThrowsException<ArgumentException>(
                () => parser.ParseInstructions("23"));
        }
    }
}