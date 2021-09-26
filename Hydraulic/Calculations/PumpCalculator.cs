using Hydraulic.HydraulicComponents.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Hydraulic.Calculations
{
    public class PumpCalculator
    {
        public Calculation Calculate(Pump newPump)
        {
            float flowRate = CalculatePumpFlowRate(newPump.Displacement, newPump.ShaftSpeed, 100);

            newPump.Lpm.Value = flowRate;

            return new Calculation(0, flowRate);
        }

        public float CalculatePumpFlowRate(float displacement, float motorSpeed, float efficiency)
        {
            //Flow = displacement * speed * efficiency / 100
            float flowRate = displacement * motorSpeed * (efficiency / 100f);
            return flowRate;
        }

        public float CalculatePumpDisplacement(float flowRate, float motorSpeed, float efficiency)
        {
            //Displacement = flowRate / speed * effiecency / 100 
            float displacement = flowRate / (motorSpeed / (efficiency / 100f));
            return displacement;
        }
    }
}
