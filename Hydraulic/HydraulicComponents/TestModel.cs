using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using System.Collections.Generic;

namespace Hydraulic.HydraulicComponents
{
    public class TestModel: NodeModel
    {
        public List<PortModel> ports = new List<PortModel>();
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }

        public TestModel(Point position) : base(position) 
        {
            
            PortModel port1 = new PortModel("One", this);
            PortModel port2 = new PortModel("Two", this);
            PortModel port3 = new PortModel("Three", this);
            PortModel port4 = new PortModel("Four", this);

            ports.Add(port1);
            ports.Add(port2);
            ports.Add(port3);
            ports.Add(port4);

        }

    }
}
