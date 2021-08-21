using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;
using System.Collections.Generic;

namespace Hydraulic.HydraulicComponents
{
    public class TestModel: NodeModel
    {
        public double FirstNumber { get; set; }
        public double SecondNumber { get; set; }

        public TestModel(Point position) : base(position) { }

    }
}
