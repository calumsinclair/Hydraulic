using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Diagrams.Core.Models;
using Hydraulic.HydraulicComponents.Properties;

namespace Hydraulic.HydraulicComponents
{
    public class ComponentData
    {
        public Func<IProperties> props;
        public string image;
        public PortAlignment[] ports;

        public ComponentData(Func<IProperties> newProps, string newImage, PortAlignment[] newPorts)
        {
            props = newProps;
            image = newImage;
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
                imagePrefix + "PumpFixedDisplacement.png", 
                topAndBottom
                ));

            Register(
             new ComponentData(()=>new Pump(PumpType.VairableDisplacement),
             imagePrefix + "PumpVairableDisplacement.png",
             topAndBottom
             ));

            // Motor
            Register(
                new ComponentData(()=>new Motor(),
                imagePrefix + "MotorElectirc.png",
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
