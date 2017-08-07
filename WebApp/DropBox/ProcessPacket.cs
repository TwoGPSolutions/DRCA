using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropBox
{
    public class ProcessPacket
    {
        byte flag;
        decimal lat, lon;
        int type;
        string message;
        ProcessPacket(String msg)
        {
            message = msg;
        }

    }
}