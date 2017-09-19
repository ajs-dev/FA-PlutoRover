using System.Drawing;
using System.Reflection.PortableExecutable;
using NUnit.Framework;

namespace FA.PlutoRover.Api.Tests
{
    [TestFixture]
    public class MovementTests
    {
        [Test]
        public void MoveForward_StartAtZeroZero_OrientatedNorth()
        {
            //Arrange
            var start = new Point();
            var grid = new Point(10, 10);
            var orientation = Orientation.North;
            IMovement rover = new PlutoRover(grid, start, orientation);

            const string moveCommand = Movement.Forwards;
            const ILocation expectedLocation = new Location(start.X, start.Y+1, Orientation.North);

            //Act
            ILocation newLocation = rover.Move(moveCommand);

            //Assert
            Assert.That(newLocation, Is.Not.Null);
            Assert.That(newLocation.X, Is.EqualTo(expectedLocation.X));
            Assert.That(newLocation.Y, Is.EqualTo(expectedLocation.Y));
            Assert.That(newLocation.Orientation, Is.EqualTo(expectedLocation.Orientation));
        }

        [Test]
        public void MoveBackward_StartAtZeroOne_OrientatedNorth()
        {
            //Arrange
            var start = new Point();
            var grid = new Point(10, 10);
            var orientation = Orientation.North;
            IMovement rover = new PlutoRover(grid, start, orientation);

            const string moveCommand = Movement.Backwards;
            const ILocation expectedLocation = new Location(start.X, start.Y - 1, Orientation.North);

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