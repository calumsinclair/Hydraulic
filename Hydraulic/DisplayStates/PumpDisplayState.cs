using Hydraulic.HydraulicComponents.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydraulic.DisplayStates
{
    public class PumpDisplayState : ComponentDisplayState
    {
        private string[] images = new string[2];
        private Dictionary<PumpType, string> pumpModifiers = new Dictionary<PumpType, string>();
        private Dictionary<PowerType, string> powerModifers = new Dictionary<PowerType, string>();

        private (int, int)[] image_size = new (int, int)[2];

        public override (int, int)[] ImageSize => image_size;
        public override string[] Images => images;

        public PumpDisplayState(string prefix, string pump) : base(pump)
        {
            pumpModifiers.Add(PumpType.FixedDisplacement, prefix + "PumpFixedDisplacement.png");
            pumpModifiers.Add(PumpType.VairableDisplacement, prefix + "PumpVairableDisplacement.png");
            powerModifers.Add(PowerType.ElectricMotor, prefix + "MotorElectric.png");
            powerModifers.Add(PowerType.Generator, prefix + "Engine.png");

            images[0] = pumpModifiers[PumpType.FixedDisplacement];
            images[1] = powerModifers[PowerType.ElectricMotor];

            image_size[0] = (50, 50);
            image_size[1] = (50, 50);
        }

        public override void UpdateDisplayState(IProperties props)
        {
            base.UpdateDisplayState(props);
            Pump pumpProps = props as Pump;
            images[0] = pumpModifiers[pumpProps.Type];
            images[1] = powerModifers[pumpProps.Power];
        }
    }
}
