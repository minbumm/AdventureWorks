using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minbumm.Advs.Win.WinApp
{
    public partial class SocketServerForm : Form
    {

        delegate void SetMessageCallback(string text);
        delegate void ClientDateBindCallback();

        //ServerSocketManager serverSocket;

        public SocketServerForm()
        {
            InitializeComponent();
        }

        private void SocketServerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
