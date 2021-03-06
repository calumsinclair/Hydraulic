using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        // Calculators 

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

            //if pump is connected 
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

        public void OnComponentUpdated(Properties props)
        {
            Console.WriteLine("Component Updated!");

            TestModel pump;
            if (!TryGetPump(out pump))
            {
                Console.WriteLine("Exited graph Loop");
                return;
            }
            else
            {
                Calculation thisCalculation = new PumpCalculator().Calculate(pump.Props as Pump);

                TestModel thisModel = pump;
                while (thisModel != null && thisModel.Ports[0].Links.Count > 0)
                {
                    Console.WriteLine("In while loop");
                    CustomLinkModel link = thisModel.Ports[0].Links[0] as CustomLinkModel;

                    if (link.IsAttached)
                    {
                        HoseCalculator hoseCalculator = new HoseCalculator(link.props as Hose, thisCalculation);
                        thisModel = link.TargetNode as TestModel;
                    }
                }
            }
        }
    }
}
