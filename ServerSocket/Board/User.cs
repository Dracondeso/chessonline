using Math.Tools.Primitives;
using Server.Enum;
using Server.Networking;
using Server.Pieces.Abstraction;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
namespace ChessOnline
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Side Side { get; set; }
        public bool YourTurn { get; set; }
        public Dictionary<Vector, Piece> ChessBoard;
        public User() { }
        public Vector StartPosition;
        public Vector EndPosition;
        public string RoomKey;
        public void SetRoomKey(Room room, Side side)
        {
            this.ChessBoard = room.Board.ChessBoard;
            this.Side = side;
            this.RoomKey = room.Name;
        }
        public void SetUser(User user)
        {
            this.UserName = user.UserName;
            this.Password = user.Password;
        }
        public void SetMove(User user)
        {
            this.StartPosition = user.StartPosition;
            this.EndPosition = user.EndPosition;
        }
        public override string ToString()
        {
            return "UserName= " + this.UserName + " Password= " + this.Password;
        }
    }
}