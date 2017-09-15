using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using huidu.sdk;
using System.Xml;
using System.Collections;

namespace RemoteServer
{
    public partial class Mainwindow : Form
    {
        private string all_         = "所有|*.bmp;*.png;*.jpg;*.jpeg;*.mp4;*.3gp;*.avi;*.rmvb;*.wmv;*.flv;*.mkv;*.dat;*.f4v;*.mov;*.mpg;*.trp;*.ts;*.vob;*.webm;*.asf;*.mpeg;*.mp3 wma;*.ttf;*.bin;*.ss;*.xml|";
        private string image_       = "图片|*.bmp;*.png;*.jpg;*.jpeg|";
        private string video_       = "视频|*.mp4;*.3gp;*.avi;*.rmvb;*.wmv;*.flv;*.mkv;*.dat;*.f4v;*.mov;*.mpg;*.trp;*.ts;*.vob;*.webm;*.asf;*.mpeg;*.mp3 wma|";
        private string font_        = "字体|*.ttf|";
        private string fireware_    = "固件|*.bin|";
        private string fpga_        = "FPGA参数|*.ss|";
        private string config_      = "基本参数|*.xml";
        public Mainwindow()
        {
            InitializeComponent();
            this.OpenResFileDialog.Filter = this.all_ + this.image_ + this.video_ + this.font_ + this.fireware_ + this.fpga_ + this.config_;
            this.rtbMsg.AppendText(" robot:  ");
            
        }

        private TcpServer server_ = null;
        private void btnStart_Click(object sender, EventArgs e)
        {
            this.btnStart.Enabled = false;
            server_ = TcpServer.GetInstance();
            server_.showMsgHandle_ += ShowMessage;
            server_.InitListen(Convert.ToInt32(this.tbPort.Text));
        }

        private void ChooseProgramConfig_Click(object sender, EventArgs e)
        {
            if (OpenXMLFileDialog.ShowDialog() == DialogResult.OK)
            {
                ProgramConfig.Text = OpenXMLFileDialog.FileName;
                ProgramConfigText.Text = "";
                try
                {
                    FileStream file = new FileStream(ProgramConfig.Text, FileMode.Open);
                    file.Seek(0, SeekOrigin.Begin);
                    StreamReader m_streamReader = new StreamReader(file);
                    string StrLine;
                    while (true)
                    {
                        StrLine = m_streamReader.ReadLine();
                        if (StrLine != null && StrLine != "")
                        {
                            ProgramConfigText.AppendText(StrLine + "\n");
                        }
                        else
                        {
                            break;
                        }
                    }

                    file.Close();
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void SendProgramConfig_Click(object sender, EventArgs e)
        {
            this.SendXml(ProgramConfigText.Text);
        }

        private string GetTypeFromFile(string filename)
        {
            string type = "";
            string suffix = Path.GetExtension(filename).ToLower();
            if (this.image_.Contains(suffix))
            {
                type = "图片";
            } else if (this.video_.Contains(suffix))
            {
                type = "视频";
            } else if (this.font_.Contains(suffix))
            {
                type = "字体";
            } else if (this.fireware_.Contains(suffix))
            {
                type = "固件";
            } else if (this.fpga_.Contains(suffix))
            {
                type = "FPGA参数";
            } else if (this.config_.Contains(suffix))
            {
                type = "基本参数";
            } else
            {
                type = "未知";
            }

            return type;
        }

        private static string GetMD5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail, error:" +ex.Message);
            }
        }

        private struct HUploadFile
        {
            public string   name;
            public long     size;
            public string   type;
            public string   md5;
            public string   path;
        }

        private void AddToUpload_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == OpenResFileDialog.ShowDialog())
            {
                foreach(string filename in OpenResFileDialog.FileNames)
                {
                    HUploadFile session = new HUploadFile();
                    FileInfo info   = new FileInfo(filename);
                    session.name    = Path.GetFileName(filename);
                    session.size    = info.Length;
                    session.type    = GetTypeFromFile(filename);
                    session.md5     = GetMD5HashFromFile(filename);
                    session.path    = filename;

                    ListViewItem item = new ListViewItem(session.name);
                    item.SubItems.AddRange(
                        new string[] {session.size.ToString(), session.type,
                                      session.md5, session.path });
                    UploadList.Items.Add(item);
                }
            }
        }

        private void DeleteUpload_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in UploadList.SelectedItems)
            {
                UploadList.Items.Remove(item);
            }
        }

        private void Upload_Click(object sender, EventArgs e)
        {
            ArrayList files = new ArrayList();
            foreach (ListViewItem item in UploadList.Items)
            {
                FileServices.FileSession session = new FileServices.FileSession();
                session.name    = item.SubItems[0].Text;
                session.size    = Convert.ToInt64(item.SubItems[1].Text);
                if (item.SubItems[2].Text == "图片")
                {
                    session.type = FileServices.HFileType.kImageFile;
                } else if (item.SubItems[2].Text == "视频")
                {
                    session.type = FileServices.HFileType.kVideoFile;
                } else if (item.SubItems[2].Text == "字体")
                {
                    session.type = FileServices.HFileType.kFont;
                } else if (item.SubItems[2].Text == "固件")
                {
                    session.type = FileServices.HFileType.kFireware;
                } else if (item.SubItems[2].Text == "FPGA参数")
                {
                    session.type = FileServices.HFileType.kFPGAConfig;
                } else if (item.SubItems[2].Text == "基本参数")
                {
                    session.type = FileServices.HFileType.kSettingCofnig;
                } else
                {
                    continue ;
                }

                session.md5     = item.SubItems[3].Text;
                session.path    = item.SubItems[4].Text;

                files.Add(session);
            }

            FileServices services = new FileServices(SDKClient.GetInstace(), files);
            services.SendFiles();
        }

        private void RefreshFileList_Click(object sender, EventArgs e)
        {
            this.rtbResult.Clear();
            string xml = XmlCmd.GetFiles();
            xml = xml.Replace("##GUID", SDKClient.GetInstace().GetGUID());
            SDKClient.GetInstace().SendXmlCmd(xml);
            this.rtbResult.AppendText("发送数据: \n" + xml + "\n\n");
            xml = SDKClient.GetInstace().RecvXmlCmd();
            this.rtbResult.AppendText("接收数据: \n" + xml + "\n\n");
            this.LoadXmlToFileList(xml, this.RemoteList);
        }


        private struct HGetMediaFile
        {
            public string name;
            public string md5;
            public string size;
            public string existSize;
            public string type;
        }

        private void LoadXmlToFileList(string xml, ListView lv)
        {
            ArrayList mediaFiles = new ArrayList();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                XmlNode outNode = doc.SelectNodes("sdk/out")[0];
                if (outNode.Attributes["result"].InnerText != "kSuccess")
                {
                    //表示获取失败了
                    return ;
                }

                XmlNode files = doc.SelectNodes("sdk/out/files")[0];
                XmlNodeList fileList = files.SelectNodes("file");
                foreach (XmlNode node in fileList)
                {
                    HGetMediaFile item = new HGetMediaFile();
                    item.name       = node.Attributes["name"].InnerText;
                    item.md5        = node.Attributes["md5"].InnerText;
                    item.size       = node.Attributes["size"].InnerText;
                    item.existSize  = node.Attributes["existSize"].InnerText;
                    item.type       = node.Attributes["type"].InnerText;
                    if (item.type == "image")
                    {
                        item.type = "图片";
                    } else if (item.type == "video")
                    {
                        item.type = "视频";
                    } else if (item.type == "font")
                    {
                        item.type = "字体";
                    } else if (item.type == "fireware")
                    {
                        item.type = "固件";
                    } else if (item.type == "fpga")
                    {
                        item.type = "FPGA参数";
                    } else if (item.type == "config")
                    {
                        item.type = "基本参数";
                    } else
                    {
                        item.type = "未知";
                    }

                    mediaFiles.Add(item);
                }
            } catch (System.Exception)
            {

            }

            lv.Items.Clear();
            int size = mediaFiles.Count;
            for (int i=0; i<size; i++)
            {
                HGetMediaFile item = (HGetMediaFile)mediaFiles[i];
                ListViewItem lvi = new ListViewItem(item.name);
                lvi.SubItems.AddRange(new string[] { item.type, item.size, item.existSize, item.md5});
                lv.Items.Add(lvi);
            }
        }

        private void DeleteRomoteFile_Click(object sender, EventArgs e)
        {
            if (this.RemoteList.SelectedItems.Count == 0)
            {
                //说明没有行被选中
                return ;
            }

            ArrayList names = new ArrayList();
            for (int i=0; i<this.RemoteList.SelectedItems.Count; i++)
            {
                names.Add(this.RemoteList.SelectedItems[i].Text);
            }

            string xml = "";
            string header =
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n"
                + "<sdk guid=\"##GUID\">\n"
                + "    <in method=\"DeleteFiles\">\n"
                + "        <files>\n";
            string end =
                "        </files>\n"
                + "    </in>\n"
                + "</sdk>\n";

            int size = names.Count;
            string item = "            <file name=\"##name\"/>\n";
            string name = "";
            for (int i=0; i<size; i++)
            {
                name = item.Replace("##name", (string)names[i]);
                xml += name;
            }

            xml = header + xml + end;
            this.rtbResult.Clear();
            xml = xml.Replace("##GUID", SDKClient.GetInstace().GetGUID());
            SDKClient.GetInstace().SendXmlCmd(xml);
            this.rtbResult.AppendText("发送数据: \n" + xml + "\n\n");
            xml = SDKClient.GetInstace().RecvXmlCmd();
            this.rtbResult.AppendText("接收数据: \n" + xml + "\n\n");
        }

        public void ShowMessage(string msg, bool error)
        {
            if (this.rtbMsg.InvokeRequired)
            {
                this.Invoke(this.server_.showMsgHandle_, new object[] { msg, error });
                return ;
            }

            this.rtbMsg.AppendText(msg + "\n robot:  ");
            this.tabControl1.Enabled = error;
        }

        private void btnReadLight_Click(object sender, EventArgs e)
        {
            string xml = XmlCmd.GetLuminancePloy();
            this.SendXml(xml);
        }

        private void btnWriteLight_Click(object sender, EventArgs e)
        {
            string xml = XmlCmd.SetLuminancePloy();
            this.SendXml(xml);
        }

        private void btnReadTime_Click(object sender, EventArgs e)
        {
            string xml = XmlCmd.GetTimeInfo();
            this.SendXml(xml);
        }

        private void btnWriteTime_Click(object sender, EventArgs e)
        {
            string xml = XmlCmd.SetTimeInfo();
            this.SendXml(xml);
        }

        private void btnReadSwitchScreen_Click(object sender, EventArgs e)
        {
            string xml = XmlCmd.GetSwitchTime();
            this.SendXml(xml);
        }

        private void btnWriteSwitchScreen_Click(object sender, EventArgs e)
        {
            string xml = XmlCmd.SetSwitchTime();
            this.SendXml(xml);
        }

        private void SendXml(string xml)
        {
            this.rtbResult.Clear();
            xml = xml.Replace("##GUID", SDKClient.GetInstace().GetGUID());
            SDKClient.GetInstace().SendXmlCmd(xml);
            this.rtbResult.AppendText("发送数据: \n" + xml + "\n\n");
            xml = SDKClient.GetInstace().RecvXmlCmd();
            this.rtbResult.AppendText("接收数据: \n" + xml + "\n\n");
        }

        private void btnHSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectFile = new OpenFileDialog();
            selectFile.Filter = "HDPlayer FPGA参数|*.ssx";
            if (DialogResult.OK != selectFile.ShowDialog())
            {
                return ;
            }

            this.tbHPath.Text = selectFile.FileName;
        }

        private void btnHSend_Click(object sender, EventArgs e)
        {
            string xml = "";
            try
            {
                string path = this.tbHPath.Text;
                FileStream fs = new FileStream(path, FileMode.Open);
                int size = (int)fs.Seek(0, SeekOrigin.End) - 38;
                fs.Seek(38, SeekOrigin.Begin);
                byte[] buffer = new byte[size];
                fs.Read(buffer, 0, size);
                fs.Close();

                int index = 0;
                xml = Tools.GetString(buffer, ref index, size);
            } catch (System.Exception)
            {
                return ;
            }

            xml = XmlCmd.SetHDPlayerFPGAConfig(xml);
            this.SendXml(xml);
        }

        private void btnSSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectFile = new OpenFileDialog();
            selectFile.Filter = "SDK FPGA参数|*.xml";
            if (DialogResult.OK != selectFile.ShowDialog())
            {
                return;
            }

            this.tbSPath.Text = selectFile.FileName;
        }

        private void btnSSend_Click(object sender, EventArgs e)
        {
            string xml = "";
            try
            {
                string path = this.tbSPath.Text;
                FileStream fs = new FileStream(path, FileMode.Open);
                int size = (int)fs.Seek(0, SeekOrigin.End);
                fs.Seek(0, SeekOrigin.Begin);
                byte[] buffer = new byte[size];
                fs.Read(buffer, 0, size);
                fs.Close();

                int index = 0;
                xml = Tools.GetString(buffer, ref index, size);
            }
            catch (System.Exception)
            {
                return;
            }

            xml = XmlCmd.SetSDKFPGAConfig(xml);
            this.SendXml(xml);
        }

        private void btnReadNetwork_Click(object sender, EventArgs e)
        {
            string xml = XmlCmd.GetNetworkInfo();
            this.SendXml(xml);
        }
    }
}
