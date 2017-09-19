using System.Drawing;
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
            var orientation = OrientationEnum.North;
            IMovement rover = new PlutoRover(grid, start, orientation);

            const string moveCommand = Movement.Forwards;
            ILocation expectedLocation = new Location(start.X, start.Y+1, OrientationEnum.North);

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
            var orientation = OrientationEnum.North;
            IMovement rover = new PlutoRover(grid, start, orientation);

            const string moveCommand = Movement.Backwards;
            ILocation expectedLocation = new Location(start.X, start.Y - 1, OrientationEnum.North);

            //Act
            ILocation newLocation = rover.Move(moveCommand);

            //Assert
            Assert.That(newLocation, Is.Not.Null);
            Assert.That(newLocation.X, Is.EqualTo(expectedLocation.X));
            Assert.That(newLocation.Y, Is.EqualTo(expectedLocation.Y));
            Assert.That(newLocation.Orientation, Is.EqualTo(expectedLocation.Orientation));
        }

        [Test]
        public void TurnLeft_OrientatedNorth()
        {
            //Arrange
            var start = new Point();
            var grid = new Point(10, 10);
            var orientation = OrientationEnum.North;
            IMovement rover = new PlutoRover(grid, start, orientation);

            const string moveCommand = Movement.TurnLeft;
            ILocation expectedLocation = new Location(start.X, start.Y, OrientationEnum.West);

            //Act
            ILocation newLocation = rover.Move(moveCommand);

            //Assert
            Assert.That(newLocation, Is.Not.Null);
            Assert.That(newLocation.X, Is.EqualTo(expectedLocation.X));
            Assert.That(newLocation.Y, Is.EqualTo(expectedLocation.Y));
            Assert.That(newLocation.Orientation, Is.EqualTo(expectedLocation.Orientation));
        }

        [Test]
        public void TurnRight_OrientatedNorth()
        {
            //Arrange
            var start = new Point();
            var grid = new Point(10, 10);
            var orientation = OrientationEnum.North;
            IMovement rover = new PlutoRover(grid, start, orientation);

            const string moveCommand = Movement.TurnRight;
            ILocation expectedLocation = new Location(start.X, start.Y, OrientationEnum.East);

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
