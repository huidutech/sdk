namespace LocalClient
{
    partial class AddressSet
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cbbDeviceID = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.DeviceAddr = new System.Windows.Forms.TabPage();
            this.btnReget = new System.Windows.Forms.Button();
            this.lbAddressTip = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbDNS = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbGateway = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbMask = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.cbDhcpEnable = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ServerAddr = new System.Windows.Forms.TabPage();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSVRefresh = new System.Windows.Forms.Button();
            this.btnSVOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.DeviceAddr.SuspendLayout();
            this.ServerAddr.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "控制卡ID";
            // 
            // cbbDeviceID
            // 
            this.cbbDeviceID.FormattingEnabled = true;
            this.cbbDeviceID.Location = new System.Drawing.Point(87, 24);
            this.cbbDeviceID.Name = "cbbDeviceID";
            this.cbbDeviceID.Size = new System.Drawing.Size(121, 20);
            this.cbbDeviceID.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.DeviceAddr);
            this.tabControl1.Controls.Add(this.ServerAddr);
            this.tabControl1.Location = new System.Drawing.Point(12, 60);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(404, 299);
            this.tabControl1.TabIndex = 2;
            // 
            // DeviceAddr
            // 
            this.DeviceAddr.Controls.Add(this.btnReget);
            this.DeviceAddr.Controls.Add(this.lbAddressTip);
            this.DeviceAddr.Controls.Add(this.btnOK);
            this.DeviceAddr.Controls.Add(this.tbDNS);
            this.DeviceAddr.Controls.Add(this.label12);
            this.DeviceAddr.Controls.Add(this.tbGateway);
            this.DeviceAddr.Controls.Add(this.label11);
            this.DeviceAddr.Controls.Add(this.tbMask);
            this.DeviceAddr.Controls.Add(this.label10);
            this.DeviceAddr.Controls.Add(this.tbIP);
            this.DeviceAddr.Controls.Add(this.cbDhcpEnable);
            this.DeviceAddr.Controls.Add(this.label9);
            this.DeviceAddr.Controls.Add(this.label8);
            this.DeviceAddr.Location = new System.Drawing.Point(4, 22);
            this.DeviceAddr.Name = "DeviceAddr";
            this.DeviceAddr.Padding = new System.Windows.Forms.Padding(3);
            this.DeviceAddr.Size = new System.Drawing.Size(396, 273);
            this.DeviceAddr.TabIndex = 0;
            this.DeviceAddr.Text = "控制卡IP";
            this.DeviceAddr.UseVisualStyleBackColor = true;
            // 
            // btnReget
            // 
            this.btnReget.Location = new System.Drawing.Point(191, 236);
            this.btnReget.Name = "btnReget";
            this.btnReget.Size = new System.Drawing.Size(75, 23);
            this.btnReget.TabIndex = 25;
            this.btnReget.Text = "刷新";
            this.btnReget.UseVisualStyleBackColor = true;
            this.btnReget.Click += new System.EventHandler(this.btnReget_Click);
            // 
            // lbAddressTip
            // 
            this.lbAddressTip.AutoSize = true;
            this.lbAddressTip.Location = new System.Drawing.Point(19, 241);
            this.lbAddressTip.Name = "lbAddressTip";
            this.lbAddressTip.Size = new System.Drawing.Size(29, 12);
            this.lbAddressTip.TabIndex = 24;
            this.lbAddressTip.Text = "    ";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(277, 236);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 23;
            this.btnOK.Text = "设置";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tbDNS
            // 
            this.tbDNS.Location = new System.Drawing.Point(90, 181);
            this.tbDNS.Name = "tbDNS";
            this.tbDNS.Size = new System.Drawing.Size(100, 21);
            this.tbDNS.TabIndex = 22;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(43, 184);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 12);
            this.label12.TabIndex = 21;
            this.label12.Text = "DNS";
            // 
            // tbGateway
            // 
            this.tbGateway.Location = new System.Drawing.Point(90, 134);
            this.tbGateway.Name = "tbGateway";
            this.tbGateway.Size = new System.Drawing.Size(100, 21);
            this.tbGateway.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(17, 137);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 19;
            this.label11.Text = "默认网关";
            // 
            // tbMask
            // 
            this.tbMask.Location = new System.Drawing.Point(90, 88);
            this.tbMask.Name = "tbMask";
            this.tbMask.Size = new System.Drawing.Size(100, 21);
            this.tbMask.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "子网掩码";
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(90, 45);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(100, 21);
            this.tbIP.TabIndex = 16;
            // 
            // cbDhcpEnable
            // 
            this.cbDhcpEnable.AutoSize = true;
            this.cbDhcpEnable.Location = new System.Drawing.Point(90, 14);
            this.cbDhcpEnable.Name = "cbDhcpEnable";
            this.cbDhcpEnable.Size = new System.Drawing.Size(48, 16);
            this.cbDhcpEnable.TabIndex = 15;
            this.cbDhcpEnable.Text = "使能";
            this.cbDhcpEnable.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "IP地址";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "自动模式";
            // 
            // ServerAddr
            // 
            this.ServerAddr.Controls.Add(this.tbPort);
            this.ServerAddr.Controls.Add(this.tbHost);
            this.ServerAddr.Controls.Add(this.label3);
            this.ServerAddr.Controls.Add(this.label2);
            this.ServerAddr.Controls.Add(this.btnSVRefresh);
            this.ServerAddr.Controls.Add(this.btnSVOK);
            this.ServerAddr.Location = new System.Drawing.Point(4, 22);
            this.ServerAddr.Name = "ServerAddr";
            this.ServerAddr.Padding = new System.Windows.Forms.Padding(3);
            this.ServerAddr.Size = new System.Drawing.Size(396, 273);
            this.ServerAddr.TabIndex = 1;
            this.ServerAddr.Text = "服务器地址";
            this.ServerAddr.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(337, 21);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSVRefresh
            // 
            this.btnSVRefresh.Location = new System.Drawing.Point(191, 236);
            this.btnSVRefresh.Name = "btnSVRefresh";
            this.btnSVRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnSVRefresh.TabIndex = 27;
            this.btnSVRefresh.Text = "刷新";
            this.btnSVRefresh.UseVisualStyleBackColor = true;
            this.btnSVRefresh.Click += new System.EventHandler(this.btnSVRefresh_Click);
            // 
            // btnSVOK
            // 
            this.btnSVOK.Location = new System.Drawing.Point(277, 236);
            this.btnSVOK.Name = "btnSVOK";
            this.btnSVOK.Size = new System.Drawing.Size(75, 23);
            this.btnSVOK.TabIndex = 26;
            this.btnSVOK.Text = "设置";
            this.btnSVOK.UseVisualStyleBackColor = true;
            this.btnSVOK.Click += new System.EventHandler(this.btnSVOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 28;
            this.label2.Text = "主机地址:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 29;
            this.label3.Text = "端口号:";
            // 
            // tbHost
            // 
            this.tbHost.Location = new System.Drawing.Point(109, 39);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(157, 21);
            this.tbHost.TabIndex = 30;
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(109, 81);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(157, 21);
            this.tbPort.TabIndex = 31;
            // 
            // AddressSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 371);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cbbDeviceID);
            this.Controls.Add(this.label1);
            this.Name = "AddressSet";
            this.Text = "地址设置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddressSet_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.DeviceAddr.ResumeLayout(false);
            this.DeviceAddr.PerformLayout();
            this.ServerAddr.ResumeLayout(false);
            this.ServerAddr.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbDeviceID;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage DeviceAddr;
        private System.Windows.Forms.TabPage ServerAddr;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnReget;
        private System.Windows.Forms.Label lbAddressTip;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox tbDNS;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbGateway;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbMask;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.CheckBox cbDhcpEnable;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSVRefresh;
        private System.Windows.Forms.Button btnSVOK;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

