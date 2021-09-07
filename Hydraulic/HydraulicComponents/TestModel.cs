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
            (int,int)[] ports
        ) : base(position)
        {
            DisplayState = displayState;
            Props = props;

            /*
            Point extraPoint = new Point(0, 0);
            Size newSize = new Size(1, 3);
            PortModel newPort = new PortModel(this,PortAlignment.Bottom, extraPoint, newSize);

            AddPort(newPort);*/
          
            foreach(var port in ports)
            {
                PortAlignment allignment = PortAlignment.Bottom;
                if(port.Item2 < 25)
                {
                    allignment = PortAlignment.Top;
                }

                CustomPortModel model = new CustomPortModel(this, allignment, port);


                AddPort(model);
            }
        }

    }
}
