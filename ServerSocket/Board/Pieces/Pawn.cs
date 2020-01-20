using ChessOnline;
using Math.Tools.Primitives;
using Server.Enum;
using Server.Pieces.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(User user, Vector position) : base(user, position)
        {
            List<Vector> PawnMove = new List<Vector>();
        }
        public  List<Vector> PawnMoves( Piece pawn)
        {
            pawn..Clear();
            if (pawn.User.Side == Enum.Side.White)
            {
                Vector position1 = new Vector((pawn.Position.X + 1), (pawn.Position.Y + 1));
                Vector position2 = new Vector((pawn.Position.X - 1), (pawn.Position.Y + 1));
                if (pawn.User.Room.Board.ChessBoard.ContainsKey(position1))
                {
                    pawn.User.Room.Board.ChessBoard.TryGetValue(position1, out Piece piece);
                    if (this.Side != piece.Side)
                    {
                       PawnMove.AddRange( Move(0, 0, 0, 0, 1, 0, 0, 0));
                    }
                }
                if (user.Room.Board.ChessBoard.ContainsKey(position2))
                {
                    user.Room.Board.ChessBoard.TryGetValue(position2, out Piece piece);
                    if (this.Side != piece.Side)
                    {
                     return   Move(0, 0, 0, 0, 0, 1, 0, 0);
                    }
                }
                if (FirstMove == true)
                    Move(2, 0, 0, 0, 0, 0, 0, 0);
                if (FirstMove == false)
                    Move(1, 0, 0, 0, 1, 1, 0, 0);
            }
            else
            {
                Vector position1 = new Vector((position.X + 1), (position.Y - 1));
                Vector position2 = new Vector((position.X - 1), (position.Y - 1));
                if (user.Room.Board.ChessBoard.ContainsKey(position1))
                {
                    user.Room.Board.ChessBoard.TryGetValue(position1, out Piece piece);
                    if (this.Side != piece.Side)
                    {
                        Move(0, 0, 0, 0, 0, 0, 1, 0);

                    }
                }
                if (user.Room.Board.ChessBoard.ContainsKey(position2))
                {
                    user.Room.Board.ChessBoard.TryGetValue(position2, out Piece piece);
                    if (this.Side != piece.Side)
                    {
                        Move(0, 0, 0, 0, 0, 0, 0, 1);

                    }
                    if (FirstMove == true)
                        Move(0, 2, 0, 0, 1, 1, 0, 0);
                    if (FirstMove == false)
                        Move(0, 1, 0, 0, 0, 0, 1, 1);
                }
            }

        }
    }
}
