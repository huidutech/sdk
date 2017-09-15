using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace huidu.sdk
{
    class Protocols
    {
        public static int MAX_TCP_PACKET    = 9 * 1024;
        public static int TCP_VERSION       = 0x1000005;

        public enum HCmdType
        {
            kSDKServiceAsk          = 0x2001,
            kSDKServiceAnswer       = 0x2002,
            kSDKCmdAsk              = 0x2003,
            kSDKCmdAnswer           = 0x2004,

            kFileStartAsk           = 0x8001,
            kFileStartAnswer        = 0x8002,
            kFileContentAsk         = 0x8003,
            kFileContentAnswer      = 0x8004,
            kFileEndAsk             = 0x8005,
            kFileEndAnswer          = 0x8006,
            kReadFileAsk            = 0x8007,
            kReadFileAnswer         = 0x8008,
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct HVersionAsk
        {
            public ushort   len;
            public ushort   cmd;
            public uint     version;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct HVersionAnswer
        {
            public ushort   len;
            public ushort   cmd;
            public uint     version;
            public ushort   status;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct HSDKCmd
        {
            public ushort   len;
            public ushort   cmd;
            public uint     total;
            public uint     index;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct HFileStartAsk
        {
            public ushort   len;
            public ushort   cmd;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
            public byte[]   md5;
            public long     size;
            public short    type;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct HFileStartAnswer
        {
            public ushort   len;
            public ushort   cmd;
            public short    status;
            public long     existSize;
        }
    }
}
