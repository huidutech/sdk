using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace huidu.sdk
{
    class XmlCmd
    {
        static string header =
            "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n"
            + "<sdk guid=\"##GUID\">\n";
        static string end = "</sdk>\n";

        //回读亮度策略
        static public string GetLuminancePloy()
        {
            string cmd = header + Light.GetLuminancePloy() + end;
            return cmd;
        }

        //设置亮度策略
        static public string SetLuminancePloy()
        {
            string cmd = header + Light.SetLuminancePloy() + end;
            return cmd;
        }

        //回读时间校正
        public static string GetTimeInfo()
        {
            string cmd = header + AdjustTime.GetTimeInfo() + end;
            return cmd;
        }

        //设置时间校正
        public static string SetTimeInfo()
        {
            string cmd = header + AdjustTime.SetTimeInfo() + end;
            return cmd;
        }

        //回读开关屏
        public static string GetSwitchTime()
        {
            string cmd = header + SwitchScreen.GetSwitchTime() + end;
            return cmd;
        }

        //设置开关屏
        public static string SetSwitchTime()
        {
            string cmd = header + SwitchScreen.SetSwitchTime() + end;
            return cmd;
        }

        //回读多媒体文件列表
        public static string GetFiles()
        {
            string cmd = header + FileServices.GetFiles() + end;
            return cmd;
        }

        //设置HDPlayer FPGA配置参数
        public static string SetHDPlayerFPGAConfig(string xml)
        {
            string cmd = header + HwSetting.SetHDPlayerFPGAConfig(xml) + end;
            return cmd;
        }

        //设置SDK FPGA配置参数
        public static string SetSDKFPGAConfig(string xml)
        {
            string cmd = header + HwSetting.SetSDKFPGAConfig(xml) + end;
            return cmd;
        }

        //回读SDK FPGA配置参数
        public static string GetSDKFPGAConfig()
        {
            string cmd = header + HwSetting.GetSDKFPGAConfig() + end;
            return cmd;
        }

        //回读网络信息
        public static string GetNetworkInfo()
        {
            string cmd = header + Network.GetNetworkInfo() + end;
            return cmd;
        }
    }
}
