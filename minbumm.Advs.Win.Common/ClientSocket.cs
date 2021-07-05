using System;
using System.Collections.Generic;
using System.Linq;
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

        
    }
}
