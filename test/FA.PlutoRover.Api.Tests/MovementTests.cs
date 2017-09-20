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
            ILocation expectedLocation = new Location(start.X, start.Y+1, orientation);

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
            ILocation expectedLocation = new Location(start.X, start.Y - 1, orientation);

            //Act
            ILocation newLocation = rover.Move(moveCommand);

            //Assert
            Assert.That(newLocation, Is.Not.Null);
            Assert.That(newLocation.X, Is.EqualTo(expectedLocation.X));
            Assert.That(newLocation.Y, Is.EqualTo(expectedLocation.Y));
            Assert.That(newLocation.Orientation, Is.EqualTo(expectedLocation.Orientation));
        }

        [Test]
        public void MoveForward_StartAtGridBoundary_OrientatedNorth_WrapAround()
        {
            //Arrange
            var grid = new Point(10, 10);
            var start = new Point(PlutoRover.ROOT_X, grid.Y);
            var orientation = OrientationEnum.North;
            IMovement rover = new PlutoRover(grid, start, orientation);

            const string moveCommand = Movement.Forwards;
            ILocation expectedLocation = new Location(start.X, PlutoRover.ROOT_Y, orientation);

            //Act
            ILocation newLocation = rover.Move(moveCommand);

            //Assert
            Assert.That(newLocation, Is.Not.Null);
            Assert.That(newLocation.X, Is.EqualTo(expectedLocation.X));
            Assert.That(newLocation.Y, Is.EqualTo(expectedLocation.Y));
            Assert.That(newLocation.Orientation, Is.EqualTo(expectedLocation.Orientation));
        }

        [Test]
        public void MoveForward_StartAtGridBoundary_OrientatedEast_WrapAround()
        {
            //Arrange
            var grid = new Point(10, 10);
            var start = new Point(grid.X, PlutoRover.ROOT_Y);
            var orientation = OrientationEnum.East;
            IMovement rover = new PlutoRover(grid, start, orientation);

            const string moveCommand = Movement.Forwards;
            ILocation expectedLocation = new Location(PlutoRover.ROOT_X, start.Y, orientation);

            //Act
            ILocation newLocation = rover.Move(moveCommand);

            //Assert
            Assert.That(newLocation, Is.Not.Null);
            Assert.That(newLocation.X, Is.EqualTo(expectedLocation.X));
            Assert.That(newLocation.Y, Is.EqualTo(expectedLocation.Y));
            Assert.That(newLocation.Orientation, Is.EqualTo(expectedLocation.Orientation));
        }

        [Test]
        public void MoveForward_StartAtGridBoundary_OrientatedSouth_WrapAround()
        {
            //Arrange
            var grid = new Point(10, 10);
            var start = new Point(grid.X, PlutoRover.ROOT_Y);
            var orientation = OrientationEnum.South;
            IMovement rover = new PlutoRover(grid, start, orientation);

            const string moveCommand = Movement.Forwards;
            ILocation expectedLocation = new Location(start.X, grid.Y, orientation);

            //Act
            ILocation newLocation = rover.Move(moveCommand);

            //Assert
            Assert.That(newLocation, Is.Not.Null);
            Assert.That(newLocation.X, Is.EqualTo(expectedLocation.X));
            Assert.That(newLocation.Y, Is.EqualTo(expectedLocation.Y));
            Assert.That(newLocation.Orientation, Is.EqualTo(expectedLocation.Orientation));
        }

        [Test]
        public void MoveForward_StartAtGridBoundary_OrientatedWest_WrapAround()
        {
            //Arrange
            var grid = new Point(10, 10);
            var start = new Point(PlutoRover.ROOT_X, PlutoRover.ROOT_Y);
            var orientation = OrientationEnum.West;
            IMovement rover = new PlutoRover(grid, start, orientation);

            const string moveCommand = Movement.Forwards;
            ILocation expectedLocation = new Location(grid.X, start.Y, orientation);

            //Act
            ILocation newLocation = rover.Move(moveCommand);

            //Assert
            Assert.That(newLocation, Is.Not.Null);
            Assert.That(newLocation.X, Is.EqualTo(expectedLocation.X));
            Assert.That(newLocation.Y, Is.EqualTo(expectedLocation.Y));
            Assert.That(newLocation.Orientation, Is.EqualTo(expectedLocation.Orientation));
        }

        [Test]
        public void MoveBackward_StartAtGridBoundary_OrientatedNorth_WrapAround()
        {
            //Arrange
            var grid = new Point(10, 10);
            var start = new Point(PlutoRover.ROOT_X, PlutoRover.ROOT_Y);
            var orientation = OrientationEnum.North;
            IMovement rover = new PlutoRover(grid, start, orientation);

            const string moveCommand = Movement.Backwards;
            ILocation expectedLocation = new Location(start.X, grid.Y, orientation);

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
