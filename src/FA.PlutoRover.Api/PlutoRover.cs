using System;
using System.Drawing;

namespace FA.PlutoRover.Api
{
    public class PlutoRover : IRover
    {
        public const int ROOT_Y = 0;
        public const int ROOT_X = 0;

        private readonly Point _grid;
        private readonly Point _start;

        public Point Grid => _grid;
        public Point Start => _start;

        public ILocation CurrentLocation { get; private set; }

        public PlutoRover(Point grid, Point start, OrientationEnum orientation)
        {
            _start = start;
            _grid = grid;

            CurrentLocation = new Location(start.X, start.Y, orientation);
        }

        public ILocation Move(string journey)
        {
            if (string.IsNullOrWhiteSpace(journey))
                throw new ArgumentNullException(nameof(journey), "Please specified a journey for the rover");

            foreach (char step in journey)
            {
                CurrentLocation = MoveOne(step.ToString());
            }
            
            return CurrentLocation;
        }

        /// <summary>
        /// Marked public so that more simplified tests can be written
        /// </summary>
        /// <param name="journey"></param>
        /// <returns></returns>
        public ILocation MoveOne(string journey)
        {
            Point loc;
            OrientationEnum or;
            ILocation newLocation;
            //simple single journey "step"
            switch (journey)
            {
                case Movement.Forwards:
                    loc = GetLocationMovingForward(CurrentLocation);
                    newLocation = new Location(loc, CurrentLocation.Orientation);
                    break;
                case Movement.Backwards:
                    loc = GetLocationMovingBackward(CurrentLocation);
                    newLocation = new Location(loc, CurrentLocation.Orientation);
                    break;
                case Movement.TurnRight:
                    or = ChangeOrientationRight(CurrentLocation.Orientation);
                    newLocation = new Location(CurrentLocation.X, CurrentLocation.Y, or);
                    break;
                case Movement.TurnLeft:
                    or = ChangeOrientationLeft(CurrentLocation.Orientation);
                    newLocation = new Location(CurrentLocation.X, CurrentLocation.Y, or);
                    break;
                default:
                    //maybe should just swallow it
                    throw new InvalidOperationException($"The specified journey \"{journey}\" for the rover is invalid");
            }
            return newLocation;
        }

        /// <summary>
        /// Marked public so that more simplified tests can be written
        /// </summary>
        /// <param name="currentLoc"></param>
        /// <returns></returns>
        public Point GetLocationMovingForward(ILocation currentLoc)
        {
            Point loc = new Point();
            if (currentLoc.Orientation == OrientationEnum.North)
            {
                loc.X = currentLoc.X;
                loc.Y = currentLoc.Y >= Grid.Y ? ROOT_Y : currentLoc.Y + 1; //wrap around grid
            }
            else if (currentLoc.Orientation == OrientationEnum.East)
            {
                loc.X = currentLoc.X >= Grid.X ? ROOT_X : currentLoc.X + 1; //wrap around grid
                loc.Y = currentLoc.Y;
            }
            else if (currentLoc.Orientation == OrientationEnum.South)
            {
                loc.X = currentLoc.X;
                loc.Y = currentLoc.Y <= ROOT_Y ? Grid.Y : currentLoc.Y - 1; //wrap around grid
            }
            else if (currentLoc.Orientation == OrientationEnum.West)
            {
                loc.X = currentLoc.X <= ROOT_X ? Grid.X : currentLoc.X - 1; //wrap around grid
                loc.Y = currentLoc.Y;
            }

            return loc;
        }

        /// <summary>
        /// Marked public so that more simplified tests can be written
        /// </summary>
        /// <param name="currentLoc"></param>
        /// <returns></returns>
        public Point GetLocationMovingBackward(ILocation currentLoc)
        {
            Point loc = new Point();
            if (currentLoc.Orientation == OrientationEnum.North)
            {
                loc.X = currentLoc.X;
                loc.Y = currentLoc.Y <= ROOT_Y ? Grid.Y : currentLoc.Y - 1; //wrap around grid
            }
            else if (currentLoc.Orientation == OrientationEnum.East)
            {
                loc.X = currentLoc.X <= ROOT_X ? Grid.X : currentLoc.X - 1; //wrap around grid
                loc.Y = currentLoc.Y;
            }
            else if (currentLoc.Orientation == OrientationEnum.South)
            {
                loc.X = currentLoc.X;
                loc.Y = currentLoc.Y >= Grid.Y ? ROOT_Y : currentLoc.Y + 1; //wrap around grid
            }
            else if (currentLoc.Orientation == OrientationEnum.West)
            {
                loc.X = currentLoc.X >= Grid.X ? ROOT_X : currentLoc.X + 1; //wrap around grid
                loc.Y = currentLoc.Y;
            }

            return loc;
        }

        /// <summary>
        /// Marked public so that more simplified tests can be written
        /// </summary>
        /// <param name="orientation"></param>
        /// <returns></returns>
        public OrientationEnum ChangeOrientationRight(OrientationEnum orientation)
        {
            OrientationEnum newOr;
            switch (orientation)
            {
                case OrientationEnum.North:
                    newOr = OrientationEnum.East;
                    break;
                case OrientationEnum.East:
                    newOr = OrientationEnum.South;
                    break;
                case OrientationEnum.South:
                    newOr = OrientationEnum.West;
                    break;
                case OrientationEnum.West:
                    newOr = OrientationEnum.North;
                    break;
                default:
                    newOr = OrientationEnum.North;
                    break;
            }
            return newOr;
        }

        /// <summary>
        /// Marked public so that more simplified tests can be written
        /// </summary>
        /// <param name="orientation"></param>
        /// <returns></returns>
        public OrientationEnum ChangeOrientationLeft(OrientationEnum orientation)
        {
            OrientationEnum newOr;
            switch (orientation)
            {
                case OrientationEnum.North:
                    newOr = OrientationEnum.West;
                    break;
                case OrientationEnum.West:
                    newOr = OrientationEnum.South;
                    break;
                case OrientationEnum.South:
                    newOr = OrientationEnum.East;
                    break;
                case OrientationEnum.East:
                    newOr = OrientationEnum.North;
                    break;
                default:
                    newOr = OrientationEnum.North;
                    break;
            }
            return newOr;
        }
    }
}
