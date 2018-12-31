using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRovers.MissionControl;

//In this project, the following link reference was taken to understand the tdd logic.
//https://codereview.stackexchange.com/questions/191991/mars-rover-kata-using-tdd-and-solid
namespace MarsRovers.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var vehicle = new Vehicle("5 5\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM");
            vehicle.Navigate();

            var result = vehicle.FinalPosition;
        }
    }
}
