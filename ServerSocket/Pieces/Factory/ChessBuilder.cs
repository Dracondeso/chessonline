using Math.Tools.Primitives;
using Server.Enum;
using Server.Pieces.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Pieces.Factory
{
    public class ChessBuilder
    {
        public Piece Build(PieceType type, Side side, int x, int y, Vector? startNormalizedPosition = null) 
        {
            switch (type)
            {
                default:
                case PieceType.Rook:
                    return new Rook(side, startNormalizedPosition ?? new Vector(x, y));
                case PieceType.Knight:
                    return new Knight(side, startNormalizedPosition ?? new Vector(x, y));
                case PieceType.Bishop:
                    return new King(side, startNormalizedPosition ?? new Vector(x, y));
                case PieceType.Queen:
                    return new Queen(side, startNormalizedPosition ?? new Vector(x, y));
                case PieceType.King:
                    return new King(side, startNormalizedPosition ?? new Vector(x, y));
                case PieceType.Pawn:
                    return new Pawn(side, startNormalizedPosition ?? new Vector(x, y));
            }
        }
    }
}
