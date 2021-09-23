using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydraulic.HydraulicComponents.Properties
{
    public enum ControlValveType
    {
        ProportionalControl,
        PushButton,
        Lever
    }

    public class DirectionalControlVavle : Properties
    {
        public ControlValveType ControlType { get; set; }

    }
        
}
