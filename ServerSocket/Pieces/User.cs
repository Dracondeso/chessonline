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
        public bool IsWhite { get; set; }
        public string RoomKey { get; private set; }
        public User() { }
        public string StartPosition;
        public string EndPosition;
        public void SetRoomKey(string roomKey, bool isWhite)
        {

            this.IsWhite = isWhite;
            this.RoomKey = roomKey;
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
            return "UserName= "+ this.UserName + " Password= " + this.Password;
        }


    }
}