using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Diagrams.Core.Models;
namespace Hydraulic.HydraulicComponents.Properties
{
    public enum PumpType
    {
        FIXED_DISPLACEMENT,
        OTHER_PUMP_TYPE
    }
    public record Pump(
        PumpType Type,
        [property:RangeAttribute(0, 100)] float power = 10f
    ) : IProperties
    {}
}
