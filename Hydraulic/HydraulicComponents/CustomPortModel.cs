using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;

namespace Hydraulic.HydraulicComponents
{
    public class CustomPortModel : PortModel
    {
        private double offsetX = 0;
        public new Point Position { get; set; }

        public CustomPortModel(NodeModel parent, PortAlignment alignment, double newOffset) : base(parent, alignment, null, null)
        {
            offsetX = newOffset;
        }

        // Hose properties : thickness, lpm , pressure 
        // Component leakage / pressure drop 
        // Actuator : weight, mass 
        // rotate component 

    }
}
