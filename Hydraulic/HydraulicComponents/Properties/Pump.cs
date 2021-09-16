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

    public enum PowerType
    {
        ElectricMotor,
        Generator
    }
    public record Pump(
        PumpType Type = PumpType.VairableDisplacement,
        PowerType Power = PowerType.ElectricMotor,
        float ShaftSpeed = 200f,
        float Displacement = 30f,

        float Lpm = 0f,
        float Pressure = 10.1f,
        float PumpPower = 0.0f
    ) : IProperties
    {    
    }
}
