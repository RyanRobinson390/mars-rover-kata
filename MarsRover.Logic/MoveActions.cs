namespace MarsRover.Logic
{
    public class MoveActions
    {
        public void MoveForward(string currentDirection, Position currentPosition)
        {
            switch (currentDirection)
            {
                case "N":
                    currentPosition.Y++;
                    break;
                case "E":
                    currentPosition.X++;
                    break;
                case "S":
                    currentPosition.Y--;
                    break;
                case "W":
                    currentPosition.X--;
                    break;
            }
        }
        public void MoveBackward(string currentDirection, Position currentPosition)
        {
            switch (currentDirection)
            {
                case "N":
                    currentPosition.Y--;
                    break;
                case "E":
                    currentPosition.X--;
                    break;
                case "S":
                    currentPosition.Y++;
                    break;
                case "W":
                    currentPosition.X++;
                    break;
            }
        }
    }
}