
namespace minbumm.Advs.Win.WinApp.Printer
{
    partial class fmLabelSerial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
<<<<<<< HEAD
            this.cboSerialPort = new System.Windows.Forms.ComboBox();
=======
            this.comboBox1 = new System.Windows.Forms.ComboBox();
>>>>>>> f568dd9a9e6fef02d952a157c74ed9a7d3c5f710
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port 번호 선택";
            // 
<<<<<<< HEAD
            // cboSerialPort
            // 
            this.cboSerialPort.FormattingEnabled = true;
            this.cboSerialPort.Items.AddRange(new object[] {
=======
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
>>>>>>> f568dd9a9e6fef02d952a157c74ed9a7d3c5f710
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
<<<<<<< HEAD
            this.cboSerialPort.Location = new System.Drawing.Point(105, 13);
            this.cboSerialPort.Name = "cboSerialPort";
            this.cboSerialPort.Size = new System.Drawing.Size(121, 23);
            this.cboSerialPort.TabIndex = 1;
=======
            this.comboBox1.Location = new System.Drawing.Point(105, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 1;
>>>>>>> f568dd9a9e6fef02d952a157c74ed9a7d3c5f710
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(233, 13);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
<<<<<<< HEAD
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
=======
>>>>>>> f568dd9a9e6fef02d952a157c74ed9a7d3c5f710
            // 
            // fmLabelSerial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 43);
            this.Controls.Add(this.btnPrint);
<<<<<<< HEAD
            this.Controls.Add(this.cboSerialPort);
            this.Controls.Add(this.label1);
            this.Name = "fmLabelSerial";
            this.Text = "fmLabelSerial";
            this.Load += new System.EventHandler(this.fmLabelSerial_Load);
=======
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "fmLabelSerial";
            this.Text = "fmLabelSerial";
>>>>>>> f568dd9a9e6fef02d952a157c74ed9a7d3c5f710
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
<<<<<<< HEAD
        private System.Windows.Forms.ComboBox cboSerialPort;
=======
        private System.Windows.Forms.ComboBox comboBox1;
>>>>>>> f568dd9a9e6fef02d952a157c74ed9a7d3c5f710
        private System.Windows.Forms.Button btnPrint;
    }
}