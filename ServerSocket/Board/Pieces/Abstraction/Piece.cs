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
        public Vector Position { get;  set; }
        public Side Side { get; set; }
        public bool FirstMove { get; set; }
        public User User;
        public List<Vector> Checks;
        public double North;
        public double South;
        public double East;
        public double West;
        public double NorthEast;
        public double NorthWest;
        public double SouthEast;
        public double SouthWest;
        public double[] DirectionSteps;
        public virtual List<Vector> Move()
        {
            if (this.Checks == null){

            this.Checks = new List<Vector>();
            }
            
            this.North = 8 - this.Position.Y;
            this.South = 0 + this.Position.Y;
            this.East = 8 - this.Position.X;
            this.West = 0 + this.Position.X;
            double piecePosition;
            if (this.Position.X <= this.Position.Y)
            { 
                piecePosition = this.Position.X; 
            }
            else
            {
                piecePosition = Position.Y;
            }
            this.NorthEast = 8 - piecePosition;
            this.NorthWest = 1 - piecePosition;
            this.SouthEast = 8 - piecePosition;
            this.SouthWest = 1 - piecePosition;
            return Core.Move(this.User);
        }
        public Piece(User user, Vector position)
        {
            User = user;
            Position = position;
            FirstMove = true;
        }

    }
}

