namespace MarsRover.Logic
{
    public class Rover
    {
        private readonly Grid _grid;
        
        public Navigator Navigator { get; private set; }
        
        public Rover(Grid grid)
        {
            _grid = grid;
            Navigator = new Navigator(new Rotator(), new MoveActions(), grid);
        }

        public void ExecuteCommand(string command)
        {
            if (command == "F" || command == "B")
                Navigator.DoMove(command);
            
            if (command == "L" || command == "R")
                Navigator.DoRotation(command);
        }
    }
}