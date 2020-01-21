using ChessOnline;
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
        public Rook(Side side, Vector position, Board board) : base(side, position, board)
        {
        }
         public override List<Vector> Move()
        {
            base.Move();
            this.NorthEast = 0;
            this.NorthWest = 0;
            this.SouthEast = 0;
            this.SouthWest = 0;
            return Core.Behavior(this.StartPosition,this.Board);
            
        }




    }

    }

