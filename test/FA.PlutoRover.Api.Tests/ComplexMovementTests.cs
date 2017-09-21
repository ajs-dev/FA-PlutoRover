using System.Drawing;
using NUnit.Framework;

namespace FA.PlutoRover.Api.Tests
{
    [TestFixture]
    public class ComplexMovementTests
    {
        [Test]
        public void MoveFFF_OrientatedNorth()
        {
            //Arrange
            var start = new Point();
            var grid = new Point(10, 10);
            var orientation = OrientationEnum.North;
            IMovement rover = new PlutoRover(grid, start, orientation);

            const string moveCommand = "FFF";
            ILocation expectedLocation = new Location(start.X, start.Y+3, orientation);

            //Act
            ILocation newLocation = rover.Move(moveCommand);

            //Assert
            Assert.That(newLocation, Is.Not.Null);
            Assert.That(newLocation.X, Is.EqualTo(expectedLocation.X));
            Assert.That(newLocation.Y, Is.EqualTo(expectedLocation.Y));
            Assert.That(newLocation.Orientation, Is.EqualTo(expectedLocation.Orientation));
        }

    }
}