﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverCS.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRoverCS.input;
using System.Runtime.CompilerServices;

namespace MarsRoverCS.logic.Tests
{
    [TestClass()]
    public class RoverTests
    {
        private Position Position;
        private Plateau Plateau;
        private Rover Rover;

        public void SetUpSafePositionNorth()
        {
            Position = new Position(new Coordinates(5, 5), CompassDirection.N);
            Plateau = new Plateau(new Coordinates(10, 10));
            Rover = new Rover(Position, Plateau);
        }

        [TestMethod()]
        public void TestMoveForwardWithSingleInstructionNorth()
        {
            SetUpSafePositionNorth();
            Rover.move(new Instruction[] { Instruction.M });
            Assert.AreEqual(new Position(new Coordinates(5, 6), CompassDirection.N), Rover.Position);
        }

        [TestMethod()]
        public void TestMoveForwardWithSingleInstructionEast()
        {
            SetUpSafePositionNorth();
            Rover.Position.Direction = CompassDirection.E;
            Rover.move(new Instruction[] { Instruction.M });
            Assert.AreEqual(new Position(new Coordinates(6, 5), CompassDirection.E), Rover.Position);
        }

        [TestMethod()]
        public void TestMoveForwardWithSingleInstructionSouth()
        {
            SetUpSafePositionNorth();
            Rover.Position.Direction = CompassDirection.S;
            Rover.move(new Instruction[] { Instruction.M });
            Assert.AreEqual(new Position(new Coordinates(5, 4), CompassDirection.S), Rover.Position);
        }

        [TestMethod()]
        public void TestMoveForwardWithSingleInstructionWest()
        {
            SetUpSafePositionNorth();
            Rover.Position.Direction = CompassDirection.W;
            Rover.move(new Instruction[] { Instruction.M });
            Assert.AreEqual(new Position(new Coordinates(4, 5), CompassDirection.W), Rover.Position);
        }
    }
}