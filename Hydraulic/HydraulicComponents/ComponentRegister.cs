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
        public PortAlignment[] ports;

        public ComponentData(Func<IProperties> newProps, ComponentDisplayState displayState, PortAlignment[] newPorts)
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
            PortAlignment[] topAndBottom = { PortAlignment.Top, PortAlignment.Bottom };
            
            //Pump
            Register(
                new ComponentData(()=>new Pump(PumpType.FixedDisplacement),
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

            // Motor
            Register(
                new ComponentData(() => new DirectionalControlValve(),
                new ControlValveDisplayState(imagePrefix + "Filter.png",
                                             imagePrefix + "MotorElectirc.png"),
                topAndBottom));

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
