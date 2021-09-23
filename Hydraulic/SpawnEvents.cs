using Hydraulic.HydraulicComponents.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydraulic
{
    public class SpawnEvents
    {
        public Action<int> ComponentSpawned;
        public Action<Properties> ComponentSelected;

        public void OnComponentSpawned(int key)
        {
            ComponentSpawned?.Invoke(key);
        }

        public void OnComponentSelected(Properties props)
        {
            ComponentSelected?.Invoke(props);
        }

    }
}
