using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace Hydraulic.HydraulicComponents.Properties
{
    public class Properties
    {
        public Action<Properties> OnPropertyChanged;

        public void UpdateValue(PropertyInfo prop, object value)
        {
            prop.SetValue(this, value);
            Notify();
        }

        void Notify()
        {
            OnPropertyChanged?.Invoke(this);
        }
    }
}
