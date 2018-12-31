using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.MissionControl
{
    public class Vehicle
    {
        private readonly string input;
        private VehicleNavigator vehicleNavigator;

        public Vehicle(string input)
        {
            this.input = input;
            NavigationCriterias = InputManager.GetNavigationCriteriasFromInput(input);
        }

        public NavigationCriterias NavigationCriterias { get; private set; }
        public string FinalPosition { get; private set; }


        public void Navigate()
        {
            vehicleNavigator = new VehicleNavigator(NavigationCriterias);
            FinalPosition = vehicleNavigator.Navigate();
        }
    }
}

