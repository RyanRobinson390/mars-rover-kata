namespace MarsRover.Logic
{
    public class Navigator
    {
        public Position CurrentPosition { get; private set; }
        public string CurrentDirection { get; private set; }

        private readonly Rotator _rotator;
        private readonly MoveActions _moveActions;
        private readonly Grid _grid;

        public Navigator(Rotator rotator, MoveActions moveActions, Grid grid)
        {
            _rotator = rotator;
            _moveActions = moveActions;
            _grid = grid;
            CurrentPosition = new Position(0, 0);
        }
        
        public void SetRoverPosition(int x, int y)
        {
            CurrentPosition.X = x;
            CurrentPosition.Y = y;

            _grid.Area[CurrentPosition.X, CurrentPosition.Y] = "R"; 
        }

        public void SetRoverDirection(string direction)
        {
            CurrentDirection = direction;
        }
        public void DoRotation(string command)
        {
            var newDirection = _rotator.Rotate(command, CurrentDirection);
            CurrentDirection = newDirection;
        }

        public void DoMove(string command)
        {
            switch (command)
            {
                case "F":
                    _moveActions.MoveForward(CurrentDirection, CurrentPosition);
                    _grid.Area[CurrentPosition.X, CurrentPosition.Y] = "R";
                    break;
                case "B":
                    _moveActions.MoveBackward(CurrentDirection, CurrentPosition);
                    _grid.Area[CurrentPosition.X, CurrentPosition.Y] = "R";
                    break;
            }
        }
    }
}