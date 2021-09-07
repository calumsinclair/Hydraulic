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
        public (int, int) Offset { get; private set; }

        public CustomPortModel(NodeModel parent, PortAlignment alignment, (int,int) newOffset)
            : base(parent, alignment)
        {
            this.Offset = newOffset;
        }

        // Hose properties : thickness, lpm , pressure 
        // Component leakage / pressure drop 
        // Actuator : weight, mass 
        // rotate component 
    }
}
