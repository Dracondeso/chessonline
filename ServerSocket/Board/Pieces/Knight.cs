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
        public Knight(Side side, Vector position, Board board) : base(side, position, board)
        {
         
        }
        public override List<Vector> Move()
        {
            Vector position1 = new Vector((this.StartPosition.X + 1), this.StartPosition.Y); 
            Vector position2 = new Vector((this.StartPosition.X - 1),this.StartPosition.Y); 
            Vector position3 = new Vector((this.StartPosition.X), (this.StartPosition.Y+1)); 
            Vector position4 = new Vector((this.StartPosition.X), (this.StartPosition.Y-1));
            Bishop bishop1 = new Bishop(this.Side, position1,this.Board);
            Bishop bishop2 = new Bishop(this.Side, position2, this.Board);
            Bishop bishop3 = new Bishop(this.Side, position3, this.Board);
            Bishop bishop4 = new Bishop(this.Side, position4, this.Board);
            this.Checks.Clear();
            bishop1.Move();
            Core.Behavior(position1, bishop1.Board);
            this.Checks.AddRange( bishop1.Checks);
            bishop2.Move();
            Core.Behavior(position2, bishop2.Board);
            this.Checks.AddRange(bishop2.Checks);
            bishop3.Move();
            Core.Behavior(position3, bishop3.Board);
            this.Checks.AddRange(bishop3.Checks);
            bishop4.Move();
            Core.Behavior(position4,bishop4.Board);
            this.Checks.AddRange(bishop4.Checks);
            return Checks;

        }


    }
}
