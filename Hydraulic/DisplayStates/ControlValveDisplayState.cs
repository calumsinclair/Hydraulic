using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydraulic.DisplayStates
{
    public class ControlValveDisplayState : ComponentDisplayState
    {
        private string[] images = new string[3];
        public ControlValveDisplayState(string modifier, string valve) : base(valve)
        {
            images[0] = modifier;
            images[1] = valve;
            images[2] = modifier;
        }

        public override string[] Images => images;
    }
}
