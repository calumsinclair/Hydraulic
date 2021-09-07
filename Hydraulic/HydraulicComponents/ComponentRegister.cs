using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Diagrams.Core.Models;
using Hydraulic.DisplayStates;
using Hydraulic.HydraulicComponents.Properties;

namespace Hydraulic.HydraulicComponents
{
    public class ComponentData
    {
        public Func<IProperties> props;
        public ComponentDisplayState displayState;
        public (int, int)[] ports;

        public ComponentData
            (Func<IProperties> newProps, ComponentDisplayState displayState, (int, int)[]  newPorts)
        {
            props = newProps;
            this.displayState = displayState;
            ports = newPorts;
        }
    }

    public class ComponentRegister
    {
        private Dictionary<int, ComponentData> Components = new Dictionary<int, ComponentData>();
        private int id = 0;
        private string imagePrefix = "Images/Components/";

        public ComponentRegister()
        {
            //PortAlignment[] topAndBottom = { PortAlignment.Top, PortAlignment.Bottom };
            (int, int)[] topAndBottom = { (0, 0), (0, 100) };
            (int, int)[] fourMiddle = { (0, 0), (1, 0), (0, 1), (1, 1) };

            //Pump
            Register(
                new ComponentData(() => new Pump(PumpType.FixedDisplacement),
                new ComponentDisplayState(imagePrefix + "PumpFixedDisplacement.png"),
                topAndBottom

            ));

            Register(
             new ComponentData(()=>new Pump(PumpType.VairableDisplacement),
             new ComponentDisplayState(imagePrefix + "PumpVairableDisplacement.png"),
             topAndBottom
             ));

            // Motor
            Register(
                new ComponentData(()=>new Motor(),
                new ComponentDisplayState(imagePrefix + "MotorElectirc.png"),
                topAndBottom));

            // ControlValve       
            Register(
                new ComponentData(() => new DirectionalControlVavle(ControlValveType.ProportionalControl),
                new ControlValveDisplayState(imagePrefix, imagePrefix + "DirectionalControlValve43.png"),
                fourMiddle));

        }

        private void Register(ComponentData c)
        {
            Components.Add(++id,  c);
        }

        public ComponentData GetComponent(int id)
        {
            return Components[id];
        }

        public Dictionary<int,ComponentData> GetComponents()
        {
            return Components;
        }
    }
}
