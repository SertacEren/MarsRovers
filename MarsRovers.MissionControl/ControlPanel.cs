using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRovers.MissionControl
{
   public class ControlPanel
    {
        #region Move
        public Dictionary<string, Func<Coordinate, Coordinate>> MoveFunctions =
                           new Dictionary<string, Func<Coordinate, Coordinate>>
   {
        {"N", MoveNorth},
        {"W", MoveWest},
        {"S", MoveSouth},
        {"E", MoveEast}
   };

        public Coordinate Move(char command, string currentDirection, Coordinate currentCoordinate)
        {
            if (command == 'M')
            {
                return MoveFunctions[currentDirection](currentCoordinate);
            }

            return currentCoordinate;
        }

        private static Coordinate MoveEast(Coordinate Coordinate)
        {
            return new Coordinate()
            {
                X = Coordinate.X + 1,
                Y = Coordinate.Y
            };
        }

        private static Coordinate MoveSouth(Coordinate Coordinate)
        {
            return new Coordinate()
            {
                X = Coordinate.X,
                Y = Coordinate.Y - 1
            };
        }

        private static Coordinate MoveWest(Coordinate Coordinate)
        {
            return new Coordinate()
            {
                X = Coordinate.X - 1,
                Y = Coordinate.Y
            };
        }

        private static Coordinate MoveNorth(Coordinate Coordinate)
        {
            return new Coordinate()
            {
                X = Coordinate.X,
                Y = Coordinate.Y + 1
            };
        }
        #endregion

        #region Spin
        static readonly LinkedList<string> directions =
                   new LinkedList<string>(new[] { "N", "W", "S", "E" });

        public readonly Dictionary<char, Func<string, string>> SpinningFunctions =
                                new Dictionary<char, Func<string, string>>
        {
        {'L', TurnLeft},
        {'R', TurnRight},
        {'M', Stay }
        };

        public string GetNextDirection(string currentDirection, char stepCommand)
        {
            return SpinningFunctions[stepCommand](currentDirection);
        }

        private static string TurnRight(string currentDirection)
        {
            LinkedListNode<string> currentIndex = directions.Find(currentDirection);
            return currentIndex.PreviousOrLast().Value;
        }

        private static string TurnLeft(string currentDirection)
        {
            LinkedListNode<string> currentIndex = directions.Find(currentDirection);
            return currentIndex.NextOrFirst().Value;
        }

        private static string Stay(string currentDirection)
        {
            return currentDirection;
        }
        #endregion
    }
}
