using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydraulic.HydraulicComponents.Properties
{
    public record DirectionalControlValve(
        float thing = 10f
    ) : IProperties
    { }
}
