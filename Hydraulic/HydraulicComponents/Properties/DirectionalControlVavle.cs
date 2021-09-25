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
        public ObservableProperty<ControlValveType> ControlType { get; set; }

        public DirectionalControlVavle()
        {
            ControlType = new ObservableProperty<ControlValveType>(this);
        }

    }
        
}
