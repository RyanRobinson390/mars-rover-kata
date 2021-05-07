namespace MarsRover.Logic
{
    public class Rover
    {
        public Position CurrentPosition { get; private set; }
        
        //public int[] CurrentPosition { get; set; } = new int[2];

        public string CurrentDirection { get; private set; }

        private readonly Grid _grid;

        private Rotator _rotator = new Rotator();

        public Rover(Grid grid)
        {
            _grid = grid;
            CurrentPosition = new Position(0, 0);
        }

        public void ExecuteCommand(string command)
        {
            if (command == "F")
                MoveForward();

            if (command == "B")
                MoveBackward();

            if (command == "L" || command == "R")
                DoRotation(command);
        }
        public void SetRoverPosition(int x, int y)
        {
            CurrentPosition.X = x;
            CurrentPosition.Y = y;
            _grid.Area[x, y] = "R";
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
        
        private void MoveBackward()
        {
            switch (CurrentDirection)
            {
                case "N":
                    CurrentPosition.Y++;
                    break;
                case "E":
                    CurrentPosition.X++;
                    break;
                case "S":
                    CurrentPosition.Y--;
                    break;
                case "W":
                    CurrentPosition.X--;
                    break;
            }

            _grid.Area[CurrentPosition.X, CurrentPosition.Y] = "R";
        }

        private void MoveForward()
        {
            switch (CurrentDirection)
            {
                case "N":
                    CurrentPosition.Y++;
                    break;
                case "E":
                    CurrentPosition.X++;
                    break;
                case "S":
                    CurrentPosition.Y--;
                    break;
                case "W":
                    CurrentPosition.X--;
                    break;
            }
            _grid.Area[CurrentPosition.X, CurrentPosition.Y] = "R";
        }
    }
}