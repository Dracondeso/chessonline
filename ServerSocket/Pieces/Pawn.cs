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
        public Pawn(Side side, Vector normalizedStartPosition) : base(side, normalizedStartPosition)
        {
            if (side == Enum.Side.White)
            {
                Vector normalizedStartPosition1 = new Vector((normalizedStartPosition.X + 1), (normalizedStartPosition.Y + 1));
                Vector normalizedStartPosition2 = new Vector((normalizedStartPosition.X - 1), (normalizedStartPosition.Y + 1));
                if (Board.chessBoard.ContainsKey(normalizedStartPosition1))
                {
                    Board.chessBoard.TryGetValue(normalizedStartPosition1, out Piece piece);
                    if (this.Side != piece.Side)
                    {
                        Move(normalizedStartPosition, 0, 0, 0, 0, 1, 0, 0, 0);
                    }
                }
                if (Board.chessBoard.ContainsKey(normalizedStartPosition2))
                {
                    Board.chessBoard.TryGetValue(normalizedStartPosition2, out Piece piece);
                    if (this.Side != piece.Side)
                    {
                        Move(normalizedStartPosition, 0, 0, 0, 0, 0, 1, 0, 0);
                    }
                }
                if (FirstMove == true)
                    Move(normalizedStartPosition, 2, 0, 0, 0, 0, 0, 0, 0);
                if (FirstMove == false)
                    Move(normalizedStartPosition, 1, 0, 0, 0, 1, 1, 0, 0);
            }
            else
            {
                Vector normalizedStartPosition1 = new Vector((normalizedStartPosition.X + 1), (normalizedStartPosition.Y - 1));
                Vector normalizedStartPosition2 = new Vector((normalizedStartPosition.X - 1), (normalizedStartPosition.Y - 1));
                if (Board.chessBoard.ContainsKey(normalizedStartPosition1))
                {
                    Board.chessBoard.TryGetValue(normalizedStartPosition1, out Piece piece);
                    if (this.Side != piece.Side)
                    {
                        Move(normalizedStartPosition, 0, 0, 0, 0, 0, 0, 1, 0);

                    }
                }
                if (Board.chessBoard.ContainsKey(normalizedStartPosition2))
                {
                    Board.chessBoard.TryGetValue(normalizedStartPosition2, out Piece piece);
                    if (this.Side != piece.Side)
                    {
                        Move(normalizedStartPosition, 0, 0, 0, 0, 0, 0, 0, 1);

                    }
                    if (FirstMove == true)
                        Move(normalizedStartPosition, 0, 2, 0, 0, 1, 1, 0, 0);
                    if (FirstMove == false)
                        Move(normalizedStartPosition, 0, 1, 0, 0, 0, 0, 1, 1);
                }
            }

        }
    }
}
