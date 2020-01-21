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
        public Bishop(Side side, Vector startPosition , Board board) : base(side, startPosition,board)
        {
        }
        public override List<Vector> Move()
        {

            base.Move();
            this.North = 0;
            this.South = 0;
            this.East = 0;
            this.West = 0;
            return Core.Behavior(this.StartPosition,this.Board);
        }

    }
}
