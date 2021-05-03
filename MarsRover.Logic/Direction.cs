using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Logic
{
    public class Direction
    {
        public string Current { get; set; }
        public string RightPosition { get; set; }
        public string LeftPosition { get; set; }

        private Direction(string current, string rightPosition, string leftPosition)
        {
            Current = current;
            RightPosition = rightPosition;
            LeftPosition = leftPosition;
        }

        public static Direction GetDirection(string currentPosition)
        {
            return GetDirections().Single(x => x.Current == currentPosition);
        }
        
        private static List<Direction> GetDirections()
        {
            var directions = new List<Direction>();
            
            directions.Add(new Direction("N", "E", "W"));
            directions.Add(new Direction("E", "S", "N"));
            directions.Add(new Direction("S", "W", "E"));
            directions.Add(new Direction("W", "N", "S"));

            return directions; 
        }
    }
}