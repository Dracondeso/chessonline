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
        }
        public override void Move()
        {
            base.Move();
            this.North = 0;
            this.South = 0;
            this.East = 0;
            this.West = 0;
            Core.MoveCreator(this);
        }

    }
}
