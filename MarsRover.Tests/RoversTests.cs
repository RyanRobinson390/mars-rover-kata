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

            SetupRover();
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
            _rover.ExecuteCommand("F");
        
            Assert.AreEqual(_rover.CurrentPosition.X, 0);
            Assert.AreEqual(_rover.CurrentPosition.Y, 1);
        }
        
        
        [Test]
        public void Rover_CanMoveBackward()
        {
            _rover.SetRoverPosition(4, 4);
            _rover.ExecuteCommand("B");

            Assert.AreEqual(_rover.CurrentPosition.X, 4);
            Assert.AreEqual(_rover.CurrentPosition.Y, 3);
        }
        
        [TestCase("L", "N", "W")]
        [TestCase("R", "W", "N")]
        public void Rover_CanRotate(string intendedRotation, string initialDirection, string expectedDirection)
        {
            _rover.SetRoverDirection(initialDirection);
            _rover.ExecuteCommand(intendedRotation);
            
            Assert.AreEqual(expectedDirection, _rover.CurrentDirection);
        }
        
        [Test]
        public void RoverMoves_WithDirection_ToCorrectPosition()
        {
            _rover.ExecuteCommand("F");
            _rover.ExecuteCommand("R");
            _rover.ExecuteCommand("F");

            var expectedPosition = new Position(1, 1); 
            
            Assert.AreEqual(expectedPosition.X, 1);
            Assert.AreEqual(expectedPosition.Y, 1);
        }
        
        private void SetupRover()
        {
            _rover.SetRoverDirection("N");
            _rover.SetRoverPosition(0, 0);
        }
    }
}
