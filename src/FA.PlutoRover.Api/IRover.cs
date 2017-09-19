namespace FA.PlutoRover.Api
{
    public interface IRover : IMovement
    {
        ILocation CurrentLocation { get; }
    }
}