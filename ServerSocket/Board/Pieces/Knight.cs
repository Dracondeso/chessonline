using ChessOnline;
using Math.Tools.Primitives;
using Server.Enum;
using Server.Pieces.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Pieces
{
    public class Knight : Piece
    {
        public Knight(User user, Vector position) : base(user, position)
        {
            this.User = user;
            this.Position = position;

        }
        public override List<Vector> Move()
        {
            Vector position1 = new Vector((this.Position.X + 1), this.Position.Y); 
            Vector position2 = new Vector((this.Position.X - 1),this.Position.Y); 
            Vector position3 = new Vector((this.Position.X), (this.Position.Y+1)); 
            Vector position4 = new Vector((this.Position.X), (this.Position.Y-1));
            Bishop bishop1 = new Bishop(this.User, position1);
            Bishop bishop2 = new Bishop(this.User, position2);
            Bishop bishop3 = new Bishop(this.User, position3);
            Bishop bishop4 = new Bishop(this.User, position4);
            Core.ClearListVector(this.User);
            bishop1.Move();
            Core.Move(bishop1.User);
            this.Checks.AddRange(bishop1.Checks);
            bishop2.Move();
            Core.Move(bishop2.User);
            this.Checks.AddRange(bishop2.Checks);
            bishop3.Move();
            Core.Move(bishop3.User);
            this.Checks.AddRange(bishop3.Checks);
            bishop4.Move();
            Core.Move(bishop4.User);
            this.Checks.AddRange(bishop4.Checks);
            return Checks;

        }


    }
}
