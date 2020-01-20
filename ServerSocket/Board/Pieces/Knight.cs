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
           

        }
        public override void Move()
        {
            Vector position1 = new Vector((this.Position.X + 1), this.Position.Y); 
            Vector position2 = new Vector((this.Position.X - 1),this.Position.Y); 
            Vector position3 = new Vector((this.Position.X), (this.Position.Y+1)); 
            Vector position4 = new Vector((this.Position.X), (this.Position.Y-1));
            Bishop bishop1 = new Bishop(this.User, position1);
            Bishop bishop2 = new Bishop(this.User, position2);
            Bishop bishop3 = new Bishop(this.User, position3);
            Bishop bishop4 = new Bishop(this.User, position4);
            bishop1.Move();
            Core.MoveCreator(bishop1);
            this.Checks.AddRange(bishop1.Checks);
            bishop2.Move();
            Core.MoveCreator(bishop2);
            this.Checks.AddRange(bishop2.Checks);
            bishop3.Move();
            Core.MoveCreator(bishop3);
            this.Checks.AddRange(bishop3.Checks);
            bishop4.Move();
            Core.MoveCreator(bishop4);
            this.Checks.AddRange(bishop4.Checks);

        }


    }
}
