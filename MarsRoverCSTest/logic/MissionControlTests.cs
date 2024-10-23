using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRoverCS.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}