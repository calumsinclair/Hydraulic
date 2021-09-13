using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydraulic.HydraulicComponents
{
    public class PortInfo
    {
        public struct Info {                  
            public int xPos;
            public int yPos;
            public bool isOut;
        }

        public List<Info> portInfos = new List<Info>();

        public PortInfo Add(int x, int y, bool outPort)
        {
            Info newInfo;
            newInfo.xPos = x;
            newInfo.yPos = y;
            newInfo.isOut = outPort;

            portInfos.Add(newInfo);

            return this;
        }
    }
}
