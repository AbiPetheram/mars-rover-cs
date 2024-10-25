using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private MissionControl MissionControl;

        public void SetUpSafePositionNorth()
        {
            Position = new Position(new Coordinates(5, 5), CompassDirection.N);
            Plateau = new Plateau(new Coordinates(10, 10));
            MissionControl = new MissionControl();
            Rover = MissionControl.CreateRover(Position, Plateau);
        }

        public Boolean IsSamePosition(Position position)
        {
            if(Rover.Position.Coordinates.x == position.Coordinates.x && 
                Rover.Position.Coordinates.y == position.Coordinates.y)
            {
                return true;
            }
            return false;
        }

        [TestMethod()]
        public void TestMoveForwardWithSingleInstructionNorth()
        {
            SetUpSafePositionNorth();
            Rover.move(new Instruction[] { Instruction.M });
            Assert.IsTrue(IsSamePosition(new Position(new Coordinates(5, 6), CompassDirection.N)));
        }

        [TestMethod()]
        public void TestMoveForwardWithSingleInstructionEast()
        {
            SetUpSafePositionNorth();
            Rover.Position.Direction = CompassDirection.E;
            Rover.move(new Instruction[] { Instruction.M });
            Assert.IsTrue(IsSamePosition(new Position(new Coordinates(6, 5), CompassDirection.E)));
        }

        [TestMethod()]
        public void TestMoveForwardWithSingleInstructionSouth()
        {
            SetUpSafePositionNorth();
            Rover.Position.Direction = CompassDirection.S;
            Rover.move(new Instruction[] { Instruction.M });
            Assert.IsTrue(IsSamePosition(new Position(new Coordinates(5, 4), CompassDirection.S)));
        }

        [TestMethod()]
        public void TestMoveForwardWithSingleInstructionWest()
        {
            SetUpSafePositionNorth();
            Rover.Position.Direction = CompassDirection.W;
            Rover.move(new Instruction[] { Instruction.M });
            Assert.IsTrue(IsSamePosition(new Position(new Coordinates(4, 5), CompassDirection.W)));
        }

        [DataRow(CompassDirection.N, Instruction.M, 5, 8)]
        [DataRow(CompassDirection.E, Instruction.M, 8, 5)]
        [DataRow(CompassDirection.S, Instruction.M, 5, 2)]
        [DataRow(CompassDirection.W, Instruction.M, 2, 5)]
        [DataTestMethod]
        public void TestMoveForwardThreeSpaces(CompassDirection Direction, Instruction Move, int x, int y)
        {
            SetUpSafePositionNorth();
            Rover.Position.Direction = Direction;
            Rover.move(new Instruction[] { Move, Move, Move });
            var expected = new Position(new Coordinates(x, y), Direction);
            Assert.IsTrue(IsSamePosition(expected));
        }

        [DataRow(CompassDirection.N, CompassDirection.E, Instruction.R)]
        [DataRow(CompassDirection.E, CompassDirection.S, Instruction.R)]
        [DataRow(CompassDirection.S, CompassDirection.W, Instruction.R)]
        [DataRow(CompassDirection.W, CompassDirection.N, Instruction.R)]
        [DataTestMethod]
        public void TestRotateRightOnceAllDirections(CompassDirection Initial, CompassDirection Resulting, Instruction Right)
        {
            SetUpSafePositionNorth();
            Rover.Position.Direction = Initial;
            Rover.move(new Instruction[] { Right });
            Assert.AreEqual(Resulting, Rover.Position.Direction);
        }

        [DataRow(CompassDirection.N, CompassDirection.W, Instruction.L)]
        [DataRow(CompassDirection.E, CompassDirection.N, Instruction.L)]
        [DataRow(CompassDirection.S, CompassDirection.E, Instruction.L)]
        [DataRow(CompassDirection.W, CompassDirection.S, Instruction.L)]
        [DataTestMethod]
        public void TestRotateLeftOnceAllDirections(CompassDirection Initial, CompassDirection Resulting, Instruction Left)
        {
            SetUpSafePositionNorth();
            Rover.Position.Direction = Initial;
            Rover.move(new Instruction[] { Left });
            Assert.AreEqual(Resulting, Rover.Position.Direction);
        }

        [DataRow(CompassDirection.N, CompassDirection.W, Instruction.R, Instruction.R, Instruction.R)]
        [DataRow(CompassDirection.E, CompassDirection.S, Instruction.R, Instruction.L, Instruction.R)]
        [DataRow(CompassDirection.S, CompassDirection.E, Instruction.R, Instruction.L, Instruction.L)]
        [DataRow(CompassDirection.N, CompassDirection.E, Instruction.L, Instruction.L, Instruction.L)]
        [DataRow(CompassDirection.W, CompassDirection.S, Instruction.L, Instruction.R, Instruction.L)]
        [DataRow(CompassDirection.S, CompassDirection.W, Instruction.L, Instruction.R, Instruction.R)]
        [DataTestMethod]
        public void TestRotateMultipleInstructions(CompassDirection Initial, CompassDirection Resulting, 
            Instruction Instruciton1, Instruction Instruciton2, Instruction Instruciton3)
        {
            SetUpSafePositionNorth();
            Rover.Position.Direction = Initial;
            Rover.move(new Instruction[] { Instruciton1, Instruciton2, Instruciton3 });
            Assert.AreEqual(Resulting, Rover.Position.Direction);
        }

        [DataRow(CompassDirection.N, CompassDirection.S, 6, 4, Instruction.R, Instruction.M, Instruction.R, Instruction.M)]
        [DataRow(CompassDirection.E, CompassDirection.W, 3, 5, Instruction.L, Instruction.L, Instruction.M, Instruction.M)]
        [DataRow(CompassDirection.S, CompassDirection.W, 3, 4, Instruction.M, Instruction.R, Instruction.M, Instruction.M)]
        [DataRow(CompassDirection.N, CompassDirection.E, 6, 5, Instruction.L, Instruction.L, Instruction.L, Instruction.M)]
        [DataRow(CompassDirection.W, CompassDirection.E, 6, 4, Instruction.L, Instruction.M, Instruction.L, Instruction.M)]
        [DataTestMethod]
        public void TestMixedInstructions(CompassDirection Initial, CompassDirection Resulting, int x, int y,
            Instruction Instruciton1, Instruction Instruciton2, Instruction Instruciton3, Instruction Instruction4)
        {
            SetUpSafePositionNorth();
            Rover.Position.Direction = Initial;
            Rover.move(new Instruction[] { Instruciton1, Instruciton2, Instruciton3, Instruction4 });
            Assert.AreEqual(Resulting, Rover.Position.Direction);
            Assert.AreEqual(x, Rover.Position.Coordinates.x);
            Assert.AreEqual(y, Rover.Position.Coordinates.y);
        }
    }
}