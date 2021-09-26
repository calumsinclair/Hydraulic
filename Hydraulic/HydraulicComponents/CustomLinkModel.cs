using Blazor.Diagrams.Core.Models;
using Hydraulic.Calculations;
using Hydraulic.HydraulicComponents.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydraulic.HydraulicComponents
{
    public class CustomLinkModel : LinkModel 
    {
        public Properties.Properties props = new Hose();
        public CustomLinkModel(PortModel sourcePort, CalculationManager calc, PortModel targetPort = null) : base(sourcePort, targetPort) 
        {
            props.OnPropertyChanged += calc.OnComponentUpdated;
        }
    }
}
