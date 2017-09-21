using System.Collections.Generic;
using System.Drawing;

namespace FA.PlutoRover.Api
{
    public class PlanetaryTerrain : ITerrain
    {
        public Point Grid { get; }

        public IReadOnlyCollection<Point> Obstacles { get; }

        public PlanetaryTerrain(Point grid, IReadOnlyCollection<Point> obstacles)
        {
            Grid = grid;
            Obstacles = obstacles;
        }
    }
}