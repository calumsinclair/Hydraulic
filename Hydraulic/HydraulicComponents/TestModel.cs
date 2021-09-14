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
            PortInfo ports
        ) : base(position)
        {
            DisplayState = displayState;
            Props = props;

            /*
            Point extraPoint = new Point(0, 0);
            Size newSize = new Size(1, 3);
            PortModel newPort = new PortModel(this,PortAlignment.Bottom, extraPoint, newSize);

            AddPort(newPort);*/
          
            foreach(var port in ports.portInfos)
            {
                PortAlignment allignment = PortAlignment.Bottom;
                if(port.yPos < 25)
                {
                    allignment = PortAlignment.Top;
                }

                (int, int) offset = (port.xPos, port.yPos);
                CustomPortModel model = new CustomPortModel(this, allignment, offset, port.isOut);
                AddPort(model);
            }
        }

    }
}
