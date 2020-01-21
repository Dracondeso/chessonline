﻿using ChessOnline;
using Math.Tools.Primitives;
using Server.Enum;
using Server.Pieces.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Pieces
{
    public class Queen : Piece
    {
        public Queen(User user, Vector position) : base(user, position)
        {
        }
        public override List<Vector> Move()
        {
            base.Move();
            return Core.Move(this.User);
        }

    }

}
