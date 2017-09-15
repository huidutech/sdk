using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace huidu.sdk
{
    public abstract class ISocket
    {
        public abstract void RecvSignaled(object obj);
        public abstract Socket GetSocket();

        public ISocket()
        {
            SocketHelper.GetInstance().recvHandle_ += 
                new SocketHelper.RecvSignalHandle(RecvSignaled);
        }

        protected byte[] recvBuffer_ = null;
        protected byte[] sendBuffer_ = null;
        protected static uint PROTOCOL_VERSION_1 = 0x1000005;

        public static byte[] StructToBytes(object structObj, int size)
        {
            byte[] bytes = new byte[size];
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(structObj, structPtr, false);
            Marshal.Copy(structPtr, bytes, 0, size);
            Marshal.FreeHGlobal(structPtr);
            return bytes;
        }

        public static object ByteToStruct(byte[] bytes, Type type, int index = 0)
        {
            int size = Marshal.SizeOf(type);
            if (size > bytes.Length)
            {
                return null;
            }

            IntPtr structPtr = Marshal.AllocHGlobal(size);
            Marshal.Copy(bytes, index, structPtr, size);
            object obj = Marshal.PtrToStructure(structPtr, type);
            Marshal.FreeHGlobal(structPtr);
            return obj;
        }

        public static int GetInt(byte[] data, ref int index)
        {
            int value = (data[index + 3] << 24) | (data[index + 2] << 16) | (data[index + 1] << 8) | data[index];
            index += 4;
            return value;
        }

        public static void SetInt(byte[] data, ref int index, int value)
        {
            data[index + 0] = (byte)(value & 0xff);
            data[index + 1] = (byte)((value >> 8) & 0xff);
            data[index + 2] = (byte)((value >> 16) & 0xff);
            data[index + 3] = (byte)((value >> 24) & 0xff);
            index += 4;
        }

        public static short GetShort(byte[] data, ref int index)
        {
            short value = (short)((data[index + 1] << 8) | data[index]);
            index += 2;
            return value;
        }

        public static void SetShort(byte[] data, ref int index, short value)
        {
            data[index + 0] = (byte)(value & 0xff);
            data[index + 1] = (byte)((value >> 8) & 0xff);
            index += 2;
        }

        public static byte GetByte(byte[] data, ref int index)
        {
            byte value = data[index];
            index += 1;
            return value;
        }

        public static void SetByte(byte[] data, ref int index, byte value)
        {
            data[index] = value;
            index += 1;
        }

        public static string GetString(byte[] data, ref int index, int len)
        {
            string value = Encoding.UTF8.GetString(data, index, len);
            index += len;
            return value;
        }

        public static void SetString(byte[] data, ref int index, string value, int len = 0)
        {
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(value);
            Buffer.BlockCopy(byteArray, 0, data, index, byteArray.Length);
            if (len == 0)
            {
                index += byteArray.Length;
            }
            else
            {
                index += len;
            }
        }
    }
}
