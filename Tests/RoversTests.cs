using System.Linq;
using NUnit.Framework;

namespace Tests
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
        public void Grid_IsEightByEight()
        {
            Assert.That(_grid.Area.Length, Is.EqualTo(64));
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

            _rover.Move("F");

            Assert.That(_grid.Area[4, 4], Is.EqualTo("R"));
        }
        
        [Test]
        public void Rover_CanMoveBackward()
        {
            _rover.SetRoverPosition(4, 4);

            _rover.Move("B");

            Assert.That(_grid.Area[4, 5], Is.EqualTo("R"));
        }

        [Test]
        public void Rover_CanTurnLeft()
        {
            _rover.SetRoverPosition(0,0);
            _rover.SetRoverDirection("N");

            _rover.Move("L");


            Assert.AreEqual("W", _rover.Direction);
        }
        
    }
}
