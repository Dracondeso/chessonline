using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessOnline
{
    public class User
    {
        string UserName { get; set; }
        string Password { get; set; }
        public bool IsWhite { get; set; }
        public string RoomKey { get; private set; }
        public void SetRoomKey(string roomKey)
                    {
            this.RoomKey = roomKey;
        }
    }
}
