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
        public List<User> Users;
        public Room(string name)
        {
            this.Board = new Board();
            this.Users = new List<User>();
            this.Name = name;
        }
    }


}
