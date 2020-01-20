using ChessOnline;
using Math.Tools.Primitives;
using Server.Enum;
using Server.Pieces.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(User user, Vector Position) : base(user, Position)
        {
            Move(0, 0, 0, 0, 8, 8, 8, 8);
        }


    }
}
