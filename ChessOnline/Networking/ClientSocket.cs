using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Sockets;
namespace ChessOnline.Networking
{
    public class ClientSocket
    {
        private Socket _socket;
        private byte[] _buffer;
        public ClientSocket()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public void Connect(string ipAddress, int port)
        {
            _socket.BeginConnect(new IPEndPoint(IPAddress.Parse(ipAddress), port), ConnectCallback, null);
        }
        private void ConnectCallback(IAsyncResult result)
        {
            Console.WriteLine("Connected to the server!");
            _buffer = new byte[1024];
            _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceivedCallback, null);
        }
        private void ReceivedCallback(IAsyncResult result)
        {
            int bufLenght = _socket.EndReceive(result);
            byte[] packet = new byte[bufLenght];
            Array.Copy(_buffer, packet, packet.Length);
        }
    }

}
