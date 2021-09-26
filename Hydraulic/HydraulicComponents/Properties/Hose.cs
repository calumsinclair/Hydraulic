using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydraulic.HydraulicComponents.Properties
{
    
    public class Hose : Properties
    {
        public ObservableProperty<int> Diameter { get; set; }
        public ObservableProperty<float> SpecifiedGravity { get; set; }
        public ObservableProperty<float> AbsoluteViscosity { get; set; }

        public ObservableProperty<float> CrossSectionalArea { get; set; }
        public ObservableProperty<float> Velocity { get; set; }
        public ObservableProperty<float> ReynoldsNumber { get; set; }

        public Hose()
        {
            Diameter = new ObservableProperty<int>(1, this);
            SpecifiedGravity = new ObservableProperty<float>(9.8f, this);
            AbsoluteViscosity = new ObservableProperty<float>(this);

            Velocity = new ObservableProperty<float>(this);
            CrossSectionalArea = new ObservableProperty<float>(this);
            ReynoldsNumber = new ObservableProperty<float>(this);
        }
    }
}
