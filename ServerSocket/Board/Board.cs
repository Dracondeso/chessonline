using System;
using System.Collections.Generic;
using System.Text;
using Math.Tools.Primitives;
using Server.Pieces.Abstraction;
using Server.Pieces;
using ChessOnline;

namespace Server
{
    public class Board
    {
        public Dictionary<Vector, Piece> ChessBoard;
        public List<User> Users { get; }
        public User WhitePlayer = new User() ;
        public User BlackPlayer = new User();
        public Board(List<User> users)
        {
            Rook rook1 = new Rook(WhitePlayer, new Vector(1, 1));
            Knight knight1 = new Knight(WhitePlayer, new Vector(2, 1));
            Bishop bishop1 = new Bishop(WhitePlayer, new Vector(3, 1));
            Queen queen1 = new Queen(WhitePlayer, new Vector(4, 1));
            King king1 = new King(WhitePlayer, new Vector(5, 1));
            Bishop bishop2 = new Bishop(WhitePlayer, new Vector(6, 1));
            Knight knight2 = new Knight(WhitePlayer, new Vector(7, 1));
            Rook rook2 = new Rook(WhitePlayer, new Vector(8, 1));
            Pawn pawn1 = new Pawn(WhitePlayer, new Vector(1, 2));
            Pawn pawn2 = new Pawn(WhitePlayer, new Vector(2, 2));
            Pawn pawn3 = new Pawn(WhitePlayer, new Vector(3, 2));
            Pawn pawn4 = new Pawn(WhitePlayer, new Vector(4, 2));
            Pawn pawn5 = new Pawn(WhitePlayer, new Vector(5, 2));
            Pawn pawn6 = new Pawn(WhitePlayer, new Vector(6, 2));
            Pawn pawn7 = new Pawn(WhitePlayer, new Vector(7, 2));
            Pawn pawn8 = new Pawn(WhitePlayer, new Vector(8, 2));
            Rook rook3 = new Rook(BlackPlayer, new Vector(1, 8));
            Knight knight3 = new Knight(BlackPlayer, new Vector(2, 8));
            Bishop bishop3 = new Bishop(BlackPlayer, new Vector(3, 8));
            Queen queen2 = new Queen(BlackPlayer, new Vector(4, 8));
            King king2 = new King(BlackPlayer, new Vector(5, 8));
            Bishop bishop4 = new Bishop(BlackPlayer, new Vector(6, 8));
            Knight knight4 = new Knight(BlackPlayer, new Vector(7, 8));
            Rook rook4 = new Rook(BlackPlayer, new Vector(8, 8));
            Pawn pawn9 = new Pawn(BlackPlayer, new Vector(1, 7));
            Pawn pawn10 = new Pawn(BlackPlayer, new Vector(2, 7));
            Pawn pawn11 = new Pawn(BlackPlayer, new Vector(3, 7));
            Pawn pawn12 = new Pawn(BlackPlayer, new Vector(4, 7));
            Pawn pawn13 = new Pawn(BlackPlayer, new Vector(5, 7));
            Pawn pawn14 = new Pawn(BlackPlayer, new Vector(6, 7));
            Pawn pawn15 = new Pawn(BlackPlayer, new Vector(7, 7));
            Pawn pawn16 = new Pawn(BlackPlayer, new Vector(8, 7));
            this.ChessBoard = new Dictionary<Vector, Piece>
            {
                {rook1.Position, rook1},
                {rook2.Position,rook2},
                {rook3.Position, rook3},
                {rook4.Position, rook4},
                {bishop1.Position, bishop1},
                {bishop2.Position, bishop2},
                {bishop3.Position, bishop3},
                {bishop4.Position, bishop4},
                {knight1.Position,knight1},
                {knight2.Position,knight2},
                {knight3.Position,knight3},
                {knight4.Position,knight4},
                {queen1.Position, queen1},
                {queen2.Position, queen2},
                {king1.Position,knight1},
                {king2.Position,knight2},
                {pawn1.Position,pawn1},
                {pawn2.Position,pawn2},
                {pawn3.Position,pawn3},
                {pawn4.Position,pawn4},
                {pawn5.Position,pawn5},
                {pawn6.Position,pawn6},
                {pawn7.Position,pawn7},
                {pawn8.Position,pawn8},
                {pawn9.Position,pawn9},
                {pawn10.Position,pawn10},
                {pawn11.Position,pawn11},
                {pawn12.Position,pawn12},
                {pawn13.Position,pawn13},
                {pawn14.Position,pawn14},
                {pawn15.Position,pawn15},
                {pawn16.Position,pawn16}
            };
            Users = users;
            Users.Add(WhitePlayer);
            Users.Add(BlackPlayer);
        }

    }




}

