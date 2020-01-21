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
        public King(Side side, Vector position, Board board) : base(side, position, board)
        {
        }
        public override List<Vector> Move()
        {
            base.Move();
                this.North = 1;
                this.NorthEast = 1;
                this.NorthWest = 1;
                this.South = 1;
                this.SouthEast = 1;
                this.SouthWest = 1;
                return Core.Behavior(this.StartPosition, this.Board);
            }


        }
    }

