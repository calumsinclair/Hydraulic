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
        public Action<IProperties> ComponentSelected;

        public void OnComponentSpawned(int key)
        {
            ComponentSpawned?.Invoke(key);
        }

        public void OnComponentSelected(IProperties props)
        {
            ComponentSelected?.Invoke(props);
        }
    }
}
