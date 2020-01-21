using System;
using System.Collections.Generic;
using System.Text;
using Math.Tools.Primitives;
using Server.Pieces.Abstraction;
using Server.Pieces;

namespace Server
{
    public class Board
    {
        public Dictionary<Vector, Piece> ChessBoard;
        public Board()
        {
            Rook rook1 = new Rook(Enum.Side.White, new Vector(1, 1),this);
            Knight knight1 = new Knight(Enum.Side.White, new Vector(2, 1), this);
            Bishop bishop1 = new Bishop(Enum.Side.White, new Vector(3, 1), this);
            Queen queen1 = new Queen(Enum.Side.White, new Vector(4, 1), this);
            King king1 = new King(Enum.Side.White, new Vector(5, 1), this);
            Bishop bishop2 = new Bishop(Enum.Side.White, new Vector(6, 1), this);
            Knight knight2 = new Knight(Enum.Side.White, new Vector(7, 1), this);
            Rook rook2 = new Rook(Enum.Side.White, new Vector(8, 1), this);
            Pawn pawn1 = new Pawn(Enum.Side.White, new Vector(1, 2), this);
            Pawn pawn2 = new Pawn(Enum.Side.White, new Vector(2, 2), this);
            Pawn pawn3 = new Pawn(Enum.Side.White, new Vector(3, 2), this);
            Pawn pawn4 = new Pawn(Enum.Side.White, new Vector(4, 2), this);
            Pawn pawn5 = new Pawn(Enum.Side.White, new Vector(5, 2), this);
            Pawn pawn6 = new Pawn(Enum.Side.White, new Vector(6, 2), this);
            Pawn pawn7 = new Pawn(Enum.Side.White, new Vector(7, 2), this);
            Pawn pawn8 = new Pawn(Enum.Side.White, new Vector(8, 2), this);
            Rook rook3 = new Rook(Enum.Side.White, new Vector(1, 8), this);
            Knight knight3 = new Knight(Enum.Side.Black, new Vector(2, 8), this);
            Bishop bishop3 = new Bishop(Enum.Side.Black, new Vector(3, 8), this);
            Queen queen2 = new Queen(Enum.Side.Black, new Vector(4, 8), this);
            King king2 = new King(Enum.Side.Black, new Vector(5, 8), this);
            Bishop bishop4 = new Bishop(Enum.Side.Black, new Vector(6, 8), this);
            Knight knight4 = new Knight(Enum.Side.Black, new Vector(7, 8), this);
            Rook rook4 = new Rook(Enum.Side.Black, new Vector(8, 8), this);
            Pawn pawn9 = new Pawn(Enum.Side.Black, new Vector(1, 7), this);
            Pawn pawn10 = new Pawn(Enum.Side.Black, new Vector(2, 7), this);
            Pawn pawn11 = new Pawn(Enum.Side.Black, new Vector(3, 7), this);
            Pawn pawn12 = new Pawn(Enum.Side.Black, new Vector(4, 7), this);
            Pawn pawn13 = new Pawn(Enum.Side.Black, new Vector(5, 7), this);
            Pawn pawn14 = new Pawn(Enum.Side.Black, new Vector(6, 7), this);
            Pawn pawn15 = new Pawn(Enum.Side.Black, new Vector(7, 7), this);
            Pawn pawn16 = new Pawn(Enum.Side.Black, new Vector(8, 7), this);
            this.ChessBoard = new Dictionary<Vector, Piece>
            {
                {rook1.StartPosition, rook1},
                {rook2.StartPosition,rook2},
                {rook3.StartPosition, rook3},
                {rook4.StartPosition, rook4},
                {bishop1.StartPosition, bishop1},
                {bishop2.StartPosition, bishop2},
                {bishop3.StartPosition, bishop3},
                {bishop4.StartPosition, bishop4},
                {knight1.StartPosition,knight1},
                {knight2.StartPosition,knight2},
                {knight3.StartPosition,knight3},
                {knight4.StartPosition,knight4},
                {queen1.StartPosition, queen1},
                {queen2.StartPosition, queen2},
                {king1.StartPosition,knight1},
                {king2.StartPosition,knight2},
                {pawn1.StartPosition,pawn1},
                {pawn2.StartPosition,pawn2},
                {pawn3.StartPosition,pawn3},
                {pawn4.StartPosition,pawn4},
                {pawn5.StartPosition,pawn5},
                {pawn6.StartPosition,pawn6},
                {pawn7.StartPosition,pawn7},
                {pawn8.StartPosition,pawn8},
                {pawn9.StartPosition,pawn9},
                {pawn10.StartPosition,pawn10},
                {pawn11.StartPosition,pawn11},
                {pawn12.StartPosition,pawn12},
                {pawn13.StartPosition,pawn13},
                {pawn14.StartPosition,pawn14},
                {pawn15.StartPosition,pawn15},
                {pawn16.StartPosition,pawn16}
            };

        }

    }




}

