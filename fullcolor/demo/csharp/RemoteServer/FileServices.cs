using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace huidu.sdk
{
    class FileServices
    {
        public enum HFileType
        {
            kImageFile = 0,
            kVideoFile,
            kFont,
            kFireware,
            kFPGAConfig,
            kSettingCofnig,
        }

        public struct FileSession
        {
            public string path;
            public string md5;
            public string name;
            public long size;
            public HFileType type;
        }

        private SDKClient client_ = null;
        private ArrayList files_ = null;
        public FileServices(SDKClient client, ArrayList files)
        {
            this.client_ = client;
            this.files_ = files;
        }

        public void SendFiles()
        {
            int counts = this.files_.Count;
            for (int i=0; i<counts; i++)
            {
                this.current_ = (FileSession)this.files_[i];
                this.SendFile();
            }
        }

        public void SendFile()
        {
            this.SendFileStartAsk();
            if (this.RecvFileStartAnswer() == false)
            {
                return ;
            }

            this.SendFileContentAsk();
            this.RecvFileEndAnswer();
        }

        private FileSession current_;
        private byte[] sendBuffer_  = new byte[Protocols.MAX_TCP_PACKET];
        private byte[] recvBuffer_  = new byte[Protocols.MAX_TCP_PACKET];
        private FileStream filestream_ = null;
        private void SendFileStartAsk()
        {
            try
            {
                filestream_ = new FileStream(this.current_.path, FileMode.Open);
            } catch (System.Exception)
            {

            }

            int index = 2;
            Tools.SetShort(this.sendBuffer_, ref index, 
                (ushort)Protocols.HCmdType.kFileStartAsk);
            Tools.SetString(this.sendBuffer_, ref index, this.current_.md5, 33);
            this.sendBuffer_[index - 1] = 0;
            Tools.SetLong(this.sendBuffer_, ref index, this.current_.size);
            Tools.SetShort(this.sendBuffer_, ref index, (short)this.current_.type);
            Tools.SetString(this.sendBuffer_, ref index, this.current_.name);
            
            int len = index + 1;
            index = 0;
            Tools.SetShort(this.sendBuffer_, ref index, (short)len);
            this.client_.SendPacket(this.sendBuffer_, len);
        }

        private bool RecvFileStartAnswer()
        {
            int len = this.client_.RecvPacket();
            this.client_.CopyPacket(this.recvBuffer_, len);

            int index = 0;
            short cmdLen = Tools.GetShort(recvBuffer_, ref index);
            short cmdValue = Tools.GetShort(recvBuffer_, ref index);
            short status = Tools.GetShort(recvBuffer_, ref index);
            long existSize = Tools.GetLong(recvBuffer_, ref index);
            if (status != 0)
            {
                //说明失败
                TcpServer.GetInstance().ShowMessage("下载文件 "
                    + this.current_.path + " 失败: " + Tools.Hex2String(recvBuffer_, len));
                return false;
            }

            if (existSize == this.current_.size)
            {
                //说明该文件已存在下位机
            }

            try
            {
                this.filestream_.Seek(existSize, SeekOrigin.Begin);
            } catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        private void SendFileContentAsk()
        {
            int packetLen = Protocols.MAX_TCP_PACKET - 4;
            try
            {
                while (true)
                {
                    int reads = this.filestream_.Read(this.sendBuffer_, 4, packetLen);
                    if (reads > 0)
                    {
                        int index = 0;
                        int len = 4 + reads;
                        Tools.SetShort(this.sendBuffer_, ref index, (short)len);
                        Tools.SetShort(this.sendBuffer_, ref index, 
                            (ushort)Protocols.HCmdType.kFileContentAsk);
                        this.client_.SendPacket(this.sendBuffer_, len);
                    }
                    else
                    {
                        this.filestream_.Close();
                        this.filestream_ = null;
                        this.SendFileEndAsk();
                        return;
                    }
                }
            } catch (System.Exception)
            {

            }
        }

        private void SendFileEndAsk()
        {
            int index = 0;
            Tools.SetShort(this.sendBuffer_, ref index, 4);
            Tools.SetShort(this.sendBuffer_, ref index, (ushort)Protocols.HCmdType.kFileEndAsk);
            this.client_.SendPacket(this.sendBuffer_, 4);
        }

        private void RecvFileEndAnswer()
        {
            int len = this.client_.RecvPacket();
            this.client_.CopyPacket(this.recvBuffer_, len);

            int index = 0;
            short cmdLen = Tools.GetShort(recvBuffer_, ref index);
            short cmdValue = Tools.GetShort(recvBuffer_, ref index);
            short status = Tools.GetShort(recvBuffer_, ref index);
            if (status == 0)
            {
                //表示发送成功
                TcpServer.GetInstance().ShowMessage("发送一个文件: " + this.current_.path + " 完成.");
            } else
            {
                TcpServer.GetInstance().ShowMessage("发送一个文件: " + this.current_.path 
                    + " 失败: error code " + status);
            }
        }

        public static string GetFiles()
        {
            string cmd = "    <in method=\"GetFiles\"/>\n";
            return cmd;
        }
    }
}
