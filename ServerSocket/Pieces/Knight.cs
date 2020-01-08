using Math.Tools.Primitives;
using Server.Enum;
using Server.Pieces.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Pieces
{
    public class Knight : Abstraction.Piece
    {
        public Knight(Side side, Vector normalizedStartPosition) : base(side, normalizedStartPosition)
        {
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }
    }
}
