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

        public HoseCalculator(Hose newHose)
        {
            HoseCalculation result = CalculateHoseProperties(10, newHose.SpecifiedGravity, newHose.Diameter, newHose.AbsoluteViscosity);

            PropertyInfo areaProperty = newHose.GetType().GetProperty("CrossSectionalArea");
            newHose.UpdateValue(areaProperty, result.crossSectionalArea);

            PropertyInfo velocityProperty = newHose.GetType().GetProperty("Velocity");
            newHose.UpdateValue(velocityProperty, result.velocity);

            PropertyInfo reynoldsProperty = newHose.GetType().GetProperty("ReynoldsNumber");
            newHose.UpdateValue(reynoldsProperty, result.reynoldsNumber);
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
