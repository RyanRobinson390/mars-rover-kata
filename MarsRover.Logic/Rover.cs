namespace MarsRover.Logic
{
    public class Rover
    {
        public Position CurrentPosition { get; private set; }
        
        public string CurrentDirection { get; private set; }

        private readonly Grid _grid;

        private Rotator _rotator;

        private MoveActions _moveActions;
        
        public Rover(Grid grid)
        {
            _grid = grid;
            _rotator = new Rotator();
            CurrentPosition = new Position(0, 0);
            _moveActions = new MoveActions();
        }

        public void ExecuteCommand(string command)
        {
            if (command == "F" || command == "B")
                DoMove(command);
            
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

        private void DoMove(string command)
        {
            if (command == "F")
                _moveActions.MoveForward(CurrentDirection, CurrentPosition);
            
            if (command == "B")
                _moveActions.MoveBackward(CurrentDirection, CurrentPosition);
        }
    }
}