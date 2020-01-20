﻿using ChessOnline;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;
namespace Server.Networking
{
    public class StateObject
    {
        // Client  socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 1024;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
        User User;
   
        public User UserCreation(string stringToConvert)
        {
            this.User = JsonConvert.DeserializeObject<User>(stringToConvert);
            return User;
        }
    }

}
