using Math.Tools.Primitives;
using Server.Enum;
using Server.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Pieces.Abstraction
{
    public abstract class Piece : IMovable
    {
        public Piece(Side side,  Vector normalizedStartPosition)
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

        public abstract void Move();

        //public Piece SwitchSide()
        //{
        //    Vector coefficent = new Vector(0, 8 - Position.Y);
        //    if (Side == Side.White)
        //    {
        //        Position.Sum(coefficent);
        //        Side = Side.Black;
        //    }
        //    else
        //    {
        //        Position.Subtract(coefficent);
        //        Side = Side.White;
        //    }
        //    return this;
        //}
    }
}
