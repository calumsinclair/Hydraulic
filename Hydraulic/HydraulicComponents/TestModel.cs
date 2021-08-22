using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using System.Collections.Generic;

namespace Hydraulic.HydraulicComponents
{

    public class TestModel : NodeModel
    {
        public string Image;
        public Properties.IProperties Props;

        public TestModel(
            Point position, 
            string image, 
            Properties.IProperties props,
            PortAlignment[] ports
        ) : base(position)
        {
            this.Image = image;
            this.Props = props;

            foreach(var port in ports)
            {
                this.AddPort(port);
            }
        }

    }
}
