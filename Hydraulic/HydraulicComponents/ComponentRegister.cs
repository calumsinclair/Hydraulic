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
        public PortInfo ports;

        public ComponentData
            (Func<IProperties> newProps, ComponentDisplayState displayState, PortInfo  newPorts)
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
            bool inPort = false;
            bool outPort = true;

            PortInfo top = new PortInfo().Add(25, 0, outPort);
            PortInfo bottom = new PortInfo().Add(25, 60, inPort);
            PortInfo topAndBottom = new PortInfo().Add(25, 0, outPort).Add(25, 60, inPort);
            PortInfo twoBottom = new PortInfo().Add(20, 60, inPort).Add(30, 60, inPort);
            PortInfo fourMiddle = new PortInfo().Add(60, 0, outPort).Add(90, 0, outPort).Add(60 ,60 ,inPort).Add(90,60,inPort);

            //Pump
            Register(
                new ComponentData(() => new Pump(PumpType.FixedDisplacement),
                new PumpDisplayState(imagePrefix, imagePrefix + "PumpFixedDisplacement.png"),
                top

            ));

            // ControlValve       
            Register(
                new ComponentData(() => new DirectionalControlVavle(ControlValveType.ProportionalControl),
                new ControlValveDisplayState(imagePrefix, imagePrefix + "DirectionalControlValve43.png"),
                fourMiddle));

            // Hydraulic Cylinder
            Register(
                new ComponentData(() => new ActuatorCylinder(50),
                new ComponentDisplayState(imagePrefix + "ActuatorCylinder.png"),
                twoBottom));

            // Tank
            Register(
                new ComponentData(() => new Tank(),
                new ComponentDisplayState(imagePrefix + "Tank.png"),
                top));

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
