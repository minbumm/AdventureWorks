using minbumm.Advs.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
        }
        private void StartListening() 
        {
            //Data buffer for incoming data.
            byte[] bytes = new byte[1024];

            //Establish the local endpoint for the socket.
            //The DNS name of the computer
            //running the listener is "host.contoso.com"

        }
    }
}

