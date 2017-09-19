namespace FA.PlutoRover.Api
{
    public interface ILocation
    {
        int X { get; }
        int Y { get; }
        OrientationEnum Orientation { get; }
    }
}