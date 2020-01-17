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
       public List<User> Users = new List<User>();
        public string Name;
        public Room(string name)
        {
            this.Name = name;
            User white = new User();
            User black = new User();
            white.SetRoomKey(this.Name, true);
            black.SetRoomKey(this.Name, false);
            Users = new List<User>();
            Users.Add(white);
            Users.Add(black);
        }
    }


}
