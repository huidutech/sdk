using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace huidu.sdk
{
    class SwitchScreen
    {
        static public string GetSwitchTime()
        {
            string cmd = "    <in method=\"GetSwitchTime\"/>\n";
            return cmd;
        }

        static public string SetSwitchTime()
        {
            string cmd = ""
                + "    <in method=\"SetSwitchTime\">\n"
                + "        <open enable=\"true\"/>\n"
                + "        <ploy enable=\"true\">\n"
                + "            <item enable=\"false\" end=\"08:00:00\" start=\"08:00:00\"/>\n"
                + "            <item enable=\"false\" end=\"08:00:00\" start=\"08:00:00\"/>\n"
                + "            <item enable=\"true\" end=\"23:59:59\" start=\"23:00:03\"/>\n"
                + "            <item enable=\"true\" end=\"23:00:02\" start=\"00:00:00\"/>\n"
                + "        </ploy>\n"
                + "    </in>\n";

            return cmd;
        }

        static public string OpenScreen()
        {
            string cmd = "    <in method=\"OpenScreen\"/>\n";
            return cmd;
        }

        static public string CloseScreen()
        {
            string cmd = "    <in method=\"CloseScreen\"/>\n";
            return cmd;
        }
    }
}
