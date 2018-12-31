using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.MissionControl
{
    public class NavigationCriterias
    {
        public string CurrentDirection { get; private set; }
        public string Command { get; }
        public Coordinate PlateauLimits { get; }
        public Coordinate CurrentCoordinates { get; private set; }

        public NavigationCriterias(string currentDirection, Coordinate plateauLimits, Coordinate currentCoordinates, string command)
        {
            CurrentDirection = currentDirection;
            PlateauLimits = plateauLimits;
            CurrentCoordinates = currentCoordinates;
            Command = command;
        }

        public void UpdateCurrentDirection(string newDirection)
        {
            CurrentDirection = newDirection;
        }

        internal void UpdateCurrentCoordinates(Coordinate newCoordinates)
        {
            CurrentCoordinates = newCoordinates;
        }
    }
}
