using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace Hydraulic.HydraulicComponents.Properties
{
    public class Properties
    {
        public Action<Properties> Observer;

        /*
        public Properties (Action<Properties> newObserver)
        {
            Observer = newObserver;
        }*/

        public void UpdateValue(PropertyInfo prop, string value)
        {
            prop.SetValue(this, StringToProperty(prop, value));
            Notify();
        }

        void Notify()
        {
            Observer?.Invoke(this);
        }

        private object StringToProperty(PropertyInfo prop, string value)
        {
            if (prop.PropertyType.IsEnum)
                return Enum.Parse(prop.PropertyType, value);
            else if (prop.PropertyType == typeof(int))
                return int.Parse(value);
            else if (prop.PropertyType == typeof(float))
                return float.Parse(value);

            throw new Exception("Unsupported Type");
        }
    }
}
