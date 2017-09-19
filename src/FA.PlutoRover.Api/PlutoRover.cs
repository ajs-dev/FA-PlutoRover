using System;
using System.Drawing;

namespace FA.PlutoRover.Api
{
    public class PlutoRover : IMovement
    {
        private Point _grid;
        private Point _start;
        private OrientationEnum _orientation;

        public PlutoRover(Point grid, Point start, OrientationEnum orientation)
        {
            _grid = grid;
            _start = start;
            _orientation = orientation;
        }

        public ILocation Move(string journey)
        {
            throw new NotImplementedException();
        }
    }
}
