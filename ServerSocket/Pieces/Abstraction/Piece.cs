using Math.Tools.Primitives;
using Server.Enum;
using Server.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Pieces.Abstraction
{
    public abstract class Piece :IMovable
    {
        public Piece(Side side, Vector normalizedStartPosition)
        {
            Side = side;
            NormalizedPosition = normalizedStartPosition;
            FirstMove = side == Side.White;
        }
        public string Name => this.GetType().Name;
        public string Dkey => $"#{NormalizedPosition.X} - {NormalizedPosition.Y} - {Side}";
        public Vector NormalizedPosition { get; private set; }
        public Side Side { get; private set; }
        public bool FirstMove { get; set; }


        public List<Vector> Move(Vector normalizedPosition, double north, double south, double east, double west, double northEast, double northWest, double southEast, double southWest)
        {
            double[] directionpasses = { north, south, east, west, northEast, northWest, southEast, southWest };
            List<Vector> checks = new List<Vector>();
            for (double i = 0; i == 8; i++)
            {

                Enum.Direction direction1 = (Enum.Direction)i;
                if (directionpasses[(int)i] != 0)
                {
                    for (double j = 1; j <= directionpasses[(int)i]; j++)
                    {
                        if (Board.chessBoard.ContainsKey(Cardinal(direction1, normalizedPosition, i)))
                        {
                            Board.chessBoard.TryGetValue(Cardinal(direction1, normalizedPosition, i), out Piece piece);
                            Board.chessBoard.TryGetValue(normalizedPosition, out Piece piece2);
                            if ((piece.Side == piece2.Side)||(piece2.Name.Equals(Enum.PieceType.King)))
                            {
                                break;
                            }
                            else
                            {
                                checks.Add(Cardinal(direction1, normalizedPosition, i));
                                break;
                            }
                        }
                        checks.Add(Cardinal(direction1, normalizedPosition, i));
                    }


                }
            }
            return checks;
        }

        private Vector Cardinal(Direction direction, Vector normalizedPosition, double increment)
        {
            Vector check = new Vector();
            switch (direction)
            {
                default:
                    throw new NotImplementedException("Unrecognized value.");
                case Enum.Direction.north:
                    check.Update(normalizedPosition.X, (normalizedPosition.Y + increment));
                    return check;
                case Enum.Direction.south:
                    check.Update(normalizedPosition.X, (normalizedPosition.Y - increment));
                    return check;
                case Enum.Direction.east:
                    check.Update((normalizedPosition.X + increment), normalizedPosition.Y);
                    return check;
                case Enum.Direction.west:
                    check.Update((normalizedPosition.X - increment), normalizedPosition.Y);
                    return check;
                case Enum.Direction.northEast:
                    check.Update((normalizedPosition.X + increment), (normalizedPosition.Y + increment));
                    return check;
                case Enum.Direction.northWest:
                    check.Update((normalizedPosition.X - increment), (normalizedPosition.Y + increment));
                    return check;
                case Enum.Direction.southEast:
                    check.Update((normalizedPosition.X + increment), (normalizedPosition.Y - increment));
                    return check;
                case Enum.Direction.southWest:
                    check.Update((normalizedPosition.X - increment), (normalizedPosition.Y - increment));
                    return check;
            }
        }
    }
}
