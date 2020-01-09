using System;
using System.Collections.Generic;
using System.Text;
using Server.Pieces.Abstraction;
using Server.Pieces.Factory;

namespace Server
{
    public class Board
    {
        //public string[] Line = new string[8];
        private static ChessBuilder factory = new ChessBuilder();
        readonly static ICollection<Piece> chessBoard = new List<Piece>
        {

            factory.Build(Enum.PieceType.Rook, Enum.Side.White),
            factory.Build(Enum.PieceType.Rook, Enum.Side.Black),
            factory.Build(Enum.PieceType.Knight, Enum.Side.White),
            factory.Build(Enum.PieceType.Knight, Enum.Side.Black),
            factory.Build(Enum.PieceType.Bishop, Enum.Side.White),
            factory.Build(Enum.PieceType.Bishop, Enum.Side.Black),
            factory.Build(Enum.PieceType.Queen, Enum.Side.White),
            factory.Build(Enum.PieceType.Queen, Enum.Side.Black),
            factory.Build(Enum.PieceType.King, Enum.Side.White),
            factory.Build(Enum.PieceType.King, Enum.Side.Black),
            factory.Build(Enum.PieceType.Pawn, Enum.Side.White),
            factory.Build(Enum.PieceType.Pawn, Enum.Side.Black),
        };



        public Board()
        {

        }


    }
}
