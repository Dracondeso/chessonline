
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using ChessOnline;

// State object for receiving data from remote device.  
public class StateObject
{
    // Client socket.  
    public Socket workSocket = null;
    // Size of receive buffer.  
    public const int BufferSize = 1024;
    // Receive buffer.  
    public byte[] buffer = new byte[BufferSize];
    // Received data string.  
    public StringBuilder sb = new StringBuilder();
}

public class AsynchronousClient

{
    // The port number for the remote device.  
    private const int port = 11000;

    // ManualResetEvent instances signal completion.  
    public static ManualResetEvent allDone = new ManualResetEvent(false);

    private static ManualResetEvent connectDone =
        new ManualResetEvent(false);
    private static ManualResetEvent sendDone =
        new ManualResetEvent(false);
    private static ManualResetEvent receiveDone =
        new ManualResetEvent(false);

    // The response from the remote device.  
    private static String response = String.Empty;

    public static Socket StartClient()
    {
        // Connect to a remote device.  
        try
        {
            // Establish the remote endpoint for the socket.  
            // The name of the   
            // remote device is "host.contoso.com".  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[1];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

            // Create a TCP/IP socket.  
            Socket client = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);
            
            // Connect to the remote endpoint.  
            client.BeginConnect(remoteEP,
                new AsyncCallback(ConnectCallback), client);
            connectDone.WaitOne();
            return client;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            return null;
        }
    }
    public static void StartListening()
    {
        // Establish the local endpoint for the socket.  
        // The DNS name of the computer  
        // running the listener is "host.contoso.com".  
        IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        IPAddress ipAddress = ipHostInfo.AddressList[1];
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

        // Create a TCP/IP socket.  
        Socket listener = new Socket(ipAddress.AddressFamily,
            SocketType.Stream, ProtocolType.Tcp);

        // Bind the socket to the local endpoint and listen for incoming connections.  
        try
        {
            listener.Bind(localEndPoint);
            listener.Listen(100);

            while (true)
            {
                // Set the event to nonsignaled state.  
                allDone.Reset();

                // Start an asynchronous socket to listen for connections.  
                Console.WriteLine("Waiting for a connection...");
                listener.BeginAccept(
                    new AsyncCallback(AcceptCallback),
                    listener);

                // Wait until a connection is made before continuing.  
                allDone.WaitOne();

            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        Console.WriteLine("\nPress ENTER to continue...");
        Console.Read();

    }
    public static void AcceptCallback(IAsyncResult ar)
    {
        // Signal the main thread to continue.  
        allDone.Set();

        // Get the socket that handles the client request.  
        Socket listener = (Socket)ar.AsyncState;
        Socket handler = listener.EndAccept(ar);

        // Create the state object.  
        StateObject state = new StateObject();
        state.workSocket = handler;
        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
            new AsyncCallback(ReadCallback), state);
    }
    public static void ReadCallback(IAsyncResult ar)
    {
        string dataRead = string.Empty;

        // Retrieve the state object and the handler socket  
        // from the asynchronous state object.  
        StateObject state = (StateObject)ar.AsyncState;
        Socket handler = state.workSocket;

        // Read data from the client socket.   
        int bytesRead = handler.EndReceive(ar);

        if (bytesRead > 0)
        {
            // There  might be more data, so store the data received so far.  
            state.sb.Append(Encoding.ASCII.GetString(
                state.buffer, 0, bytesRead));

            // Check for end-of-file tag. If it is not there, read   
            // more data.  
            dataRead = state.sb.ToString();

            if (dataRead.IndexOf("<EOF>") > -1)
            {
                // All the data has been read from the   
                // client. Display it on the console.  
                Console.WriteLine("Read {0} bytes from socket. \n Data : {1}",
                    dataRead.Length, dataRead);
                // Echo the data back to the client.  
                Send(handler, dataRead);
            }
            else
            {
                // Not all data received. Get more.  
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
            }
        }
    }

    private static void ConnectCallback(IAsyncResult ar)
    {
        try
        {
            // Retrieve the socket from the state object.  
            Socket client = (Socket)ar.AsyncState;

            // Complete the connection.  
            client.EndConnect(ar);

            Console.WriteLine("Socket connected to {0}",
                client.RemoteEndPoint.ToString());

            // Signal that the connection has been made.  
            connectDone.Set();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public static void Receive(Socket client)
    {
        try
        {
            // Create the state object.  
            StateObject state = new StateObject();
            state.workSocket = client;

            // Begin receiving the data from the remote device.  
            client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReceiveCallback), state);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    private static void ReceiveCallback(IAsyncResult ar)
    {
        try
        {
            // Retrieve the state object and the client socket   
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket client = state.workSocket;

            // Read data from the remote device.  
            int bytesRead = client.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There might be more data, so store the data received so far.  
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                // Get the rest of the data.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            else
            {
                // All the data has arrived; put it in response.  
                if (state.sb.Length > 1)
                {
                    response = state.sb.ToString();
                    Console.WriteLine(response);
                }
                // Signal that all bytes have been received.  
                receiveDone.Set();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public static void Send(Socket client, String data)
    {
        // Convert the string data to byte data using ASCII encoding.  
        byte[] byteData = Encoding.ASCII.GetBytes(data);

        // Begin sending the data to the remote device.  
        client.BeginSend(byteData, 0, byteData.Length, 0,
            new AsyncCallback(SendCallback), client);
    }

    private static void SendCallback(IAsyncResult ar)
    {
        try
        {
            // Retrieve the socket from the state object.  
            Socket client = (Socket)ar.AsyncState;

            // Complete sending the data to the remote device.  
            int bytesSent = client.EndSend(ar);
            Console.WriteLine("Sent {0} bytes to server.", bytesSent);

            // Signal that all bytes have been sent.  
            sendDone.Set();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    //public static int Main(String[] args)
    //{
    //    StartClient();
    //    return 0;
    //}
}






































//using System;
//using System.Net;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Net.Sockets;
//using System.Text;

//namespace ChessOnline.Networking
//{

//    public class ClientSocket
//    {
//        // Establish the remote endpoint for the socket. 
//        // This example uses port 11000 on the local computer. 

//        private static IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
//        private static IPAddress ipAddress = ipHostInfo.AddressList[1];
//        private static IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

//        public static Socket Sender = new Socket(ipAddress.AddressFamily,
//        // Create a TCP/IP  socket.  
//        // Connect the socket to the remote endpoint. Catch any errors.  
//                        SocketType.Stream, ProtocolType.Tcp);

//        public static Socket StartClient()
//        {
//            // Connect to a remote device.  
//            try
//            {
//                Sender.Connect(remoteEP);

//                Console.WriteLine("Socket connected to {0}",
//                    Sender.RemoteEndPoint.ToString());

//                //// Encode the data string into a byte array.  
//                //byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");

//                //// Send the data through the socket.  
//                //int bytesSent = sender.Send(msg);

//                //// Receive the response from the remote device.  
//                //int bytesRec = sender.Receive(bytes);
//                //Console.WriteLine("Echoed test = {0}",
//                //    Encoding.ASCII.GetString(bytes, 0, bytesRec));

//                //// Release the socket.  
//                //sender.Shutdown(SocketShutdown.Both);
//                return Sender;
//            }
//            catch (ArgumentNullException ane)
//            {
//                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
//                return null;

//            }
//            catch (SocketException se)
//            {
//                Console.WriteLine("SocketException : {0}", se.ToString());
//                return null;

//            }
//            catch (Exception e)
//            {
//                Console.WriteLine("Unexpected exception : {0}", e.ToString());
//                return null;

//            }

//        -}
//        public static void SendMsg(string message)
//        {

//            byte[] bytes = new byte[1024];

//            byte[] msg = Encoding.ASCII.GetBytes(message);

//            // Send the data through the socket.  
//           Sender.Send(msg);
//            int totalBytesReceived = Sender.Receive(bytes);
//        }
//        public static void Disconnect(Socket sender)
//        {
//            // Release the socket.  
//            sender.Shutdown(SocketShutdown.Both);
//            sender.Close();
//        }
//        public static string ReceiveMsg()
//        {
//            byte[] bytes = new byte[1024];

//            // Receive the response from the remote device.  
//            int bytesRec = ClientSocket.StartClient().Receive(bytes);
//            Console.WriteLine("Echoed test = {0}",
//                    Encoding.ASCII.GetString(bytes, 0, bytesRec));
//            return Encoding.ASCII.GetString(bytes, 0, bytesRec);
//        }
//        public static void StartListening()
//        {

//        }

//    }


//}
