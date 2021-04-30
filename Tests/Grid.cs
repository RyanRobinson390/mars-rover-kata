using System.Reflection;

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
    }
}