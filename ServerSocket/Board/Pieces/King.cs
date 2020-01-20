using ChessOnline;
using Math.Tools.Primitives;
using Server.Enum;
using Server.Pieces.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Pieces
{
    public class King : Piece
    {
        public King(User user, Vector position) : base(user, position)
        {
            Move( 1, 1, 1, 1, 1, 1, 1, 1);
        }


    }
}
