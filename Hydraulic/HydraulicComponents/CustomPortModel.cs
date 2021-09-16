using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using Hydraulic.HydraulicComponents.Positioners;

namespace Hydraulic.HydraulicComponents
{
    public class CustomPortModel : PortModel
    {
        //private TestModel testModel;
        //private PortAlignment allignment;
        //private PortInfo.Info port;

        public (Positioner, Positioner) Offset { get; private set; }
        public bool IsOut { get; set; }

        public CustomPortModel(NodeModel parent, PortAlignment alignment, (Positioner, Positioner) newOffset, bool isOut)
            : base(parent, alignment)
        {
            Offset = newOffset;
            IsOut = isOut;
        }

        public override bool CanAttachTo(PortModel port)
        {
            // Checks for same-node/port attachements
            if (!base.CanAttachTo(port))
                return false;

            // Only able to attach to the same port type
            if (!(port is CustomPortModel cp))
                return false;

            return IsOut != cp.IsOut;
        }
    }
}
