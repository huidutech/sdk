using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace huidu.sdk
{
    public struct HDeviceInfo
    {
        public string id;
        public bool dhcp;
        public string ip;
        public string netmask;
        public string gateway;
        public string dns;
    }

    public class UDPServices: ISocket
    {
        private static UDPServices instance_ = null;
        static public UDPServices GetInstance()
        {
            if (instance_ == null)
            {
                instance_ = new UDPServices();
            }

            return instance_;
        }

        private ArrayList devices_ = new ArrayList();
        public HDeviceInfo[] GetDevices()
        {
            HDeviceInfo[] devices = new HDeviceInfo[this.devices_.Count];
            for (int i=0; i<this.devices_.Count; i++)
            {
                devices[i] = (HDeviceInfo)this.devices_[i];
            }

            return devices;
        }

        EndPoint remote_ = new IPEndPoint(IPAddress.Any, 0);
        public override void RecvSignaled(object obj)
        {
            if (obj != this.udp_)
            {
                return;
            }

            int recvs = this.udp_.ReceiveFrom(this.recvBuffer_, ref remote_);
            this.DisposeUDPPacket(recvs);
        }

        public override Socket GetSocket()
        {
            return this.udp_;
        }

        public void SendCmd(string id, string cmd)
        {
            int packetLen = cmd.Length + 6 + MAX_DEVICE_ID_LENGHT;
            byte[] packet = new byte[packetLen];
            int index = 0;
            ISocket.SetInt(packet, ref index, (int)PROTOCOL_VERSION_1);
            ISocket.SetShort(packet, ref index, (short)HCmdType.kSDKCmdAsk);
            ISocket.SetString(packet, ref index, id, MAX_DEVICE_ID_LENGHT);
            ISocket.SetString(packet, ref index, cmd);
            this.udp_.SendTo(packet, this.udpRemote_);
        }

        private static int MAX_UDP_PACKET           = 9 * 1024;     //UDP协议最大的一个数据包
        private static int REMOTE_PORT              = 10001;        //控制卡监听的UDP服务的端口号
        private static int BIND_PORT                = 0;            //对本地绑定的端口号没有要求
        private static int SEARCH_DELAY             = 2000;         //发送一个搜索包的间隔时间
        public  static int MAX_DEVICE_ID_LENGHT     = 15;
        private static int MIN_RESPOND_UDP_LENGHT   = 6;
        private UDPServices()
        {
            /**
             * 1. 初始化接收和发送数据的buffer
             * 2. 初始化发送广播包的socket
             * 3. 初始化搜索控制卡的数据包buffer
             * 4. 启动定时器, 定时发送搜索包
             */
            this.recvBuffer_ = new byte[MAX_UDP_PACKET];
            this.sendBuffer_ = new byte[MAX_UDP_PACKET];
            this.InitSocket();
            this.InitSearchPacket();
            this.StartSearchDevice();
        }

        private Socket udp_;
        private IPEndPoint udpRemote_;
        private void InitSocket()
        {
            this.udpRemote_ = new IPEndPoint(IPAddress.Broadcast, REMOTE_PORT);
            IPEndPoint ip   = new IPEndPoint(IPAddress.Any, BIND_PORT);
            this.udp_       = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            this.udp_.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);
            try
            {
                this.udp_.Bind(ip);
                SocketHelper.GetInstance().Register(this);
            } catch (SocketException e)
            {

            }
        }

        public enum HCmdType
        {
            kSearchDeviceAsk        = 0x1001,
            kSearchDeviceAnswer     = 0x1002,
            kSDKCmdAsk              = 0x2003,
            kSDKCmdAnswer           = 0x2004,
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct HSearchAsk
        {
            public uint version;
            public ushort cmd;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct HSearchAnswer
        {
            public uint     version;
            public ushort   cmd;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
            public byte[]   id;
            public uint     change;
        }

        private byte[] searchAsk_;
        private void InitSearchPacket()
        {
            HSearchAsk ask  = new HSearchAsk();
            ask.version     = PROTOCOL_VERSION_1;
            ask.cmd         = (ushort)HCmdType.kSearchDeviceAsk;
            this.searchAsk_ = StructToBytes(ask, 6);
        }

        private Timer searchTimer_;
        private void StartSearchDevice()
        {
            this.searchTimer_ = new Timer();
            this.searchTimer_.Tick += this.TimerTick;
            this.searchTimer_.Interval = SEARCH_DELAY;
            this.searchTimer_.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            this.udp_.SendTo(this.searchAsk_, this.udpRemote_);
        }

        private void DisposeUDPPacket(int recvs)
        {
            if (recvs < MIN_RESPOND_UDP_LENGHT)
            {
                return;
            }

            int index = 0;
            uint version = (uint)GetInt(this.recvBuffer_, ref index);
            HCmdType cmd = (HCmdType)GetShort(this.recvBuffer_, ref index);
            switch (cmd)
            {
                case HCmdType.kSearchDeviceAnswer:
                    this.RecvSearchAnswer(recvs);
                    break;
                case HCmdType.kSDKCmdAnswer:
                    this.RecvSDKCmdAnswer(recvs);
                    break;
                default:
                    break;
            }
        }

        private void RecvSearchAnswer(int packetLen)
        {
            int checkLen = 0;
            HSearchAnswer answer = (HSearchAnswer)ByteToStruct(this.recvBuffer_, typeof(HSearchAnswer));
            unsafe
            {
                checkLen = Marshal.SizeOf(answer);
            }

            if (packetLen != checkLen)
            {
                return ;
            }

            int index = 0;
            string id = ISocket.GetString(answer.id, ref index, MAX_DEVICE_ID_LENGHT);
            if (this.FindDeviceID(id) == false)
            {
                this.AddDevice(id, (IPEndPoint)this.remote_);
            }
        }

        public delegate void XmlRespondHandle(byte[] buffer, int len);
        public XmlRespondHandle xmlRespond_;
        private void RecvSDKCmdAnswer(int packetLen)
        {
            if (this.xmlRespond_ != null)
            {
                this.xmlRespond_(this.recvBuffer_, packetLen);
            }
        }


        private bool FindDeviceID(string id)
        {
            for (int i = 0; i < this.devices_.Count; i++)
            {
                HDeviceInfo info = (HDeviceInfo)this.devices_[i];
                if (info.id == id)
                {
                    return true;
                }
            }

            return false;
        }

        private void AddDevice(string id, IPEndPoint address)
        {
            HDeviceInfo info = new HDeviceInfo();
            info.id = id;
            info.ip = address.Address.ToString();
            int ip = (int)address.Address.Address;
            this.devices_.Add(info);
        }

        public HDeviceInfo GetDeviceInfo(string id)
        {
            for (int i = 0; i < this.devices_.Count; i++)
            {
                HDeviceInfo info = (HDeviceInfo)this.devices_[i];
                if (info.id.Contains(id))
                {
                    return info;
                }
            }

            return new HDeviceInfo();
        }
    }
}
