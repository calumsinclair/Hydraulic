using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using System.Collections.Generic;

namespace Hydraulic.HydraulicComponents
{

    public class TestModel : NodeModel
    {
        public ComponentDisplayState DisplayState;
        public Properties.IProperties Props;

        public TestModel(Point position,
            ComponentDisplayState displayState, 
            Properties.IProperties props,
            PortAlignment[] ports
        ) : base(position)
        {
            DisplayState = displayState;
            Props = props;

            foreach(var port in ports)
            {
                this.AddPort(port);
            }
        }

    }
}
