namespace MarsRover.Logic
{
    public class Rover
    {
        public int[] Position { get; set; } = new int[2];

        public string CurrentDirection { get; private set; }

        private readonly Grid _grid;

        private Rotator _rotator = new Rotator();

        public Rover(Grid grid)
        {
            _grid = grid;
        }

        public void ExecuteCommand(string command)
        {
            if (command == "F")
                MoveForward(command);

            if (command == "B")
                MoveBackward(command);

            if (command == "L" || command == "R")
                DoRotation(command);
        }
        public void SetRoverPosition(int x, int y)
        {
            _grid.Area[x, y] = "R";
            Position[0] = x;
            Position[1] = y; 
        }

        public void SetRoverDirection(string direction)
        {
            CurrentDirection = direction;
        }
        private void DoRotation(string command)
        {
            var newDirection = _rotator.Rotate(command, CurrentDirection);
            CurrentDirection = newDirection;
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
    }
}