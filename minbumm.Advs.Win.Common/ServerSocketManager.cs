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


    }
}
