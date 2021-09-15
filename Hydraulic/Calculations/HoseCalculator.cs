using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydraulic.Calculations
{
    public record HoseCalculation (float crossSectionalArea, float velocity, float reynoldsNumber);

    public class HoseCalculator
    {
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
