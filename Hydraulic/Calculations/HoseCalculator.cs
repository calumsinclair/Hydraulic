using Hydraulic.HydraulicComponents.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Hydraulic.Calculations
{
    public class HoseCalculator
    {
        public record HoseCalculation(float crossSectionalArea, float velocity, float reynoldsNumber);

        public HoseCalculator(Hose newHose, Calculation newCalc)
        {
            HoseCalculation result = CalculateHoseProperties(newCalc.flow, newHose.SpecifiedGravity, newHose.Diameter, newHose.AbsoluteViscosity);

            newHose.CrossSectionalArea.Value = result.crossSectionalArea;
            newHose.Velocity.Value = result.velocity;
            newHose.ReynoldsNumber.Value = result.reynoldsNumber;
        }

        public HoseCalculation CalculateHoseProperties
            (float floatRate, float specificGravity, float insideDiameter, float absoluteViscosity)
        {
            float area = (float)Math.PI * insideDiameter;
            float velocity = floatRate / area;
            float reynoldsNumber = (1000 * velocity * insideDiameter * specificGravity) / absoluteViscosity;

            HoseCalculation result = new HoseCalculation(area, velocity, reynoldsNumber);
            return result;
        }
    }
}
