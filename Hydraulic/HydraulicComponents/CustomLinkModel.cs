using Blazor.Diagrams.Core.Models;
using Hydraulic.HydraulicComponents.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydraulic.HydraulicComponents
{
    public class CustomLinkModel : LinkModel 
    {
        public IProperties props = new Hose(10);
        public CustomLinkModel(PortModel sourcePort, PortModel targetPort = null) : base(sourcePort, targetPort) { }
    }
}
