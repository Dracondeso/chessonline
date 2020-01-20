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
        }
        public override void Move()
        {
            base.Move();
            if (this.Side == Enum.Side.White)
            {
                Vector position1 = new Vector((this.Position.X + 1), (this.Position.Y + 1));
                Vector position2 = new Vector((this.Position.X - 1), (this.Position.Y + 1));
                Vector position3 = new Vector((this.Position.X), (this.Position.Y + 1));
                Vector position4 = new Vector((this.Position.X), (this.Position.Y + 2));
                if (this.User.Room.Board.ChessBoard.ContainsKey(position1))
                {
                    this.User.Room.Board.ChessBoard.TryGetValue(position1, out Piece piece);
                    if (this.Side != piece.Side)
                    {
                        this.NorthEast = 1;
                    }
                    else
                        this.NorthEast = 0;
                }
                if (this.User.Room.Board.ChessBoard.ContainsKey(position2))
                {
                    this.User.Room.Board.ChessBoard.TryGetValue(position2, out Piece piece);
                    if (this.Side != piece.Side)
                    {
                        this.NorthWest = 1;
                    }
                    else
                        this.NorthWest = 0;
                }
                this.North = 0;
                if (!this.User.Room.Board.ChessBoard.ContainsKey(position3))
                {
                    if (!this.User.Room.Board.ChessBoard.ContainsKey(position4) && FirstMove == true)
                    {
                        this.North = 2;
                    }
                    if (this.Position.Y < 8)
                    {
                        this.North = 1;
                    }
                }
                this.SouthEast = 0;
                this.South = 0;
                this.SouthWest = 0;
            }
            else
            {
                Vector position1 = new Vector((this.Position.X + 1), (this.Position.Y - 1));
                Vector position2 = new Vector((this.Position.X - 1), (this.Position.Y - 1));
                Vector position3 = new Vector((this.Position.X), (this.Position.Y - 1));
                Vector position4 = new Vector((this.Position.X), (this.Position.Y - 2));
                if (this.User.Room.Board.ChessBoard.ContainsKey(position1))
                {
                    this.User.Room.Board.ChessBoard.TryGetValue(position1, out Piece piece);
                    if (this.Side != piece.Side)
                    {
                        this.SouthEast = 1;
                    }
                    else
                        this.SouthEast = 0;
                }
                if (this.User.Room.Board.ChessBoard.ContainsKey(position2))
                {
                    this.User.Room.Board.ChessBoard.TryGetValue(position2, out Piece piece);
                    if (this.Side != piece.Side)
                    {
                        this.SouthWest = 1;
                    }
                    else
                        this.SouthWest = 0;
                    if (!this.User.Room.Board.ChessBoard.ContainsKey(position4) && FirstMove == true)
                        this.South = 2;
                    if (FirstMove == false)
                        this.South = 1;

                    if (!this.User.Room.Board.ChessBoard.ContainsKey(position3))
                    {
                        if (!this.User.Room.Board.ChessBoard.ContainsKey(position3) && !this.User.Room.Board.ChessBoard.ContainsKey(position4) && FirstMove == true)
                        {
                            this.South = 2;
                        }
                        if ((this.Position.Y < 8) && !this.User.Room.Board.ChessBoard.ContainsKey(position3))
                        {
                            this.South = 1;
                        }
                        else
                            this.SouthEast = 0;
                        this.NorthEast = 0;
                    }
                    this.North = 0;
                    this.NorthWest = 0;
                }
            }
        }
    }
}
