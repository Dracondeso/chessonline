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
            Vector normalizedStartPosition1 = new Vector((position.X + 1), position.Y); 
            Vector normalizedStartPosition2 = new Vector((position.X - 1), position.Y); 
            Vector normalizedStartPosition3 = new Vector((position.X), (position.Y+1)); 
            Vector normalizedStartPosition4 = new Vector((position.X), (position.Y-1));
            Move( 0, 0, 0, 0, 1, 1, 0, 0);
            Move( 0, 0, 0, 0, 0, 0, 1, 1);
            Move( 0, 0, 0, 0, 1, 0, 1, 0);
            Move( 0, 0, 0, 0, 0, 1, 0, 1);

        }

   
    }
}
