using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minbumm.Advs.Win.WinApp.Printer
{
    public partial class fmLabelSerial : Form
    {
        //프린트 제어 문자
        string PRINT_CUT = Encoding.Default.GetString(new byte[] { 0, 0, 0, 0 });    //Feed + Cut

        public fmLabelSerial()
        {
            InitializeComponent();

        private void fmLabelSerial_Load(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string s = String.Format(@"");
                byte[] buffer = new byte[2048];

                buffer = Encoding.Default.GetBytes(s);

                SerialPort port = new SerialPort(cboSerialPort.Text, 9600, Parity.None, 8, StopBits.One);

                if (!port.IsOpen) port.Open();

                port.Write(buffer, 0, buffer.Length);
                port.Close();
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("선택한 포트 " + cboSerialPort.Text + "가 연결되지 않았습니다.", "오류");
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
