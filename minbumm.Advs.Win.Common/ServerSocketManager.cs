using minbumm.Advs.DataModel;
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
    /// <summary>
    /// https://msdn.microsoft.com/ko-kr/library/fx6588te(v=vs.110).aspx
    /// </summary>
    public class ServerSocketManager
    {
        public delegate void OnAcceptEvenHandler(ClientSocket sender);
        public event OnAcceptEvenHandler OnAccept;
        public delegate void OnDisconnectionEventHandler(ClientSocket sender);
        public event OnDisconnectionEventHandler OnDisconnect;


        public static ManualResetEvent allDone = new ManualResetEvent(false);
        private bool listeningFlag = true;

        //The port number for the remote device
        private int port = Constants.DEFAULT_SOCKET_PORT;
        private string tcpServerIP = string.Empty;
        private Encoding encoding = Encoding.Default;

        //The response from the remote device
        private string response = string.Empty;

        //Client soceket define
        Socket serverSocket = null;
        List<ClientSocket> clients = new List<ClientSocket>();
        Thread sockT = null;


        public List<ClientSocket> Clients { get => clients; set => clients = value; }
        public Socket ServerSocket { get => serverSocket; set => serverSocket = value; }

        
        Timer timer = null;

        public ServerSocketManager() 
        {
            //CREATE a TCP/IP Socket
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            timer = new Timer(new TimerCallback(CheckClientSocketState), null, 10000 , 10000 );
        }
        public void CheckClientSocketState(object state) 
        {
            List<ClientSocket> removingClients = null;
            if (Clients.Count > 0)
            {
                foreach (var client in clients)
                {
                    if (!client.Connected)
                    {
                        if (removingClients == null)
                        {
                            removingClients = new List<ClientSocket>();
                        }
                        removingClients.Add(client);

                        continue;
                    }
                    client.Send($"{DateTime.Now.ToString()}:ping:<EOF>");
                }
            }
            if (removingClients != null && removingClients.Count > 0)
            {
                foreach (var client in removingClients)
                {
                    clients.Remove(client);

                    if (OnDisconnect != null)
                    {
                        OnDisconnect(client);
                    }
                }
            }

        }

        public ServerSocketManager(int port) : this() 
        {
            this.port = port;
        }

        public ServerSocketManager(Encoding encoding) : this()
        {
            this.encoding = encoding;
            this.port = port;
        }
        public void Start()
        {
            Thread sockT = new Thread(new ThreadStart(StartListening));
            sockT.Start();
        }

        public void Stop()
        {
            StopListening();

            foreach (var client in Clients)
            {
                client.Close();
            }

            Clients.Clear();
        }

        public void AddClient(ClientSocket client)
        {
            client.OnDisconnect += Client_OnDisconnect;
            Clients.Add(client);
        }

        private void Client_OnDisconnect(ClientSocket sender)
        {
            RemoveClient(sender);
            if (OnDisconnect != null)
                OnDisconnect(sender);
        }

        public void RemoveClient(ClientSocket client)
        {
            if (Clients.Contains(client))
            {
                client.Close();
                Clients.Remove(client);
            }
        }

        private void StartListening()
        {
            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.
            // The DNS name of the computer
            // running the listener is "host.contoso.com".
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList.Where(a => a.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault();
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);
            listeningFlag = true;

            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                ServerSocket.Bind(localEndPoint);
                ServerSocket.Listen(100);

                while (listeningFlag)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.
                    Debug.WriteLine("Waiting for a connection...");
                    ServerSocket.BeginAccept(
                        new AsyncCallback(AcceptCallback),
                        ServerSocket);

                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw ex;
            }

        }
        private void StopListening()
        {
            listeningFlag = false;
            allDone.Set();
            sockT = null;

        }

        private void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();

            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            if (OnAccept != null)
            {
                //OnAccept(handler);
            }

        }

    }

    // State object for receiving data from remote device
    public class ServerSocketStateObject
    {
        // Client socket
        public Socket workSocket = null;
        // Size of receive buffer
        public const int BufferSize = 1024;
        // Receive buffer
        public byte[] buffer = new byte[BufferSize];
        // Receiving data string
        public StringBuilder sb = new StringBuilder();
    }
}

