﻿using System;
using System.Drawing;
using System.Linq;

namespace FA.PlutoRover.Api
{
    public class PlutoRover : IRover
    {
        public const int ROOT_Y = 0;
        public const int ROOT_X = 0;

        public ITerrain Terrain { get; }
        public Point Start { get; }

        public ILocation CurrentLocation { get; private set; }

        public PlutoRover(ITerrain terrain, Point start, OrientationEnum orientation)
        {
            Start = start;
            Terrain = terrain;

            CurrentLocation = new Location(start.X, start.Y, orientation);
        }

        public ILocation Move(string journey)
        {
            if (string.IsNullOrWhiteSpace(journey))
                throw new ArgumentNullException(nameof(journey), "Please specified a journey for the rover");

            ILocation newLocation = null;
            foreach (char step in journey)
            {
                newLocation = MoveOne(step.ToString());
                if (Terrain.Obstacles.Contains(new Point(newLocation.X, newLocation.Y)))
                {
                    //report obstacle encountered
                    newLocation =
                        new LocationBlocked("An obstacle is blocking your path. Go north, open door with key, or go back.",
                                            CurrentLocation.X, CurrentLocation.Y, CurrentLocation.Orientation);
                    break;
                }
                else
                {
                    CurrentLocation = newLocation;
                }
            }
            
            return newLocation;
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
                loc.Y = currentLoc.Y >= Terrain.Grid.Y ? ROOT_Y : currentLoc.Y + 1; //wrap around grid
            }
            else if (currentLoc.Orientation == OrientationEnum.East)
            {
                loc.X = currentLoc.X >= Terrain.Grid.X ? ROOT_X : currentLoc.X + 1; //wrap around grid
                loc.Y = currentLoc.Y;
            }
            else if (currentLoc.Orientation == OrientationEnum.South)
            {
                loc.X = currentLoc.X;
                loc.Y = currentLoc.Y <= ROOT_Y ? Terrain.Grid.Y : currentLoc.Y - 1; //wrap around grid
            }
            else if (currentLoc.Orientation == OrientationEnum.West)
            {
                loc.X = currentLoc.X <= ROOT_X ? Terrain.Grid.X : currentLoc.X - 1; //wrap around grid
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
                loc.Y = currentLoc.Y <= ROOT_Y ? Terrain.Grid.Y : currentLoc.Y - 1; //wrap around grid
            }
            else if (currentLoc.Orientation == OrientationEnum.East)
            {
                loc.X = currentLoc.X <= ROOT_X ? Terrain.Grid.X : currentLoc.X - 1; //wrap around grid
                loc.Y = currentLoc.Y;
            }
            else if (currentLoc.Orientation == OrientationEnum.South)
            {
                loc.X = currentLoc.X;
                loc.Y = currentLoc.Y >= Terrain.Grid.Y ? ROOT_Y : currentLoc.Y + 1; //wrap around grid
            }
            else if (currentLoc.Orientation == OrientationEnum.West)
            {
                loc.X = currentLoc.X >= Terrain.Grid.X ? ROOT_X : currentLoc.X + 1; //wrap around grid
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
