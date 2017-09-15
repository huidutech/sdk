using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Xml;

namespace huidu.sdk
{
    class SDKClient
    {
        private static SDKClient instance_ = null;
        public static SDKClient GetInstace()
        {
            if (instance_ == null)
            {
                instance_ = new SDKClient();
            }

            return instance_;
        }

        private SDKClient()
        {
            
        }

        private string guid_ = "";
        private Socket client_ = null;
        public void InitConnect(Socket client)
        {
            this.client_ = client;
            this.SendVersionAsk();
            this.RecvVersionAnswer();
            this.SendGetIFVersion();
            this.RecvGetIFVersion();
        }

        public string GetGUID()
        {
            return this.guid_;
        }

        public void SendVersionAsk()
        {
            Protocols.HVersionAsk version = new Protocols.HVersionAsk();
            version.len     = 8;
            version.cmd     = (ushort)Protocols.HCmdType.kSDKServiceAsk;
            version.version = (uint)Protocols.TCP_VERSION;
            byte[] buffer   = Tools.StructToBytes(version, version.len);
            this.SendPacket(buffer, version.len);
        }

        public void RecvVersionAnswer()
        {
            int len = this.RecvPacket();
            if (len != 10)
            {
                this.PacketError(len);
                return ;
            }

            Protocols.HVersionAnswer answer = (Protocols.HVersionAnswer)Tools.ByteToStruct(
                this.packet_, typeof(Protocols.HVersionAnswer));
        }

        public void SendGetIFVersion()
        {
            string cmd =
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n"
                + "<sdk guid=\"##GUID\">\n"
                + "    <in method=\"GetIFVersion\">\n"
                + "        <version value=\"##version\"/>\n"
                + "    </in>\n"
                + "</sdk>\n";

            cmd = cmd.Replace("##version", "1000000");
            this.SendXmlCmd(cmd);
        }

        public void RecvGetIFVersion()
        {
            try
            {
                string xml = this.RecvXmlCmd();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                XmlNode sdk = doc.SelectSingleNode("sdk");
                this.guid_ = sdk.Attributes["guid"].InnerText;

                XmlNode version = sdk.SelectNodes("out/version")[0];
                string versionStr = version.Attributes["value"].InnerText;
            }
            catch (System.Exception e)
            {

            }
        }

        public void SendXmlCmd(string xml)
        {
            byte[] cmd = System.Text.Encoding.UTF8.GetBytes(xml);
            int len = cmd.Length;
            this.SendXmlCmd(cmd, len);
        }

        public string RecvXmlCmd()
        {
            string xml = "";
            while (true)
            {
                int len = this.RecvPacket();
                if (len < 12)
                {
                    this.PacketError(len);
                    return "";
                }

                int index = 4;
                int total = Tools.GetInt(this.packet_, ref index);
                index = 12;
                xml += Tools.GetString(this.packet_, ref index, len - index);
                if (xml.Length == total)
                {
                    break;
                }
            }
            
            return xml;
        }

        private byte[] sendBuffer_ = new byte[Protocols.MAX_TCP_PACKET];
        public void SendXmlCmd(byte[] xml, int len)
        {
            int validLen = Protocols.MAX_TCP_PACKET - 12;
            int packets = (len + validLen - 1) / validLen;
            int dataLen = len, packetLen = 0, dataIndex = 0;
            for (int i=0; i<packets; i++)
            {
                if (dataLen > validLen)
                {
                    packetLen = validLen;
                } else
                {
                    packetLen = dataLen;
                }

                dataIndex = len - dataLen;
                Array.Copy(xml, dataIndex, sendBuffer_, 12, packetLen);
                dataLen   -= packetLen;
                packetLen += 12;

                int index = 0;
                Tools.SetShort(sendBuffer_, ref index, (short)packetLen);
                Tools.SetShort(sendBuffer_, ref index, (short)Protocols.HCmdType.kSDKCmdAsk);
                Tools.SetInt(sendBuffer_, ref index, len);
                Tools.SetInt(sendBuffer_, ref index, dataIndex);
                this.SendPacket(sendBuffer_, packetLen);
            }
        }

        public void SendPacket(byte[] buffer, int len)
        {
            if (this.client_ == null)
            {
                TcpServer.GetInstance().ShowMessage("客户端未接入!");
                return ;
            }

            if (this.client_.Send(buffer, len, SocketFlags.None) != len)
            {
                this.SocketError("发送数据失败!");
            }
        }

        private byte[] buffer_      = new byte[Protocols.MAX_TCP_PACKET];
        private byte[] swapBuffer_  = new byte[Protocols.MAX_TCP_PACKET];
        private byte[] packet_      = new byte[Protocols.MAX_TCP_PACKET];
        private int validLen_       = 0;
        private int maxBufferLen_   = Protocols.MAX_TCP_PACKET;
        public void CopyPacket(byte[] buffer, int len)
        {
            Array.Copy(this.packet_, buffer, len);
        }

        public int RecvPacket()
        {
            byte[] buff = new byte[1024];
            while (true)
            {
                try
                {
                    int len = client_.Receive(buff);
                    if (len < 1)
                    {
                        break;
                    }

                    int space = 0, copyLen = 0;
                    int index = 0;
                    while (len > 0)
                    {
                        space = this.maxBufferLen_ - this.validLen_;
                        if (space == 0)
                        {
                            //说明数据包有问题, 主动丢弃数据
                            space = this.maxBufferLen_;
                            this.validLen_ = 0;
                        }

                        if (space >= len)
                        {
                            copyLen = len;
                        }
                        else
                        {
                            copyLen = space;
                        }

                        len -= copyLen;
                        Array.Copy(buff, 0, this.buffer_, this.validLen_, copyLen);
                        this.validLen_ += copyLen;
                        if (this.validLen_ < 2)
                        {
                            break;
                        }

                        index = 0;
                        short cmdLen = Tools.GetShort(this.buffer_, ref index);
                        if (cmdLen > Protocols.MAX_TCP_PACKET)
                        {
                            this.validLen_ = 0;
                            continue;
                        }
                        else if (cmdLen > this.validLen_)
                        {
                            break;
                        }

                        Array.Copy(this.buffer_, this.packet_, cmdLen);
                        if (this.validLen_ > cmdLen)
                        {
                            this.validLen_ = this.validLen_ - cmdLen;
                            Array.Copy(this.buffer_, cmdLen, swapBuffer_, 0, this.validLen_);
                            Array.Copy(swapBuffer_, this.buffer_, this.validLen_);
                        }
                        else
                        {
                            this.validLen_ = 0;
                        }

                        return cmdLen;
                    }
                }
                catch (Exception ex)
                {
                    this.SocketError("接受数据失败!");
                    break;
                }
            }

            return 0;
        }

        private void PacketError(int len)
        {
            if (len < 1)
            {
                return ;
            }

            string msg = "数据包错误: " + Tools.Hex2String(this.packet_, len);
            this.SocketError(msg);
        }

        private void SocketError(string msg)
        {
            this.guid_ = "";
            if (this.client_ != null)
            {
                this.client_.Shutdown(SocketShutdown.Both);
                this.client_.Close();
                this.client_ = null;
            }
            
            TcpServer.GetInstance().ShowMessage("出错! " + msg, false);
        }
    }
}
