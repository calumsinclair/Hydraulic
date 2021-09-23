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

    public class Pump : Properties
    {
        public PumpType Type { get; set; } = PumpType.FixedDisplacement;
        public PowerType Power { get; set; } = PowerType.ElectricMotor;
        public float ShaftSpeed { get; set; } 
        public float Displacement { get; set; } 

        public float Lpm { get; set; } 
        float Pressure { get; set; } 
        float PumpPower { get; set; } 
    }
}
