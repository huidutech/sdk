using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using huidu.sdk;
using System.Xml;

namespace LocalClient
{
    public partial class AddressSet : Form
    {
        public AddressSet()
        {
            InitializeComponent();

            //初始化socket监听器, 开启线程进行socket监听
            SocketHelper.GetInstance().Init();

            //创建udp服务: 支持搜索控制卡、设置控制卡IP地址
            UDPServices.GetInstance();

            UDPServices.GetInstance().xmlRespond_ += this.XmlRespond;
        }

        //窗口关闭事件函数
        private void AddressSet_FormClosed(object sender, FormClosedEventArgs e)
        {
            //窗体退出时等待后台线程退出后再关闭窗口
            SocketHelper.GetInstance().Exit();
        }

        //控制卡ID号刷新事件函数
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //1. 清空列表中的项
            //2. 获取控制卡列表, 将控制卡ID添加到列表中
            this.cbbDeviceID.Items.Clear();
            HDeviceInfo[] devices = UDPServices.GetInstance().GetDevices();
            for (int i = 0; i<devices.Length; i++)
            {
                this.cbbDeviceID.Items.Add(devices[i].id);
            }

            //3. 选中第0个项
            if (this.cbbDeviceID.Items.Count > 0)
            {
                this.cbbDeviceID.Text = (string)this.cbbDeviceID.Items[0];
            }
        }

        private void btnReget_Click(object sender, EventArgs e)
        {
            if (this.cbbDeviceID.Text == "")
            {
                return ;
            }

            string cmd =
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n"
                + "<sdk>\n"
                + "    <in method=\"GetEth0Info\"/>"
                + "</sdk>\n";
            UDPServices.GetInstance().SendCmd(this.cbbDeviceID.Text, cmd);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.cbbDeviceID.Text == "")
            {
                return;
            }

            HnEthernetInfo nInfo = new HnEthernetInfo();
            nInfo.valid     = true;
            nInfo.enable    = true;
            nInfo.dhcp      = this.cbDhcpEnable.Checked;
            nInfo.ip        = this.tbIP.Text;
            nInfo.mask      = this.tbMask.Text;
            nInfo.gateway   = this.tbGateway.Text;
            nInfo.dns       = this.tbDNS.Text;
            HEthernetInfo info = this.N2Str(nInfo);
            string cmd =
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n"
                + "<sdk>\n"
                + "    <in method=\"SetEth0Info\">\n"
                + "        <eth valid=\"true\">\n"
                + "            <enable value=\"true\"/>\n"
                + "            <dhcp auto=\"##dhcp\"/>\n"
                + "            <address ip=\"##ip\" netmask=\"##netmask\" gateway=\"##gateway\" dns=\"##dns\"/>\n"
                + "        </eth>\n"
                + "    </in>\n"
                + "</sdk>\n";

            cmd = cmd.Replace("##dhcp", info.dhcp);
            cmd = cmd.Replace("##ip", info.ip);
            cmd = cmd.Replace("##netmask", info.mask);
            cmd = cmd.Replace("##gateway", info.gateway);
            cmd = cmd.Replace("##dns", info.dns);
            UDPServices.GetInstance().SendCmd(this.cbbDeviceID.Text, cmd);
        }

        private void btnSVRefresh_Click(object sender, EventArgs e)
        {
            if (this.cbbDeviceID.Text == "")
            {
                return;
            }

            string cmd =
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n"
                + "<sdk>\n"
                + "    <in method=\"GetSDKTcpServer\"/>"
                + "</sdk>\n";
            UDPServices.GetInstance().SendCmd(this.cbbDeviceID.Text, cmd);
        }

        private void btnSVOK_Click(object sender, EventArgs e)
        {
            if (this.cbbDeviceID.Text == "")
            {
                return;
            }

            string host = this.tbHost.Text;
            string port = this.tbPort.Text;
            string cmd =
                "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n"
                + "<sdk>\n"
                + "    <in method=\"SetSDKTcpServer\">\n"
                + "        <server host=\"##host\" port=\"##port\"/>\n"
                + "    </in>\n"
                + "</sdk>\n";
            cmd = cmd.Replace("##host", host);
            cmd = cmd.Replace("##port", port);
            UDPServices.GetInstance().SendCmd(this.cbbDeviceID.Text, cmd);
        }

        private void XmlRespond(byte[] buffer, int len)
        {
            if (this.cbbDeviceID.InvokeRequired)
            {
                byte[] copy = new byte[len];
                Array.Copy(buffer, copy, len);
                this.Invoke(UDPServices.GetInstance().xmlRespond_, new object[] { copy, len });
                return ;
            }

            int index = 0;
            int version = ISocket.GetInt(buffer, ref index);
            UDPServices.HCmdType cmd = (UDPServices.HCmdType)ISocket.GetShort(buffer, ref index);
            string id = ISocket.GetString(buffer, ref index, UDPServices.MAX_DEVICE_ID_LENGHT);
            if (id.IndexOf('\0') >= 0)
            {
                id = id.Remove(id.IndexOf('\0'));
            }

            if (id != this.cbbDeviceID.Text)
            {
                return ;
            }

            string xml = ISocket.GetString(buffer, ref index, len - 6 - UDPServices.MAX_DEVICE_ID_LENGHT);
            this.ParseXml(xml);
        }

        private void ParseXml(string xml)
        {
            Console.Write(xml);
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(xml);
                XmlNodeList results = doc.SelectNodes("sdk/out");
                foreach (XmlNode node in results)
                {
                    if (node.Attributes["result"].InnerText != "kSuccess")
                    {
                        Console.Write("获取失败");
                        continue ;
                    }

                    if (node.Attributes["method"].InnerText == "GetEth0Info")
                    {
                        this.ParseGetEth0Info(node);
                    } else if (node.Attributes["method"].InnerText == "SetEth0Info")
                    {
                        this.ParseSetEth0Info(node);
                    } else if (node.Attributes["method"].InnerText == "GetSDKTcpServer")
                    {
                        this.ParseGetSDKTcpServer(node);
                    } else if (node.Attributes["method"].InnerText == "SetSDKTcpServer")
                    {
                        this.ParseSetSDKTcpServer(node);
                    }
                }

            }
            catch (System.Exception e)
            {
                
            }
        }

        private struct HEthernetInfo
        {
            public string valid;
            public string enable;
            public string dhcp;
            public string ip;
            public string mask;
            public string gateway;
            public string dns;
        }

        private struct HnEthernetInfo
        {
            public bool valid;
            public bool enable;
            public bool dhcp;
            public string ip;
            public string mask;
            public string gateway;
            public string dns;
        }

        private HnEthernetInfo Str2N(HEthernetInfo info)
        {
            HnEthernetInfo nInfo = new HnEthernetInfo();
            nInfo.valid     = this.ParseBool(info.valid);
            nInfo.enable    = this.ParseBool(info.enable);
            nInfo.dhcp      = this.ParseBool(info.dhcp);
            nInfo.ip        = info.ip;
            nInfo.mask      = info.mask;
            nInfo.gateway   = info.gateway;
            nInfo.dns       = info.dns;
            return nInfo;
        }

        private HEthernetInfo N2Str(HnEthernetInfo nInfo)
        {
            HEthernetInfo info = new HEthernetInfo();
            info.valid      = this.GenBool(nInfo.valid);
            info.enable     = this.GenBool(nInfo.enable);
            info.dhcp       = this.GenBool(nInfo.dhcp);
            info.ip         = nInfo.ip;
            info.mask       = nInfo.mask;
            info.gateway    = nInfo.gateway;
            info.dns        = nInfo.dns;
            return info;
        }

        private void ParseGetEth0Info(XmlNode outNode)
        {
            HEthernetInfo info      = new HEthernetInfo();
            try
            {
                XmlNode eth     = outNode.SelectSingleNode("eth");
                XmlNode enable  = outNode.SelectNodes("eth/enable")[0];
                XmlNode dhcp    = outNode.SelectNodes("eth/dhcp")[0];
                XmlNode addr    = outNode.SelectNodes("eth/address")[0];

                info.valid      = eth.Attributes["valid"].InnerText;
                info.enable     = enable.Attributes["value"].InnerText;
                info.dhcp       = dhcp.Attributes["auto"].InnerText;
                info.ip         = addr.Attributes["ip"].InnerText;
                info.mask       = addr.Attributes["netmask"].InnerText;
                info.gateway    = addr.Attributes["gateway"].InnerText;
                info.dns        = addr.Attributes["dns"].InnerText;
                this.RefreshEthUI(this.Str2N(info));
            } catch (System.Exception e)
            {

            }
        }

        private void ParseSetEth0Info(XmlNode outNode)
        {
            //走进该流程 说明设置成功
        }

        private void ParseGetSDKTcpServer(XmlNode outNode)
        {
            XmlNode server      = outNode.SelectSingleNode("server");
            string host         = server.Attributes["host"].InnerText;
            string port         = server.Attributes["port"].InnerText;
            this.tbHost.Text    = host;
            this.tbPort.Text    = port;
        }

        private void ParseSetSDKTcpServer(XmlNode outNode)
        {
            //走进该流程 说明设置成功
        }

        private bool ParseBool(string value)
        {
            if (value == "true")
            {
                return true;
            }

            return false;
        }

        private string GenBool(bool value)
        {
            if (value)
            {
                return "true";
            }

            return "false";
        }

        private void RefreshEthUI(HnEthernetInfo nInfo)
        {
            this.cbDhcpEnable.Checked = nInfo.dhcp;
            this.tbIP.Text = nInfo.ip;
            this.tbMask.Text = nInfo.mask;
            this.tbGateway.Text = nInfo.gateway;
            this.tbDNS.Text = nInfo.dns;
        }
    }
}

