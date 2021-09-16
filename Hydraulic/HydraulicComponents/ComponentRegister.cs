using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Diagrams.Core.Models;
using Hydraulic.DisplayStates;
using Hydraulic.HydraulicComponents.Properties;
using Hydraulic.HydraulicComponents.Positioners;
using static Hydraulic.HydraulicComponents.Positioners.Positioner;

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

            PortInfo top = new PortInfo()
                .Add(Pos<Center>(), Pos<Top>(), outPort);

            PortInfo bottom = new PortInfo()
                .Add(Pos<Center>(), Pos<Bottom>(), inPort);

            PortInfo topAndBottom = new PortInfo()
                .Add(Pos<Center>(), Pos<Top>(), outPort)
                .Add(Pos<Center>(), Pos<Bottom>(), inPort);

            PortInfo twoBottom = new PortInfo()
                .Add(Pos<Center>() + 10, Pos<Bottom>(), inPort)
                .Add(Pos<Center>() - 10, Pos<Bottom>(), inPort);

            PortInfo fourMiddle = new PortInfo()
                .Add(Pos<Center>() * 0.5f, Pos<Top>(), outPort)
                .Add(Pos<Center>() * 1.5f, Pos<Top>(), outPort)
                .Add(Pos<Center>() + new Percent(0.25f), Pos<Bottom>(), inPort) // Same as before just diffrent way
                .Add(Pos<Center>() + new Percent(-0.25f), Pos<Bottom>(), inPort);

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
