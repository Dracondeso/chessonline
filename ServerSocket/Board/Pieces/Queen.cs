using ChessOnline;
using Math.Tools.Primitives;
using Server.Enum;
using Server.Pieces.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Pieces
{
    public class Queen : Piece
    {
        public Queen(Side side, Vector position, Board board) : base(side, position, board)
        {
        }
        public override List<Vector> Move()
        {
            base.Move();
            return Core.Behavior(this.StartPosition,this.Board);
        }

    }

}

