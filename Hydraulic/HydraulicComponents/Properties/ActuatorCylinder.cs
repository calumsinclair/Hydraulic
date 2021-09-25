using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydraulic.HydraulicComponents.Properties
{
    public class ActuatorCylinder : Properties
    {
        public ObservableProperty<int> weight { get; set; }

        public ActuatorCylinder()
        {
            weight = new ObservableProperty<int>(this);
        }
    }

}
