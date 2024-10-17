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

        [TestMethod()]
        public void TestInvalidAlphabeticalInstructionThrowsArgumentException()
        {
            var parser = new InstructionParser();
            Assert.ThrowsException<ArgumentException>(
                () => parser.ParseInstructions("MLMRLP"));
        }

        [TestMethod()]
        public void TestReturnsArrayWithL()
        {
            var parser = new InstructionParser();
            Instruction[] result = parser.ParseInstructions("L");
            CollectionAssert.AreEqual(new Instruction[] { Instruction.L }, result);
        }

        [TestMethod()]
        public void TestReturnsArrayWith5Ls()
        {
            var parser = new InstructionParser();
            Instruction[] result = parser.ParseInstructions("LLLLL");
            CollectionAssert.AreEqual(
                new Instruction[] {Instruction.L, Instruction.L, Instruction.L, Instruction.L, Instruction.L }, result);
        }

        [TestMethod()]
        public void TestReturnsArrayWithMixedValidInput()
        {
            var parser = new InstructionParser();
            CollectionAssert.AreEqual(
                new Instruction[] { Instruction.L, Instruction.R, Instruction.M }, 
                parser.ParseInstructions("LRM"));
            CollectionAssert.AreEqual(
                new Instruction[] { Instruction.R, Instruction.R, Instruction.R, Instruction.M },
                parser.ParseInstructions("RRRM"));
            CollectionAssert.AreEqual(
                new Instruction[] { Instruction.M, Instruction.R, Instruction.L, Instruction.M },
                parser.ParseInstructions("MRLM"));
        }
    }
}