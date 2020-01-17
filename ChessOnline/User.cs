using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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
        public string StartPosition;
        public string EndPosition;
        public bool IsWhite { get; set; }
        public string RoomKey { get; private set; }
        public override string ToString()
        {
            return "UserName= "+ this.UserName + " Password= " + this.Password;
        }
        public void SetMove(User user)
        {
            this.StartPosition = user.StartPosition;
            this.EndPosition = user.EndPosition;
        }
    }
}