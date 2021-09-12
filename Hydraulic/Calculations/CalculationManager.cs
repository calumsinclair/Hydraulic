using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Diagrams.Core;
using Hydraulic.HydraulicComponents;
using Hydraulic.HydraulicComponents.Properties;

namespace Hydraulic.Calculations
{
    public class CalculationManager
    {
        Diagram graph;

        public CalculationManager(Diagram newGraph)
        {
            graph = newGraph;
        }

        public bool TryGetPump(out TestModel testModel)
        {
            for (int i = 0; i < graph.Nodes.Count; i++)
            {
                TestModel currentNode = graph.Nodes[i] as TestModel; 
                
                if(currentNode.Props is Pump)
                {
                    testModel = currentNode;
                    return true;                
                }    
            }

            testModel = null;
            return false;
        }

        public void ReCalculate()
        {
            Console.WriteLine("Calculating Graph");
            TestModel start;
            Console.WriteLine("Pump in scene = " + TryGetPump(out start));
        }
    }
}
