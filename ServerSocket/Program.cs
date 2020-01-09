using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
namespace Server
{
    public static class Program
    {
        static List<string> pippo = new List<string>();
        private static void Main(String[] args)
        {
           AsynchronousSocketListener.StartListening();
        }
    }
}
