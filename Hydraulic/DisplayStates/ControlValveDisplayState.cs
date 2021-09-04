using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hydraulic.HydraulicComponents.Properties;

namespace Hydraulic.DisplayStates
{
    public class ControlValveDisplayState : ComponentDisplayState
    {
        private Dictionary<ControlValveType, string> modifers = new Dictionary<ControlValveType, string>();
        private string[] images = new string[3];
               
        public ControlValveDisplayState(string prefix, string valve) : base(valve)
        {
            modifers.Add(ControlValveType.ProportionalControl, prefix + "ControlProportional.png");
            modifers.Add(ControlValveType.Lever, prefix + "ControlLever.png");
            modifers.Add(ControlValveType.PushButton, prefix + "ControlPushButton.png");

            images[0] = modifers[ControlValveType.ProportionalControl];
            images[1] = valve;
            images[2] = modifers[ControlValveType.ProportionalControl];
        }

        public override string[] Images => images;

        public override void UpdateDisplayState(IProperties props)
        {
            base.UpdateDisplayState(props);
            DirectionalControlVavle controlValveProps = props as DirectionalControlVavle;
            images[0] = modifers[controlValveProps.ControlType];
            images[2] = modifers[controlValveProps.ControlType];
        }
    }
}
