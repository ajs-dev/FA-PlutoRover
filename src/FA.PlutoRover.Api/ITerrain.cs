using System.Drawing;

namespace FA.PlutoRover.Api
{
    public interface ITerrain : IObstacles
    {
        Point Grid { get; }
    }
}