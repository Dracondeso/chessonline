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
        public Piece Build(PieceType type, Side side, Vector? startNormalizedPosition = null) 
        {
            switch (type)
            {
                default:
                case PieceType.Rook1:
                    return new Rook(side, startNormalizedPosition ?? new Vector(1, 1));
                case PieceType.Knight1:
                    return new Knight(side, startNormalizedPosition ?? new Vector(1, 2));
                case PieceType.Bishop1:
                    return new King(side, startNormalizedPosition ?? new Vector(1, 3));
                case PieceType.Queen:
                    return new Queen(side, startNormalizedPosition ?? new Vector(1, 4));
                case PieceType.King:
                    return new King(side, startNormalizedPosition ?? new Vector(1, 5));
                case PieceType.Bishop2:
                    return new Bishop(side, startNormalizedPosition ?? new Vector(1, 6));
                case PieceType.Knight2:
                    return new Knight(side, startNormalizedPosition ?? new Vector(1, 7));
                case PieceType.Rook2:
                    return new Rook(side, startNormalizedPosition ?? new Vector(1, 8));
                case PieceType.Pawn1:
                    return new Pawn(side, startNormalizedPosition ?? new Vector(2, 1));
                case PieceType.Pawn2:
                    return new Pawn(side, startNormalizedPosition ?? new Vector(2, 2));
                case PieceType.Pawn3:
                    return new Pawn(side, startNormalizedPosition ?? new Vector(2, 3));
                case PieceType.Pawn4:
                    return new Pawn(side, startNormalizedPosition ?? new Vector(2, 4));
                case PieceType.Pawn5:
                    return new Pawn(side, startNormalizedPosition ?? new Vector(2, 5));
                case PieceType.Pawn6:
                    return new Pawn(side, startNormalizedPosition ?? new Vector(2, 6));
                case PieceType.Pawn7:
                    return new Pawn(side, startNormalizedPosition ?? new Vector(2, 7));
                case PieceType.Pawn8:
                    return new Pawn(side, startNormalizedPosition ?? new Vector(2, 8));

                    
            }
        }
    }
}
