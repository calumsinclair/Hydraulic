using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydraulic.HydraulicComponents.Positioners
{
    public abstract class Positioner{

        protected List<Positioner> Children = new List<Positioner>();
        void Apply(Positioner p)
        {
            Children.Add(p);
        }

        public static Positioner operator +(Positioner a, Positioner b)
        {
            a.Apply(b);
            return a;
        }

        public static Positioner operator *(Positioner a, float b)
        {
            a.Apply(new Mult(b));
            return a;
        }

        public static Positioner operator /(Positioner a, float b)
        {
            a.Apply(new Div(b));
            return a;
        }

        public static Positioner operator +(Positioner a, int b)
        {
            a.Apply(new Pixel(b));
            return a;
        }

        public static Positioner operator -(Positioner a, int b)
        {
            a.Apply(new Pixel(-b));
            return a;
        }

        public abstract int Resolve(int size, int pos);

        protected int ResolveChildren(int size, int pos)
        {
            foreach(var child in Children)
            {
                pos = child.Resolve(size, pos);
            }
            return pos;
        }

        public static T Pos<T>() where T : Positioner, new()
        {
            return new T();
        }

    }
}

