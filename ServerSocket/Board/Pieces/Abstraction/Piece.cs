using ChessOnline;
using Math.Tools.Primitives;
using Server.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Pieces.Abstraction
{
    public abstract class Piece : IMovable
    {
        public string Name => this.GetType().Name;
        //    public string Dkey => $"#{Position.X} - {Position.Y} - {Side}";
        public Vector Position { get; private set; }
        public Side Side { get;  set; }
        public bool FirstMove { get; set; }
        public User User;
        private Vector Cardinal(Direction direction, Vector position, double increment)
        {
            Vector check = new Vector();
            switch (direction)
            {
                default:
                    throw new NotImplementedException("Unrecognized value.");
                case Enum.Direction.north:
                    check.Update(position.X, (position.Y + increment));
                    return check;
                case Enum.Direction.south:
                    check.Update(position.X, (position.Y - increment));
                    return check;
                case Enum.Direction.east:
                    check.Update((position.X + increment), position.Y);
                    return check;
                case Enum.Direction.west:
                    check.Update((position.X - increment), position.Y);
                    return check;
                case Enum.Direction.northEast:
                    check.Update((position.X + increment), (position.Y + increment));
                    return check;
                case Enum.Direction.northWest:
                    check.Update((position.X - increment), (position.Y + increment));
                    return check;
                case Enum.Direction.southEast:
                    check.Update((position.X + increment), (position.Y - increment));
                    return check;
                case Enum.Direction.southWest:
                    check.Update((position.X - increment), (position.Y - increment));
                    return check;
            }
        }
        public Piece(User user, Vector position)
        {
            Side = user.Side;
            Position = position;
            FirstMove = true;
        }
        public List<Vector> MoveChoose(Piece piece)
        {
            switch (piece.Name)
            {
                case "Pawn":
                    return Pawn.PawnMoves();
                case "Bishop":
                case "Knight":
                case "Rook":
                case "Queen":
                case "King":
                default:
                    break;
            }
        }
        }
        public List<Vector> Move(double north, double south, double east, double west, double northEast, double northWest, double southEast, double southWest)
        {
            double[] directionStep = { north, south, east, west, northEast, northWest, southEast, southWest };
            List<Vector> checks = new List<Vector>();
            for (double i = 0; i == 8; i++)
            {
                Enum.Direction direction1 = (Enum.Direction)i;
                if (directionStep[(int)i] != 0)
                {
                    for (double j = 1; j <= directionStep[(int)i]; j++)
                    {
                        if (this.User.Room.Board.ChessBoard.ContainsKey(Cardinal(direction1, this.User.StartPosition, i)))
                        {
                            this.User.Room.Board.ChessBoard.TryGetValue(Cardinal(direction1, this.User.StartPosition, i), out Piece piece);
                            this.User.Room.Board.ChessBoard.TryGetValue(this.User.StartPosition, out Piece piece2);
                            if ((piece.Side == piece2.Side) || (piece2.Name.Equals(Enum.PieceType.King)))
                            {
                                break;
                            }
                            else
                            {
                                checks.Add(Cardinal(direction1, this.User.StartPosition, i));
                                break;
                            }
                        }
                        checks.Add(Cardinal(direction1, this.User.StartPosition, i));
                    }
                }
            }
            return checks;
        }
    }
}
