using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Grid
    {
        public string[,] Area = new string[8, 8];
        public int[] RoverPosition { get; set; } = new int[2];
    }

    public class Rover
    {
        public int[] Position { get; set; } = new int[2];

        public string Direction { get; private set; } = "N";

        private readonly Grid _grid;

        public Rover(Grid grid)
        {
            _grid = grid;
        }
        
        public void Move(string command)
        {
            if (command == "F")
                MoveForward(command);

            if (command == "B")
                MoveBackward(command);

            if (command == "L")
                RotateLeft("L");
        }

        private void RotateLeft(string command)
        {
            Direction dir;
            
            Direction = "W";
        }
        
        private void MoveBackward(string command)
        {
            Position[1]++;

            var x = Position[0];
            var y = Position[1];

            _grid.Area[x, y] = "R";
        }

        private void MoveForward(string command)
        {
            Position[1]--;

            var x = Position[0];
            var y = Position[1];

            _grid.Area[x, y] = "R";
        }

        public void SetRoverPosition(int x, int y)
        {
            _grid.Area[x, y] = "R";
            Position[0] = x;
            Position[1] = y; 
        }

        public void SetRoverDirection(string direction)
        {
            Direction = direction;
        }
    }

    public class Direction
    {
        public string Current { get; set; }
        public string RightPosition { get; set; }
        public string LeftPosition { get; set; }
        
        public Direction(string current, string rightPosition, string leftPosition)
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

    public class Rotator
    {
        public string Rotate(string rotation, string currentDirection)
        {
            var intendedDirection = Direction.GetDirection(currentDirection);
            return DetermineNewDirection(rotation, intendedDirection);
        }

        private string DetermineNewDirection(string rotation, Direction intendedDirection)
        {
            return rotation == "L" ? intendedDirection.LeftPosition : intendedDirection.RightPosition; 
        }
    }
}