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
        public PumpType Type { get; set; } = PumpType.VairableDisplacement;
        public PowerType Power { get; set; } = PowerType.ElectricMotor;
        public float ShaftSpeed { get; set; } = 200f;
        public float Displacement { get; set; } = 30f;

        public float Lpm { get; set; } = 0f;
        float Pressure { get; set; } = 10.1f;
        float PumpPower { get; set; } = 0.0f;

        //public Pump(Action<Properties> newObserver) : base(newObserver) { }
    }
}
