using Math.Tools.Primitives;
using Server.Enum;
using Server.Networking;
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
        public Room Room { get; private set; }
        public User() { }
        public Vector StartPosition;
        public Vector EndPosition;
        public StateObject StateObject;
        public void SetRoomKey(Room room, Side side)
        {
            this.Side = side;
            this.Room = room;
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
        public void SetStateObject(StateObject stateObject)
        {
            this.StateObject = stateObject;
        }
    }
}