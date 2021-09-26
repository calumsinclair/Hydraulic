using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydraulic.Calculations
{
    public class PressureDropCalculator
    {
        public PressureDropCalculator()
        {

        }

        public float CalculatePressureDrop(float flowRate, float diameter, float flowCoeffiecient, float specificGravity)
        {
            float pressureDrop = flowRate / (0.021275f * (MathF.PI * flowCoeffiecient) * MathF.Pow(diameter,2));
            pressureDrop = MathF.Pow(pressureDrop, 2);
            pressureDrop = pressureDrop * specificGravity;

            return pressureDrop;
        }
    }
}
