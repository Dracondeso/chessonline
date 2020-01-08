using Math.Tools.Primitives;
using Server.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Primitives
{
    public static class VectorExtensions
    {
        public static Vector Denormalize(this Vector vector, Side side) => vector.Sum(side == Side.Black ? new Vector(0, 8 - vector.Y) : new Vector(0, vector.Y));
    }
}
