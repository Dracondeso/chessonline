using Math.Tools.Primitives;
using Server.Enum;
using Server.Pieces.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Pieces
{
    public class Rook : Piece
    {
        public Rook(Side side, Vector normalizedStartPosition) : base(side, normalizedStartPosition)
        {
            Move(normalizedStartPosition, 8, 8, 8, 8, 0, 0, 0, 0);
        }

    


        }

    }

