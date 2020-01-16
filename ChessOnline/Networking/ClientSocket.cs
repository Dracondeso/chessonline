using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Text;

namespace ChessOnline.Networking
{

    public class ClientSocket
    {
        // Establish the remote endpoint for the socket. 
        // This example uses port 11000 on the local computer. 

        private static IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        private static IPAddress ipAddress = ipHostInfo.AddressList[1];
        private static IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

        public static Socket Sender = new Socket(ipAddress.AddressFamily,
        // Create a TCP/IP  socket.  
        // Connect the socket to the remote endpoint. Catch any errors.  
                        SocketType.Stream, ProtocolType.Tcp);
        public static Socket StartClient()
        {
            // Connect to a remote device.  
            try
            {
                Sender.Connect(remoteEP);

                Console.WriteLine("Socket connected to {0}",
                    Sender.RemoteEndPoint.ToString());

                //// Encode the data string into a byte array.  
                //byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");

                //// Send the data through the socket.  
                //int bytesSent = sender.Send(msg);

                //// Receive the response from the remote device.  
                //int bytesRec = sender.Receive(bytes);
                //Console.WriteLine("Echoed test = {0}",
                //    Encoding.ASCII.GetString(bytes, 0, bytesRec));

                //// Release the socket.  
                //sender.Shutdown(SocketShutdown.Both);
                return Sender;
            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                return null;

            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
                return null;

            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
                return null;

            }

        }
        public static void SendMsg(string message)
        {

            byte[] bytes = new byte[1024];

            byte[] msg = Encoding.ASCII.GetBytes(message);

            // Send the data through the socket.  
            int bytesSent = Sender.Send(msg);
        }
        public static void Disconnect(Socket sender)
        {
            // Release the socket.  
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
        public static string ReceiveMsg()
        {
            byte[] bytes = new byte[1024];

            // Receive the response from the remote device.  
            int bytesRec = ClientSocket.StartClient().Receive(bytes);
            Console.WriteLine("Echoed test = {0}",
                    Encoding.ASCII.GetString(bytes, 0, bytesRec));
            return Encoding.ASCII.GetString(bytes, 0, bytesRec);
        }
        public static void StartListening()
        {

        }

    }


}
