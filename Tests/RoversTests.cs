using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class RoversTests
    {
        private Grid _grid;

        [SetUp]
        public void SetUp()
        {
            _grid = new Grid();
        }

        [Test]
        public void Can_GetGrid()
        {
            _grid.InitializeGrid();
        }

        [Test]
        public void GetGrid_Initialize_IsEightByEight()
        {
            var grid = _grid.InitializeGrid();

            Assert.That(grid.Length, Is.EqualTo(64));
        }
    }
}
