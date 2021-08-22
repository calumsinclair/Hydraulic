using Hydraulic.HydraulicComponents.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydraulic
{

    public class AppEvents
    {
        public record ComponentProps(IProperties props, string image);
        public event EventHandler<ComponentProps> ComponentClicked;

        public virtual void OnComponentClicked(IProperties props, string image)
        {
            ComponentClicked?.Invoke(this, new ComponentProps(props, image));
        }
    }
}
