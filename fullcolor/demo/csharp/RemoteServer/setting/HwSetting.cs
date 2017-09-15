using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace huidu.sdk
{
    class HwSetting
    {
        public static string SetHDPlayerFPGAConfig(string xml)
        {
            string cmd = "    <in method=\"SetHDPlayerFPGAConfig\">\n"
                + xml
                + "    </in>\n";
            return cmd;
        }

        public static string SetSDKFPGAConfig(string xml)
        {
            string cmd = "    <in method=\"SetSDKFPGAConfig\">\n"
                + xml
                + "    </in>\n";
            return cmd;
        }

        public static string GetSDKFPGAConfig()
        {
            string cmd = "    <in method=\"GetSDKFPGAConfig\"/>\n";
            return cmd;
        }
    }
}
