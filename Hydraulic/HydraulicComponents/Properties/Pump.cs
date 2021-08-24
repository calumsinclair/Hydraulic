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
        FixedDisplacement,
        VairableDisplacement
    }
    public record Pump(
        PumpType Type,
        int Displacement = 30
    ) : IProperties
    {}
}
