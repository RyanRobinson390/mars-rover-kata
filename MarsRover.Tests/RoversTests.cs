using MarsRover.Logic;
using NUnit.Framework;

namespace MarsRover.Tests
{
    [TestFixture]
    public class RoversTests
    {
        private Grid _grid;
        private Rover _rover;

        [SetUp]
        public void SetUp()
        {
            _grid = new Grid();
            _rover = new Rover(_grid); 
        }
        
        [Test]
        public void Grid_IsFiveByFive_IncludingZeroCoordinates()
        {
            Assert.That(_grid.Area.Length, Is.EqualTo(36));
        }

        [Test]
        public void Grid_HasRover()
        {
            _rover.SetRoverPosition(4, 5);
            
            Assert.That(_grid.Area[4, 5], Is.EqualTo("R"));
       }
        
        [Test]
        public void Rover_CanMoveForward()
        {
            _rover.SetRoverPosition(4, 5);

            _rover.ExecuteCommand("F");

            Assert.That(_grid.Area[4, 4], Is.EqualTo("R"));
        }
        
        [Test]
        public void Rover_CanMoveBackward()
        {
            _rover.SetRoverPosition(4, 4);

            _rover.ExecuteCommand("B");

            Assert.That(_grid.Area[4, 5], Is.EqualTo("R"));
        }
        
        [TestCase("L", "N", "W")]
        [TestCase("R", "W", "N")]
        public void Rover_CanRotate(string intendedRotation, string initialDirection, string expectedDirection)
        {
            _rover.SetRoverDirection(initialDirection);
            _rover.ExecuteCommand(intendedRotation);
            
            Assert.AreEqual(expectedDirection, _rover.CurrentDirection);
        }
    }
}
