using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace minbumm.Advs.Win.Common
{
    public class ClientSocket
    {
        public delegate void OnConnectEvantHandler(ClientSocket sender, bool connected);
        public event OnConnectEvantHandler OnConnect;

        public delegate void OnSendEventHandler(ClientSocket sender, int bytesSent);
        public event OnSendEventHandler OnSend;

        public delegate void OnReceiveEventHandler(ClientSocket sender, string receiveData);
        public event OnReceiveEventHandler OnReceivde;

        public delegate void OnDisconnectEventHandller(ClientSocket sender);
        public event OnDisconnectEventHandller OnDisconnect;

        //The port number for the remote device
        private int port = 10000;
        private Encoding encoding = Encoding.Default; 

        private string tcpServerIP = string.Empty;

        // ManualResetEvent instances signal completion
        private ManualResetEvent connectDone = new ManualResetEvent(false);
        private ManualResetEvent sendDone = new ManualResetEvent(false);
        private ManualResetEvent receiveDone = new ManualResetEvent(false);

        // The reponse from the remote device.
        private string response = string.Empty;

        Socket socket = null;

        public Socket Socket { get => socket; set => socket = value; }

        public bool Connected
        {
            get
            {
                if (Socket != null)
                {
                    return Socket.Connected;
                }
                return false;
            }
        }

        public ClientSocket(string serverIP) 
        {
            // Create a TCP/IP socket
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            tcpServerIP = serverIP;
        }

        public ClientSocket(string serverIP, int remotePort, Encoding encoding) : this(serverIP)  
        {
            port = remotePort;
            this.encoding = encoding;
        }

        public ClientSocket(Socket socket) 
        {
            Socket = socket;
        }

        public void Close() 
        {
            if (Socket != null && Socket.Connected)
            {
                Socket.Shutdown(SocketShutdown.Both);
                Socket.Close();
                Socket = null;
                if (OnDisconnect != null)
                {
                    OnDisconnect(this);
                }
            }
        }




        public void SendAndReceiveMesaage(string sendData) 
        {
            // Establish the remote endpoint for the socket
            // The Ip of the
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(tcpServerIP), port);

            // Connect to the remote endpoint
            Socket.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), Socket);
            connectDone.WaitOne();

            // Send user input data to the remote device.
            sendData += "<EOF>";
            Send(sendData);
            sendDone.WaitOne();

            // Release the socket
            Close();
        }

        private void SendCallback(IAsyncResult ar) 
        {
            try
            {
                // Retrieve the socekt from the state object.
                Socket client = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = client.EndSend(ar);
                if (OnSend != null)
                {
                    OnSend(this, bytesSent);
                }
                sendDone.Set();
            }
            catch (SocketException skex)
            {
                Debug.WriteLine(skex.ToString());
                if (OnDisconnect != null)
                {
                    OnDisconnect(this);
                }
            }
            catch(Exception e) 
            {
                Debug.WriteLine(e.ToString());
            }

        }

        public void Send(string data) 
        {
            //Convert the string data to byte data using ASCII encoding.
            byte[] byteData = encoding.GetBytes(data);
            try
            {
                Socket.BeginSend(byteData, 0, byteData.Length, 0, 
                    new AsyncCallback(SendCallback), Socket);
            }
            catch (SocketException skex)
            {

                Debug.WriteLine(skex.Message);
            }
        }

        private void ConnectCallback(IAsyncResult ar) 
        {
            try
            {
                // Retrieve the socket from the state object
                Socket client = ar.AsyncState as Socket;

                client.EndConnect(ar);
                if (OnConnect != null)
                {
                    OnConnect(this, Connected);
                }
                //Signal that the connection has been made
                connectDone.Set();
            }
            catch (SocketException se)
            {
                Debug.WriteLine("ConnectCallback [SocketException] Error : {0}", se.Message.ToString());
                if (OnDisconnect != null)
                {
                    OnDisconnect(this);
                }

            }
            catch (Exception ex) 
            {
                Debug.Write("ConnectCallback [Exception] Error : {0} ", ex.Message.ToString());
            }

        }
    }
}
