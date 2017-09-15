using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace huidu.sdk
{
    
    public class SocketHelper
    {
        static public SocketHelper GetInstance()
        {
            if (instance_ == null)
            {
                instance_ = new SocketHelper();
            }

            return instance_;
        }

        public void Init()
        {
            thread_ = new Thread(ReadThread);
            thread_.IsBackground = true;
            thread_.Start();
        }

        public void Register(ISocket socket)
        {
            lock (this.locker_)
            {
                this.recvHandle_ += new RecvSignalHandle(socket.RecvSignaled);
                this.socketLists_.Add(socket);
            }
        }

        public void Unregister(ISocket socket)
        {
            lock(this.locker_)
            {
                this.socketLists_.Remove(socket);
            }
        }

        private static SocketHelper instance_ = null;
        private Thread thread_ = null;
        private SocketHelper()
        {
            
        }

        public void Exit()
        {
            this.isActivity_ = false;
        }

        private bool isActivity_ = true;
        private object locker_ = new object();
        private ArrayList socketLists_ = new ArrayList();
        public delegate void RecvSignalHandle(object obj);
        public RecvSignalHandle recvHandle_ = null;
        private static void ReadThread()
        {
            ArrayList readList = new ArrayList();
            while (instance_.isActivity_)
            {
                lock(instance_.locker_)
                {
                    readList.Clear();
                    for (int i=0; i<instance_.socketLists_.Count; i++)
                    {
                        readList.Add(((ISocket)instance_.socketLists_[i]).GetSocket());
                    }
                }

                if (readList.Count == 0)
                {
                    Thread.Sleep(200);
                    continue;
                }

                Socket.Select(readList, null, null, 1000);
                lock (instance_.locker_)
                {
                    for (int i=0; i<readList.Count; i++)
                    {
                        if (instance_.recvHandle_ != null)
                        {
                            instance_.recvHandle_(readList[i]);
                        }
                    }
                }
            }

            Console.Write("end...");
        }
    }
}
