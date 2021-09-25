using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydraulic.HydraulicComponents.Properties
{
    public class Tank : Properties
    {
        public ObservableProperty<int> size { get; set; }

        public Tank()
        {
            size = new ObservableProperty<int>(10, this);
        }
        
    }
}
