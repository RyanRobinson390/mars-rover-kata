namespace MarsRover.Logic
{
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