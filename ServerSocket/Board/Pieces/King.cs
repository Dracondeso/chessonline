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
                return Core.Move(this.User);
            }


        }
    }

