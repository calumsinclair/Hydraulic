using Hydraulic.HydraulicComponents.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydraulic
{
    public class SpawnEvents
    {
        public record ComponentProps(IProperties props, string image);
        public Action<int> ComponentClicked;

        public void OnComponentClicked(int key)
        {
            ComponentClicked?.Invoke(key);
        }
    }
}
