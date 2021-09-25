using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydraulic.HydraulicComponents.Properties
{
    
    public class Hose : Properties
    {
        public ObservableProperty<int> Diameter { get; set; }

        public Hose()
        {
            Diameter = new ObservableProperty<int>(1, this);
        }
    }
}
