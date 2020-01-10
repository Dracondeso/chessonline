using System;
using System.Collections.Generic;
using System.Text;
using Math.Tools.Primitives;
using Server.Pieces.Abstraction;
using Server.Pieces.Factory;
using Server.Pieces;

namespace Server
{
    public class Board
    {
        //public string[] Line = new string[8];
        //private static ChessBuilder factory = new ChessBuilder();
        public static Vector rook1Pos = new Vector(1, 1);
        public static Rook rook1 = new Rook(Enum.Side.White, rook1Pos);
        public static Vector knight1Pos = new Vector(2, 1);
        public static Knight knight1 = new Knight(Enum.Side.White, knight1Pos);
        public static Vector bishop1Pos = new Vector(3, 1);
        public static Bishop bishop1 = new Bishop(Enum.Side.White, bishop1Pos);
        public static Vector queen1Pos = new Vector(4, 1);
        public static Queen queen1 = new Queen(Enum.Side.White, queen1Pos);
        public static Vector king1Pos = new Vector(5, 1);
        public static King king1 = new King(Enum.Side.White, king1Pos);
        public static Vector bishop2Pos = new Vector(6, 1);
        public static Bishop bishop2 = new Bishop(Enum.Side.White, bishop2Pos);
        public static Vector knight2Pos = new Vector(7, 1);
        public static Knight knight2 = new Knight(Enum.Side.White, knight2Pos);
        public static Vector rook2Pos = new Vector(8, 1);
        public static Rook rook2 = new Rook(Enum.Side.White, rook2Pos);
        public static Vector pawn1Pos = new Vector(1, 2);
        public static Pawn pawn1 = new Pawn(Enum.Side.White, pawn1Pos);
        public static Vector pawn2Pos = new Vector(2, 2);
        public static Pawn pawn2 = new Pawn(Enum.Side.White, pawn2Pos);
        public static Vector pawn3Pos = new Vector(3, 2);
        public static Pawn pawn3 = new Pawn(Enum.Side.White, pawn3Pos);
        public static Vector pawn4Pos = new Vector(4, 2);
        public static Pawn pawn4 = new Pawn(Enum.Side.White, pawn4Pos);
        public static Vector pawn5Pos = new Vector(5, 2);
        public static Pawn pawn5 = new Pawn(Enum.Side.White, pawn5Pos);
        public static Vector pawn6Pos = new Vector(6, 2);
        public static Pawn pawn6 = new Pawn(Enum.Side.White, pawn6Pos);
        public static Vector pawn7Pos = new Vector(7, 2);
        public static Pawn pawn7 = new Pawn(Enum.Side.White, pawn7Pos);
        public static Vector pawn8Pos = new Vector(8, 2);
        public static Pawn pawn8 = new Pawn(Enum.Side.White, pawn8Pos);
        public static Vector rook3Pos = new Vector(1, 8);
        public static Rook rook3 = new Rook(Enum.Side.White, rook3Pos);
        public static Vector knight3Pos = new Vector(2, 8);
        public static Knight knight3 = new Knight(Enum.Side.White, knight3Pos);
        public static Vector bishop3Pos = new Vector(3, 8);
        public static Bishop bishop3 = new Bishop(Enum.Side.White, bishop3Pos);
        public static Vector queen2Pos = new Vector(4, 8);
        public static Queen queen2 = new Queen(Enum.Side.White, queen2Pos);
        public static Vector king2Pos = new Vector(5, 8);
        public static King king2 = new King(Enum.Side.White, king2Pos);
        public static Vector bishop4Pos = new Vector(6, 8);
        public static Bishop bishop4 = new Bishop(Enum.Side.White, bishop4Pos);
        public static Vector knight4Pos = new Vector(7, 8);
        public static Knight knight4 = new Knight(Enum.Side.White, knight4Pos);
        public static Vector rook4Pos = new Vector(8, 8);
        public static Rook rook4 = new Rook(Enum.Side.White, rook4Pos);
        public static Vector pawn9Pos = new Vector(1, 7);
        public static Pawn pawn9 = new Pawn(Enum.Side.White, pawn9Pos);
        public static Vector pawn10Pos = new Vector(2, 7);
        public static Pawn pawn10 = new Pawn(Enum.Side.White, pawn10Pos);
        public static Vector pawn11Pos = new Vector(3, 7);
        public static Pawn pawn11 = new Pawn(Enum.Side.White, pawn11Pos);
        public static Vector pawn12Pos = new Vector(4, 7);
        public static Pawn pawn12 = new Pawn(Enum.Side.White, pawn12Pos);
        public static Vector pawn13Pos = new Vector(5, 7);
        public static Pawn pawn13 = new Pawn(Enum.Side.White, pawn13Pos);
        public static Vector pawn14Pos = new Vector(6, 7);
        public static Pawn pawn14 = new Pawn(Enum.Side.White, pawn14Pos);
        public static Vector pawn15Pos = new Vector(7, 7);
        public static Pawn pawn15 = new Pawn(Enum.Side.White, pawn15Pos);
        public static Vector pawn16Pos = new Vector(8, 7);
        public static Pawn pawn16 = new Pawn(Enum.Side.White, pawn16Pos);
        public static IDictionary<Vector, Piece> chessBoard = new Dictionary<Vector, Piece>
            {
                {rook1Pos, rook1},
                {rook2Pos,rook2},
                {rook3Pos, rook3},
                {rook4Pos, rook4},
                {bishop1Pos, bishop1},
                {bishop2Pos, bishop2},
                {bishop3Pos, bishop3},
                {bishop4Pos, bishop4},
                {knight1Pos,knight1},
                {knight2Pos,knight2},
                {knight3Pos,knight3},
                {knight4Pos,knight4},
                {queen1Pos, queen1},
                {queen2Pos, queen2},
                {king1Pos,knight1},
                {king2Pos,knight2},
                {pawn1Pos,pawn1},
                {pawn2Pos,pawn2},
                {pawn3Pos,pawn3},
                {pawn4Pos,pawn4},
                {pawn5Pos,pawn5},
                {pawn6Pos,pawn6},
                {pawn7Pos,pawn7},
                {pawn8Pos,pawn8},
                {pawn9Pos,pawn9},
                {pawn10Pos,pawn10},
                {pawn11Pos,pawn11},
                {pawn12Pos,pawn12},
                {pawn13Pos,pawn13},
                {pawn14Pos,pawn14},
                {pawn15Pos,pawn15},
                {pawn16Pos,pawn16}
            };
        //factory.Build(Enum.PieceType.Rook, Enum.Side.White),
        //factory.Build(Enum.PieceType.Rook, Enum.Side.Black),
        //factory.Build(Enum.PieceType.Knight, Enum.Side.White),
        //factory.Build(Enum.PieceType.Knight, Enum.Side.Black),
        //factory.Build(Enum.PieceType.Bishop, Enum.Side.White),
        //factory.Build(Enum.PieceType.Bishop, Enum.Side.Black),
        //factory.Build(Enum.PieceType.Queen, Enum.Side.White),
        //factory.Build(Enum.PieceType.Queen, Enum.Side.Black),
        //factory.Build(Enum.PieceType.King, Enum.Side.White),
        //factory.Build(Enum.PieceType.King, Enum.Side.Black),
        //factory.Build(Enum.PieceType.Pawn, Enum.Side.White),
        //factory.Build(Enum.PieceType.Pawn, Enum.Side.Black),
    }




}

