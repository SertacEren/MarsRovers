using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.MissionControl
{
    public static class InputManager
    {
        private static Coordinate plateauLimits;
        private static Coordinate currentCoordinates;
        private static string currentDirection;
        private static string command;

        private static string[] inputByLines;

        private const int INPUT_LINES_COUNT = 3;
        private const int LINE_NUMBER_OF_PLATEAU_LIMITS = 0;
        private const int LINE_NUMBER_OF_START_POSITION = 1;
        private const int LINE_NUMBER_OF_COMMAND = 2;

        private const char PARAMETER_DELIMETER = ' ';

        private static readonly List<string> directions = new List<string> { "N", "W", "E", "S" };

        public static NavigationCriterias GetNavigationCriteriasFromInput(string input)
        {
            SplitInputByLines(input);
            SetPlateauLimits(inputByLines);
            SetStartPositionAndDirection(inputByLines);
            SetCommand();

            return new NavigationCriterias(currentDirection, plateauLimits, currentCoordinates, command);
        }

        private static void SplitInputByLines(string input)
        {
            var splitString = input.Split(Environment.NewLine.ToCharArray());

            if (splitString.Length != INPUT_LINES_COUNT)
            {
                throw new Exception("Input format is invalid.");
            }

            inputByLines = splitString;
        }

        private static void SetPlateauLimits(string[] inputLines)
        {
            var stringPlateauLimits = inputLines[LINE_NUMBER_OF_PLATEAU_LIMITS].Split(PARAMETER_DELIMETER);

            if (PlateauDimensionsAreInvalid(stringPlateauLimits))
            {
                throw new Exception("Plateau limits is invalid.");
            }

            plateauLimits = new Coordinate
            {
                X = Int32.Parse(stringPlateauLimits[0]),
                Y = Int32.Parse(stringPlateauLimits[1])
            };
        }

        private static void SetStartPositionAndDirection(string[] inputByLines)
        {
            var stringCurrentPositionAndDirection = inputByLines[LINE_NUMBER_OF_START_POSITION].Split(PARAMETER_DELIMETER);

            if (StartPositionIsInvalid(stringCurrentPositionAndDirection))
            {
                throw new Exception("Start Position is invalid.");
            }

            currentCoordinates = new Coordinate
            {
                X = Int32.Parse(stringCurrentPositionAndDirection[0]),
                Y = Int32.Parse(stringCurrentPositionAndDirection[1])
            };

            currentDirection = stringCurrentPositionAndDirection[2];
        }

        private static void SetCommand()
        {
            command = inputByLines[LINE_NUMBER_OF_COMMAND];
        }

        private static bool StartPositionIsInvalid(string[] stringCurrentPositionAndDirection)
        {
            if (stringCurrentPositionAndDirection.Length != 3
                || !stringCurrentPositionAndDirection[0].All(char.IsDigit)
                || !stringCurrentPositionAndDirection[1].All(char.IsDigit)
                || !directions.Any(stringCurrentPositionAndDirection[2].Contains))
            {
                return true;
            }

            if (Int32.Parse(stringCurrentPositionAndDirection[0]) > plateauLimits.X
                || Int32.Parse(stringCurrentPositionAndDirection[1]) > plateauLimits.Y)
            {
                return true;
            }

            return false;
        }

        private static bool PlateauDimensionsAreInvalid(string[] stringPlateauLimits)
        {
            if (stringPlateauLimits.Length != 2
                || !stringPlateauLimits[0].All(char.IsDigit)
                || !stringPlateauLimits[1].All(char.IsDigit))
            {
                return true;
            }

            return false;
        }
    }
}
