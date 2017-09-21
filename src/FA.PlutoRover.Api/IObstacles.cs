using System.Collections.Generic;
using System.Drawing;

namespace FA.PlutoRover.Api
{
    public interface IObstacles
    {
        IReadOnlyCollection<Point> Obstacles { get; }
    }
}