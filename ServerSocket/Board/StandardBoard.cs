using System;
using System.Collections.Generic;
using System.Text;
using Server.Pieces.Abstraction;
using Server.Pieces.Factory;

namespace Server
{
    class Board

    {
        //public string[] Line = new string[8];
        private static ChessBuilder factory = new ChessBuilder();
        readonly static ICollection<Piece> chessBoard = new List<Piece>
        {

             factory.Build(Enum.PieceType.Rook1, Enum.Side.White),
            factory.Build(Enum.PieceType.Rook1, Enum.Side.Black),
            factory.Build(Enum.PieceType.Knight1, Enum.Side.White),
            factory.Build(Enum.PieceType.Knight1, Enum.Side.Black),
            factory.Build(Enum.PieceType.Bishop1, Enum.Side.White),
            factory.Build(Enum.PieceType.Bishop1, Enum.Side.Black),
            factory.Build(Enum.PieceType.Queen, Enum.Side.White),
            factory.Build(Enum.PieceType.Queen, Enum.Side.Black),
            factory.Build(Enum.PieceType.King, Enum.Side.White),
            factory.Build(Enum.PieceType.King, Enum.Side.Black),
             factory.Build(Enum.PieceType.Rook2, Enum.Side.White),
            factory.Build(Enum.PieceType.Rook2, Enum.Side.Black),
            factory.Build(Enum.PieceType.Knight2, Enum.Side.White),
            factory.Build(Enum.PieceType.Knight2, Enum.Side.Black),
            factory.Build(Enum.PieceType.Bishop2, Enum.Side.White),
            factory.Build(Enum.PieceType.Bishop2, Enum.Side.Black),
            factory.Build(Enum.PieceType.Pawn1, Enum.Side.White),
            factory.Build(Enum.PieceType.Pawn1, Enum.Side.Black),
            factory.Build(Enum.PieceType.Pawn2, Enum.Side.White),
            factory.Build(Enum.PieceType.Pawn2, Enum.Side.Black),
            factory.Build(Enum.PieceType.Pawn3, Enum.Side.White),
            factory.Build(Enum.PieceType.Pawn3, Enum.Side.Black),
            factory.Build(Enum.PieceType.Pawn4, Enum.Side.White),
            factory.Build(Enum.PieceType.Pawn4, Enum.Side.Black),
            factory.Build(Enum.PieceType.Pawn5, Enum.Side.White),
            factory.Build(Enum.PieceType.Pawn5, Enum.Side.Black),
            factory.Build(Enum.PieceType.Pawn6, Enum.Side.White),
            factory.Build(Enum.PieceType.Pawn6, Enum.Side.Black),
            factory.Build(Enum.PieceType.Pawn7, Enum.Side.White),
            factory.Build(Enum.PieceType.Pawn7, Enum.Side.Black),
            factory.Build(Enum.PieceType.Pawn8, Enum.Side.White),
            factory.Build(Enum.PieceType.Pawn8, Enum.Side.Black),
        };



        public Board()
        {

        }


    }
}
