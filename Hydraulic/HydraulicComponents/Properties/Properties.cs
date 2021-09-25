using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace Hydraulic.HydraulicComponents.Properties
{
    public class ObservableProperty<T>
    {
        private T _value;
        private Properties _properties;
        public T Value
        {
            get
            {
                // insert desired logic here
                return _value;
            }
            set
            {
                // insert desired logic here
                if(!_value.Equals(value))
                {
                    _value = value;
                    _properties.Notify();
                }
            }
        }

        public ObservableProperty(Properties p) 
        {
            _properties = p;
        }

        public ObservableProperty(T value, Properties p)
        {
            _value = value;
            _properties = p;
        }

        public static implicit operator T(ObservableProperty<T> value)
        {
            return value.Value;
        }
    }

    public class Properties
    {
        public Action<Properties> OnPropertyChanged;

        public void UpdateValue(PropertyInfo prop, object value)
        {
            if (value.Equals(prop.GetValue(this)))
                return;

            prop.SetValue(this, value);
            Notify();
        }

        public void Notify()
        {
            OnPropertyChanged?.Invoke(this);
        }

    }
}
