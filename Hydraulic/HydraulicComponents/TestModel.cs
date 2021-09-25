using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using System.Collections.Generic;

namespace Hydraulic.HydraulicComponents
{

    public class TestModel : NodeModel
    {
        public ComponentDisplayState DisplayState;
        public Properties.Properties Props;

        public TestModel(Point position,
            ComponentDisplayState displayState, 
            Properties.Properties props,
            PortInfo ports
        ) : base(position)
        {
            DisplayState = displayState;
            Props = props;
            DisplayState.UpdateDisplayState(props);
          
            foreach(var port in ports.portInfos)
            {
                PortAlignment allignment = PortAlignment.Bottom;
                int ypos = 0;
                int size = 10;
                ypos = port.yPos.Resolve(size, ypos);

                if(ypos < size/2)
                {
                    allignment = PortAlignment.Top;
                }

                CustomPortModel model = new CustomPortModel(this, allignment, (port.xPos, port.yPos), port.isOut);
                AddPort(model);
            }
        }

    }
}
