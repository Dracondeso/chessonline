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
            Move(8, 8, 8, 8, 0, 0, 0, 0);
        }

    


        }

    }

