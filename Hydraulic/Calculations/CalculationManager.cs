using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Diagrams.Core;
using Blazor.Diagrams.Core.Models.Base;
using Hydraulic.HydraulicComponents;
using Hydraulic.HydraulicComponents.Properties;

namespace Hydraulic.Calculations
{
    public class CalculationManager
    {
        Diagram graph;
        List<TestModel> nodes = new List<TestModel>();

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
            bool pumpInScene = TryGetPump(out start);
            Console.WriteLine("Pump in scene = " + pumpInScene);
            if (!pumpInScene) return;

            if(start.Ports[0].Links.Count > 0)
            {
                Console.WriteLine("Links > 0");
                nodes.Add(start);
                BaseLinkModel link = start.Ports[0].Links[0];

                if (link.IsAttached)
                {
                    TestModel next = link.TargetNode as TestModel;
                    Console.WriteLine("Found next node !");
                }
            }               
        }
    }
}
