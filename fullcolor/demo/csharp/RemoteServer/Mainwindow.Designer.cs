namespace RemoteServer
{
    partial class Mainwindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainwindow));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnStart = new System.Windows.Forms.Button();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FileSync = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RemoteList = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RefreshFileList = new System.Windows.Forms.Button();
            this.DeleteRomoteFile = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.UploadList = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Upload = new System.Windows.Forms.Button();
            this.DeleteUpload = new System.Windows.Forms.Button();
            this.AddToUpload = new System.Windows.Forms.Button();
            this.SendProgram = new System.Windows.Forms.TabPage();
            this.ProgramConfigText = new System.Windows.Forms.RichTextBox();
            this.ProgramConfig = new System.Windows.Forms.TextBox();
            this.SendProgramConfig = new System.Windows.Forms.Button();
            this.ChooseProgramConfig = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnWriteSwitchScreen = new System.Windows.Forms.Button();
            this.btnReadSwitchScreen = new System.Windows.Forms.Button();
            this.btnWriteTime = new System.Windows.Forms.Button();
            this.btnReadTime = new System.Windows.Forms.Button();
            this.btnWriteLight = new System.Windows.Forms.Button();
            this.btnReadLight = new System.Windows.Forms.Button();
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.OpenXMLFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.OpenResFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.rtbMsg = new System.Windows.Forms.RichTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbHPath = new System.Windows.Forms.TextBox();
            this.btnHSend = new System.Windows.Forms.Button();
            this.btnHSelect = new System.Windows.Forms.Button();
            this.tbSPath = new System.Windows.Forms.TextBox();
            this.btnSSend = new System.Windows.Forms.Button();
            this.btnSSelect = new System.Windows.Forms.Button();
            this.btnReadNetwork = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.FileSync.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SendProgram.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.FileSync);
            this.tabControl1.Controls.Add(this.SendProgram);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(2, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(790, 491);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnStart);
            this.tabPage1.Controls.Add(this.tbPort);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(782, 465);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "初始化";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(234, 39);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(77, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(104, 39);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(81, 21);
            this.tbPort.TabIndex = 1;
            this.tbPort.Text = "1000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "端口号: ";
            // 
            // FileSync
            // 
            this.FileSync.Controls.Add(this.groupBox3);
            this.FileSync.Controls.Add(this.groupBox2);
            this.FileSync.Location = new System.Drawing.Point(4, 22);
            this.FileSync.Name = "FileSync";
            this.FileSync.Padding = new System.Windows.Forms.Padding(3);
            this.FileSync.Size = new System.Drawing.Size(782, 465);
            this.FileSync.TabIndex = 1;
            this.FileSync.Text = "文件同步";
            this.FileSync.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RemoteList);
            this.groupBox3.Controls.Add(this.RefreshFileList);
            this.groupBox3.Controls.Add(this.DeleteRomoteFile);
            this.groupBox3.Location = new System.Drawing.Point(17, 216);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(737, 243);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "文件列表";
            // 
            // RemoteList
            // 
            this.RemoteList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader8,
            this.columnHeader7});
            this.RemoteList.FullRowSelect = true;
            this.RemoteList.GridLines = true;
            this.RemoteList.Location = new System.Drawing.Point(6, 31);
            this.RemoteList.Name = "RemoteList";
            this.RemoteList.Size = new System.Drawing.Size(608, 206);
            this.RemoteList.TabIndex = 3;
            this.RemoteList.UseCompatibleStateImageBehavior = false;
            this.RemoteList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "文件名";
            this.columnHeader4.Width = 93;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "类型";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "大小";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "实际大小";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "MD5";
            // 
            // RefreshFileList
            // 
            this.RefreshFileList.Location = new System.Drawing.Point(634, 29);
            this.RefreshFileList.Name = "RefreshFileList";
            this.RefreshFileList.Size = new System.Drawing.Size(87, 23);
            this.RefreshFileList.TabIndex = 2;
            this.RefreshFileList.Text = "刷新";
            this.RefreshFileList.UseVisualStyleBackColor = true;
            this.RefreshFileList.Click += new System.EventHandler(this.RefreshFileList_Click);
            // 
            // DeleteRomoteFile
            // 
            this.DeleteRomoteFile.Location = new System.Drawing.Point(634, 58);
            this.DeleteRomoteFile.Name = "DeleteRomoteFile";
            this.DeleteRomoteFile.Size = new System.Drawing.Size(86, 23);
            this.DeleteRomoteFile.TabIndex = 0;
            this.DeleteRomoteFile.Text = "删除文件";
            this.DeleteRomoteFile.UseVisualStyleBackColor = true;
            this.DeleteRomoteFile.Click += new System.EventHandler(this.DeleteRomoteFile_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.UploadList);
            this.groupBox2.Controls.Add(this.Upload);
            this.groupBox2.Controls.Add(this.DeleteUpload);
            this.groupBox2.Controls.Add(this.AddToUpload);
            this.groupBox2.Location = new System.Drawing.Point(17, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(737, 191);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "上传文件列表";
            // 
            // UploadList
            // 
            this.UploadList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader2,
            this.columnHeader10,
            this.columnHeader3,
            this.columnHeader1});
            this.UploadList.FullRowSelect = true;
            this.UploadList.GridLines = true;
            this.UploadList.Location = new System.Drawing.Point(7, 21);
            this.UploadList.Name = "UploadList";
            this.UploadList.Size = new System.Drawing.Size(607, 164);
            this.UploadList.TabIndex = 3;
            this.UploadList.UseCompatibleStateImageBehavior = false;
            this.UploadList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "文件名";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "大小";
            this.columnHeader2.Width = 83;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "类型";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "MD5";
            this.columnHeader3.Width = 257;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "路径";
            this.columnHeader1.Width = 259;
            // 
            // Upload
            // 
            this.Upload.Location = new System.Drawing.Point(634, 78);
            this.Upload.Name = "Upload";
            this.Upload.Size = new System.Drawing.Size(86, 23);
            this.Upload.TabIndex = 2;
            this.Upload.Text = "上传文件";
            this.Upload.UseVisualStyleBackColor = true;
            this.Upload.Click += new System.EventHandler(this.Upload_Click);
            // 
            // DeleteUpload
            // 
            this.DeleteUpload.Location = new System.Drawing.Point(634, 49);
            this.DeleteUpload.Name = "DeleteUpload";
            this.DeleteUpload.Size = new System.Drawing.Size(86, 23);
            this.DeleteUpload.TabIndex = 1;
            this.DeleteUpload.Text = "删除文件";
            this.DeleteUpload.UseVisualStyleBackColor = true;
            this.DeleteUpload.Click += new System.EventHandler(this.DeleteUpload_Click);
            // 
            // AddToUpload
            // 
            this.AddToUpload.Location = new System.Drawing.Point(634, 20);
            this.AddToUpload.Name = "AddToUpload";
            this.AddToUpload.Size = new System.Drawing.Size(86, 23);
            this.AddToUpload.TabIndex = 0;
            this.AddToUpload.Text = "添加文件";
            this.AddToUpload.UseVisualStyleBackColor = true;
            this.AddToUpload.Click += new System.EventHandler(this.AddToUpload_Click);
            // 
            // SendProgram
            // 
            this.SendProgram.Controls.Add(this.ProgramConfigText);
            this.SendProgram.Controls.Add(this.ProgramConfig);
            this.SendProgram.Controls.Add(this.SendProgramConfig);
            this.SendProgram.Controls.Add(this.ChooseProgramConfig);
            this.SendProgram.Controls.Add(this.label1);
            this.SendProgram.Location = new System.Drawing.Point(4, 22);
            this.SendProgram.Name = "SendProgram";
            this.SendProgram.Padding = new System.Windows.Forms.Padding(3);
            this.SendProgram.Size = new System.Drawing.Size(782, 465);
            this.SendProgram.TabIndex = 0;
            this.SendProgram.Text = "发送节目";
            this.SendProgram.UseVisualStyleBackColor = true;
            // 
            // ProgramConfigText
            // 
            this.ProgramConfigText.Location = new System.Drawing.Point(17, 34);
            this.ProgramConfigText.Name = "ProgramConfigText";
            this.ProgramConfigText.Size = new System.Drawing.Size(759, 425);
            this.ProgramConfigText.TabIndex = 3;
            this.ProgramConfigText.Text = resources.GetString("ProgramConfigText.Text");
            // 
            // ProgramConfig
            // 
            this.ProgramConfig.Location = new System.Drawing.Point(88, 7);
            this.ProgramConfig.Name = "ProgramConfig";
            this.ProgramConfig.Size = new System.Drawing.Size(346, 21);
            this.ProgramConfig.TabIndex = 2;
            // 
            // SendProgramConfig
            // 
            this.SendProgramConfig.Location = new System.Drawing.Point(521, 6);
            this.SendProgramConfig.Name = "SendProgramConfig";
            this.SendProgramConfig.Size = new System.Drawing.Size(75, 23);
            this.SendProgramConfig.TabIndex = 1;
            this.SendProgramConfig.Text = "发送";
            this.SendProgramConfig.UseVisualStyleBackColor = true;
            this.SendProgramConfig.Click += new System.EventHandler(this.SendProgramConfig_Click);
            // 
            // ChooseProgramConfig
            // 
            this.ChooseProgramConfig.Location = new System.Drawing.Point(440, 6);
            this.ChooseProgramConfig.Name = "ChooseProgramConfig";
            this.ChooseProgramConfig.Size = new System.Drawing.Size(75, 23);
            this.ChooseProgramConfig.TabIndex = 1;
            this.ChooseProgramConfig.Text = "选择";
            this.ChooseProgramConfig.UseVisualStyleBackColor = true;
            this.ChooseProgramConfig.Click += new System.EventHandler(this.ChooseProgramConfig_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "配置文件";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnReadNetwork);
            this.tabPage2.Controls.Add(this.btnWriteSwitchScreen);
            this.tabPage2.Controls.Add(this.btnReadSwitchScreen);
            this.tabPage2.Controls.Add(this.btnWriteTime);
            this.tabPage2.Controls.Add(this.btnReadTime);
            this.tabPage2.Controls.Add(this.btnWriteLight);
            this.tabPage2.Controls.Add(this.btnReadLight);
            this.tabPage2.Controls.Add(this.rtbResult);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(782, 465);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "设置项";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnWriteSwitchScreen
            // 
            this.btnWriteSwitchScreen.Location = new System.Drawing.Point(227, 59);
            this.btnWriteSwitchScreen.Name = "btnWriteSwitchScreen";
            this.btnWriteSwitchScreen.Size = new System.Drawing.Size(75, 23);
            this.btnWriteSwitchScreen.TabIndex = 6;
            this.btnWriteSwitchScreen.Text = "设置开关屏";
            this.btnWriteSwitchScreen.UseVisualStyleBackColor = true;
            this.btnWriteSwitchScreen.Click += new System.EventHandler(this.btnWriteSwitchScreen_Click);
            // 
            // btnReadSwitchScreen
            // 
            this.btnReadSwitchScreen.Location = new System.Drawing.Point(227, 16);
            this.btnReadSwitchScreen.Name = "btnReadSwitchScreen";
            this.btnReadSwitchScreen.Size = new System.Drawing.Size(75, 23);
            this.btnReadSwitchScreen.TabIndex = 5;
            this.btnReadSwitchScreen.Text = "回读开关屏";
            this.btnReadSwitchScreen.UseVisualStyleBackColor = true;
            this.btnReadSwitchScreen.Click += new System.EventHandler(this.btnReadSwitchScreen_Click);
            // 
            // btnWriteTime
            // 
            this.btnWriteTime.Location = new System.Drawing.Point(125, 59);
            this.btnWriteTime.Name = "btnWriteTime";
            this.btnWriteTime.Size = new System.Drawing.Size(75, 23);
            this.btnWriteTime.TabIndex = 4;
            this.btnWriteTime.Text = "时间校正";
            this.btnWriteTime.UseVisualStyleBackColor = true;
            this.btnWriteTime.Click += new System.EventHandler(this.btnWriteTime_Click);
            // 
            // btnReadTime
            // 
            this.btnReadTime.Location = new System.Drawing.Point(125, 16);
            this.btnReadTime.Name = "btnReadTime";
            this.btnReadTime.Size = new System.Drawing.Size(75, 23);
            this.btnReadTime.TabIndex = 3;
            this.btnReadTime.Text = "回读时间";
            this.btnReadTime.UseVisualStyleBackColor = true;
            this.btnReadTime.Click += new System.EventHandler(this.btnReadTime_Click);
            // 
            // btnWriteLight
            // 
            this.btnWriteLight.Location = new System.Drawing.Point(23, 59);
            this.btnWriteLight.Name = "btnWriteLight";
            this.btnWriteLight.Size = new System.Drawing.Size(75, 23);
            this.btnWriteLight.TabIndex = 2;
            this.btnWriteLight.Text = "设置亮度";
            this.btnWriteLight.UseVisualStyleBackColor = true;
            this.btnWriteLight.Click += new System.EventHandler(this.btnWriteLight_Click);
            // 
            // btnReadLight
            // 
            this.btnReadLight.Location = new System.Drawing.Point(23, 16);
            this.btnReadLight.Name = "btnReadLight";
            this.btnReadLight.Size = new System.Drawing.Size(75, 23);
            this.btnReadLight.TabIndex = 1;
            this.btnReadLight.Text = "回读亮度";
            this.btnReadLight.UseVisualStyleBackColor = true;
            this.btnReadLight.Click += new System.EventHandler(this.btnReadLight_Click);
            // 
            // rtbResult
            // 
            this.rtbResult.Location = new System.Drawing.Point(7, 108);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.ReadOnly = true;
            this.rtbResult.Size = new System.Drawing.Size(769, 351);
            this.rtbResult.TabIndex = 0;
            this.rtbResult.Text = "";
            // 
            // OpenXMLFileDialog
            // 
            this.OpenXMLFileDialog.Filter = "XML文件|*.xml|所有文件|*.*";
            // 
            // OpenResFileDialog
            // 
            this.OpenResFileDialog.Multiselect = true;
            // 
            // rtbMsg
            // 
            this.rtbMsg.Location = new System.Drawing.Point(2, 509);
            this.rtbMsg.Name = "rtbMsg";
            this.rtbMsg.ReadOnly = true;
            this.rtbMsg.Size = new System.Drawing.Size(790, 143);
            this.rtbMsg.TabIndex = 1;
            this.rtbMsg.Text = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tbSPath);
            this.tabPage3.Controls.Add(this.btnSSend);
            this.tabPage3.Controls.Add(this.btnSSelect);
            this.tabPage3.Controls.Add(this.tbHPath);
            this.tabPage3.Controls.Add(this.btnHSend);
            this.tabPage3.Controls.Add(this.btnHSelect);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(782, 465);
            this.tabPage3.TabIndex = 4;
            this.tabPage3.Text = "FPGA参数";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "HDPlayer FPGA参数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "SDK FPGA参数";
            // 
            // tbHPath
            // 
            this.tbHPath.Location = new System.Drawing.Point(148, 37);
            this.tbHPath.Name = "tbHPath";
            this.tbHPath.Size = new System.Drawing.Size(346, 21);
            this.tbHPath.TabIndex = 5;
            // 
            // btnHSend
            // 
            this.btnHSend.Location = new System.Drawing.Point(581, 36);
            this.btnHSend.Name = "btnHSend";
            this.btnHSend.Size = new System.Drawing.Size(75, 23);
            this.btnHSend.TabIndex = 3;
            this.btnHSend.Text = "发送";
            this.btnHSend.UseVisualStyleBackColor = true;
            this.btnHSend.Click += new System.EventHandler(this.btnHSend_Click);
            // 
            // btnHSelect
            // 
            this.btnHSelect.Location = new System.Drawing.Point(500, 36);
            this.btnHSelect.Name = "btnHSelect";
            this.btnHSelect.Size = new System.Drawing.Size(75, 23);
            this.btnHSelect.TabIndex = 4;
            this.btnHSelect.Text = "选择";
            this.btnHSelect.UseVisualStyleBackColor = true;
            this.btnHSelect.Click += new System.EventHandler(this.btnHSelect_Click);
            // 
            // tbSPath
            // 
            this.tbSPath.Location = new System.Drawing.Point(148, 76);
            this.tbSPath.Name = "tbSPath";
            this.tbSPath.Size = new System.Drawing.Size(346, 21);
            this.tbSPath.TabIndex = 8;
            // 
            // btnSSend
            // 
            this.btnSSend.Location = new System.Drawing.Point(581, 75);
            this.btnSSend.Name = "btnSSend";
            this.btnSSend.Size = new System.Drawing.Size(75, 23);
            this.btnSSend.TabIndex = 6;
            this.btnSSend.Text = "发送";
            this.btnSSend.UseVisualStyleBackColor = true;
            this.btnSSend.Click += new System.EventHandler(this.btnSSend_Click);
            // 
            // btnSSelect
            // 
            this.btnSSelect.Location = new System.Drawing.Point(500, 75);
            this.btnSSelect.Name = "btnSSelect";
            this.btnSSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSSelect.TabIndex = 7;
            this.btnSSelect.Text = "选择";
            this.btnSSelect.UseVisualStyleBackColor = true;
            this.btnSSelect.Click += new System.EventHandler(this.btnSSelect_Click);
            // 
            // btnReadNetwork
            // 
            this.btnReadNetwork.Location = new System.Drawing.Point(330, 16);
            this.btnReadNetwork.Name = "btnReadNetwork";
            this.btnReadNetwork.Size = new System.Drawing.Size(85, 23);
            this.btnReadNetwork.TabIndex = 7;
            this.btnReadNetwork.Text = "获取网络信息";
            this.btnReadNetwork.UseVisualStyleBackColor = true;
            this.btnReadNetwork.Click += new System.EventHandler(this.btnReadNetwork_Click);
            // 
            // Mainwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 664);
            this.Controls.Add(this.rtbMsg);
            this.Controls.Add(this.tabControl1);
            this.Name = "Mainwindow";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.FileSync.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.SendProgram.ResumeLayout(false);
            this.SendProgram.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage SendProgram;
        private System.Windows.Forms.TabPage FileSync;
        private System.Windows.Forms.RichTextBox ProgramConfigText;
        private System.Windows.Forms.TextBox ProgramConfig;
        private System.Windows.Forms.Button SendProgramConfig;
        private System.Windows.Forms.Button ChooseProgramConfig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog OpenXMLFileDialog;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button RefreshFileList;
        private System.Windows.Forms.Button DeleteRomoteFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView UploadList;
        private System.Windows.Forms.Button Upload;
        private System.Windows.Forms.Button DeleteUpload;
        private System.Windows.Forms.Button AddToUpload;
        private System.Windows.Forms.OpenFileDialog OpenResFileDialog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView RemoteList;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.RichTextBox rtbMsg;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox rtbResult;
        private System.Windows.Forms.Button btnWriteSwitchScreen;
        private System.Windows.Forms.Button btnReadSwitchScreen;
        private System.Windows.Forms.Button btnWriteTime;
        private System.Windows.Forms.Button btnReadTime;
        private System.Windows.Forms.Button btnWriteLight;
        private System.Windows.Forms.Button btnReadLight;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSPath;
        private System.Windows.Forms.Button btnSSend;
        private System.Windows.Forms.Button btnSSelect;
        private System.Windows.Forms.TextBox tbHPath;
        private System.Windows.Forms.Button btnHSend;
        private System.Windows.Forms.Button btnHSelect;
        private System.Windows.Forms.Button btnReadNetwork;
    }
}

