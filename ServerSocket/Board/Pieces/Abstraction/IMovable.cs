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
