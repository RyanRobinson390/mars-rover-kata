namespace MarsRover.Logic
{
    public class Grid
    {
        public string[,] Area = new string[6, 6];
        public int[] RoverPosition { get; set; } = new int[2];
    }
}