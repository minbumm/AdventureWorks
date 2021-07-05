
namespace minbumm.Advs.Win.WinApp
{
    partial class SocketServerForm
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
            this.listClient = new System.Windows.Forms.ListBox();
            this.listHost = new System.Windows.Forms.ListBox();
            this.txtCmdMsg = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listClient
            // 
            this.listClient.FormattingEnabled = true;
            this.listClient.ItemHeight = 12;
            this.listClient.Location = new System.Drawing.Point(12, 32);
            this.listClient.Name = "listClient";
            this.listClient.Size = new System.Drawing.Size(120, 88);
            this.listClient.TabIndex = 0;
            // 
            // listHost
            // 
            this.listHost.FormattingEnabled = true;
            this.listHost.ItemHeight = 12;
            this.listHost.Location = new System.Drawing.Point(155, 32);
            this.listHost.Name = "listHost";
            this.listHost.Size = new System.Drawing.Size(120, 88);
            this.listHost.TabIndex = 1;
            // 
            // txtCmdMsg
            // 
            this.txtCmdMsg.Location = new System.Drawing.Point(299, 13);
            this.txtCmdMsg.Name = "txtCmdMsg";
            this.txtCmdMsg.Size = new System.Drawing.Size(181, 21);
            this.txtCmdMsg.TabIndex = 2;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(486, 13);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 3;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 126);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(548, 277);
            this.textBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "label1";
            // 
            // SocketServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtCmdMsg);
            this.Controls.Add(this.listHost);
            this.Controls.Add(this.listClient);
            this.Name = "SocketServerForm";
            this.Text = "SocketServerForm";
            this.Load += new System.EventHandler(this.SocketServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listClient;
        private System.Windows.Forms.ListBox listHost;
        private System.Windows.Forms.TextBox txtCmdMsg;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}