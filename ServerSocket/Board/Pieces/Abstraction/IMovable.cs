using ChessOnline;
using Math.Tools.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Pieces.Abstraction
{
    public interface IMovable
    {
        List<Vector> Move();

    }

}
//uble north, double south, double east, double west, double northEast, double northWest, double southEast, double southWest