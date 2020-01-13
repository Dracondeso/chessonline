using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessOnline
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsWhite { get; set; }
        public string RoomKey { get; private set; }
        public void SetRoomKey(string roomKey)
        {
            this.RoomKey = roomKey;
        }


     
    }
}