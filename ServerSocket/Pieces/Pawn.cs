using Math.Tools.Primitives;
using Server.Enum;
using Server.Pieces.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(Side side, Vector normalizedStartPosition) : base(side, normalizedStartPosition)
        {
        }

    }
}
