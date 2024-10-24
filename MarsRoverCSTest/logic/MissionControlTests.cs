using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverCS.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRoverCS.input;

namespace MarsRoverCS.logic.Tests
{
    [TestClass()]
    public class MissionControlTests
    {

        [TestMethod()]
        public void CreatePlateauTestNullInput()
        {
            var MissionControl = new MissionControl();
            Assert.ThrowsException<ArgumentNullException>(() => MissionControl.CreatePlateau(null));
        }

        [TestMethod()]
        public void CreatePlateauWithValidInput()
        {
            var MissionControl = new MissionControl();
            var plateau = MissionControl.CreatePlateau(new Coordinates(2, 3));
            Assert.AreEqual(2, plateau.Size.x);
            Assert.AreEqual(3, plateau.Size.y);
        }

        [TestMethod()]
        public void CreateRoverTestNullInput()
        {
            var MissionControl = new MissionControl();
            Assert.ThrowsException<ArgumentNullException>(() => MissionControl.CreateRover(null, null));
        }

        [TestMethod()]
        public void CreateRoverWithValidInput()
        {
            var missionControl = new MissionControl();
            var plateau = missionControl.CreatePlateau(new Coordinates(2, 3));
            var position = new Position(new Coordinates(1, 1), CompassDirection.N);
            var rover = missionControl.CreateRover(position, plateau);
            Assert.AreEqual(2, rover.Plateau.Size.x);
            Assert.AreEqual(3, rover.Plateau.Size.y);
            Assert.AreEqual(1, rover.Position.Coordinates.x);
            Assert.AreEqual(1, rover.Position.Coordinates.y);
        }

        [TestMethod()]
        public void TestIsPositionInPlateauWhenCoordinatesMaxSize()
        {
            var missionControl = new MissionControl();
            var plateau = missionControl.CreatePlateau(new Coordinates(2, 3));
            Boolean result = missionControl.IsPositionInPlateau(new Coordinates(2, 3), plateau);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void TestIsPositionInPlateauWhenCoordiates00()
        {
            var missionControl = new MissionControl();
            var plateau = missionControl.CreatePlateau(new Coordinates(2, 3));
            Boolean result = missionControl.IsPositionInPlateau(new Coordinates(0, 0), plateau);
            Assert.IsTrue(result);

        }

        [TestMethod()]
        public void TestReturnsFalseWhenXCoordinateBiggerThanPlateau()
        {
            var missionControl = new MissionControl();
            var plateau = missionControl.CreatePlateau(new Coordinates(2, 3));
            Boolean result = missionControl.IsPositionInPlateau(new Coordinates(3, 1), plateau);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void TestReturnsFalseWhenYCoordinateBiggerThanPlateau()
        {
            var missionControl = new MissionControl();
            var plateau = missionControl.CreatePlateau(new Coordinates(2, 3));
            Boolean result = missionControl.IsPositionInPlateau(new Coordinates(1, 4), plateau);
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void TestIsPositionInPlateauWithNegativeCoordinates()
        {
            var missionControl = new MissionControl();
            var plateau = missionControl.CreatePlateau(new Coordinates(5, 5));
            Boolean result = missionControl.IsPositionInPlateau(new Coordinates(-1, 4), plateau);
            Boolean result2 = missionControl.IsPositionInPlateau(new Coordinates(1, -4), plateau);
            Assert.IsFalse(result);
            Assert.IsFalse(result2);
        }

        [TestMethod()]
        public void TestIsPositionEmpty()
        {
            var missionControl = new MissionControl();
            var plateau = missionControl.CreatePlateau(new Coordinates(5, 5));
            var rover = missionControl.CreateRover(new Position(new Coordinates(2,2), CompassDirection.N), plateau);
            var rover2 = missionControl.CreateRover(new Position(new Coordinates(2, 1), CompassDirection.N), plateau);
            Boolean result = missionControl.IsPositionEmpty(new Coordinates(2, 2), plateau);
            Boolean result2 = missionControl.IsPositionEmpty(new Coordinates(2, 1), plateau);
            Boolean result3 = missionControl.IsPositionEmpty(new Coordinates(1, 1), plateau);
            Assert.IsFalse(result);
            Assert.IsFalse(result2);
            Assert.IsTrue(result3);
        }
    }
}