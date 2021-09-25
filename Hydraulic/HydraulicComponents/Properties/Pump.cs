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
        public ObservableProperty<PumpType> Type { get; set; }
        public ObservableProperty<PowerType> Power { get; set; }
        public ObservableProperty<float> ShaftSpeed { get; set; }
        public ObservableProperty<float> Displacement { get; set; }

        public ObservableProperty<float> Lpm { get; set; }
        public ObservableProperty<float> Pressure { get; set; }
        public ObservableProperty<float> PumpPower { get; set; }

        public Pump()
        {
            Type = new ObservableProperty<PumpType>(PumpType.FixedDisplacement, this);
            Power = new ObservableProperty<PowerType>(PowerType.ElectricMotor,this);
            ShaftSpeed = new ObservableProperty<float>(this);
            Displacement = new ObservableProperty<float>(this);
            Lpm = new ObservableProperty<float>(this);
            Pressure = new ObservableProperty<float>(this);
            PumpPower = new ObservableProperty<float>(this);
        }
    }
}
