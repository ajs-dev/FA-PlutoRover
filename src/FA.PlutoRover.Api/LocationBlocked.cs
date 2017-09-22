namespace FA.PlutoRover.Api
{
    public class LocationBlocked : ILocation
    {
        public int X { get; }
        public int Y { get; }
        public OrientationEnum Orientation { get; }

        public string Reason { get; }

        public LocationBlocked(string reason, int x, int y, OrientationEnum orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;

            Reason = reason;
        }
    }
}