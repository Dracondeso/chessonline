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
        public Rook(User user, Vector position) : base(user, position)
        {
        }
         public override List<Vector> Move()
        {
            base.Move();
            this.NorthEast = 0;
            this.NorthWest = 0;
            this.SouthEast = 0;
            this.SouthWest = 0;
            return Core.Move(this.User);
            
        }




    }

    }

