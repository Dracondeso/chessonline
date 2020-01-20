using Server;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
namespace ChessOnline
{
    public class Room
    {
        public string Name;
        public Board Board;
        public Room(string name)
        {
        List<User> Users = new List<User>();
            this.Name = name;
            User white = new User();
            User black = new User();
            white.SetRoomKey(this, Server.Enum.Side.White);
            black.SetRoomKey(this, Server.Enum.Side.Black);
            Users = new List<User>();
            Users.Add(white);
            Users.Add(black);
         this.Board= new Board(Users);
        }
    }


}
