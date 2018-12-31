using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.MissionControl
{
    public class VehicleNavigator
    {
        private readonly NavigationCriterias navigationCriterias;
        private ControlPanel controlPanel;
        //private MovingControl movingControl;

        public VehicleNavigator(NavigationCriterias navigationCriterias)
        {
            this.navigationCriterias = navigationCriterias;
            controlPanel = new ControlPanel();
          
        }

        public string Navigate()
        {
            var command = navigationCriterias.Command;

            foreach (var step in command)
            {
                DoAStep(step);
            }

            var result = $"{navigationCriterias.CurrentCoordinates.X} {navigationCriterias.CurrentCoordinates.Y} {navigationCriterias.CurrentDirection}";

            return result;
        }

        private void DoAStep(char stepCommand)
        {
            var newDirection = controlPanel.GetNextDirection(navigationCriterias.CurrentDirection, stepCommand);

            navigationCriterias.UpdateCurrentDirection(newDirection);

            var newCoordinates = controlPanel.Move(stepCommand, navigationCriterias.CurrentDirection, navigationCriterias.CurrentCoordinates);

            if (newCoordinates.X > navigationCriterias.PlateauLimits.X || newCoordinates.Y > navigationCriterias.PlateauLimits.Y)
            {
                throw new Exception("Command is invalid");
            }

            navigationCriterias.UpdateCurrentCoordinates(newCoordinates);
        }
    }
}