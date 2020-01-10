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
        public Knight(Side side, Vector normalizedStartPosition) : base(side, normalizedStartPosition)
        {
            Vector normalizedStartPosition1 = new Vector((normalizedStartPosition.X + 1), normalizedStartPosition.Y); 
            Vector normalizedStartPosition2 = new Vector((normalizedStartPosition.X - 1), normalizedStartPosition.Y); 
            Vector normalizedStartPosition3 = new Vector((normalizedStartPosition.X), (normalizedStartPosition.Y+1)); 
            Vector normalizedStartPosition4 = new Vector((normalizedStartPosition.X), (normalizedStartPosition.Y-1));
            Move(normalizedStartPosition1, 0, 0, 0, 0, 1, 1, 0, 0);
            Move(normalizedStartPosition2, 0, 0, 0, 0, 0, 0, 1, 1);
            Move(normalizedStartPosition3, 0, 0, 0, 0, 1, 0, 1, 0);
            Move(normalizedStartPosition4, 0, 0, 0, 0, 0, 1, 0, 1);

        }

   
    }
}
