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
        public Vector StartPosition { get;  set; }
        public Vector EndPosition { get;  set; }
        public Side Side { get; set; }
        public bool FirstMove { get; set; }
        public List<Vector> Checks;
        public Board Board;
        public double[] DirectionSteps;
        public double North;
        public double South;
        public double East;
        public double West;
        public double NorthEast;
        public double NorthWest;
        public double SouthEast;
        public double SouthWest;

        public Piece( Side side, Vector startPosition, Board board )
        {
            this.Board = board;
            Side = side;
            StartPosition = startPosition;
            FirstMove = true;
        }
        public virtual List<Vector> Move()
        {
            if (this.Checks == null){

            this.Checks = new List<Vector>();
            }
            this.Checks.Clear();

            this.North = 8 - this.StartPosition.Y;
            this.South = 0 + this.StartPosition.Y;
            this.East = 8 - this.StartPosition.X;
            this.West = 0 + this.StartPosition.X;
            double piecePosition;
            if (this.StartPosition.X <= this.StartPosition.Y)
            { 
                piecePosition = this.StartPosition.X; 
            }
            else
            {
                piecePosition = StartPosition.Y;
            }
            this.NorthEast = 8 - piecePosition;
            this.NorthWest = 1 - piecePosition;
            this.SouthEast = 8 - piecePosition;
            this.SouthWest = 1 - piecePosition;
            return Core.Behavior(this.StartPosition,this.Board);
        }

    }
}

