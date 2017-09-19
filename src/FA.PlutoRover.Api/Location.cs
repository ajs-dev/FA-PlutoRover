namespace FA.PlutoRover.Api
{
    public class Location : ILocation
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public OrientationEnum Orientation { get; private set; }

        public Location(int x, int y, OrientationEnum orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }
    }
}