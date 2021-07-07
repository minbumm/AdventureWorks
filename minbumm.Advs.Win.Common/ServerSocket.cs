using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace minbumm.Advs.Win.Common
{
    /// <summary>
    /// https://msdn.microsoft.com/ko-kr/library/fx6588te(v=vs.110).aspx
    /// </summary>
    public class ServerSocket
    {
        public delegate void OnAcceptEvenHandler(ClientSocket sender);
        public event OnAcceptEvenHandler OnAccept;
        public delegate void OnDisconnectionEventHandler(ClientSocket sender);
        public event OnDisconnectionEventHandler OnDisconnect;


        public static ManualResetEvent allDone = new ManualResetEvent(false);
        private bool listeningFlag = true;

        // The port number for the remote device
    }
}
