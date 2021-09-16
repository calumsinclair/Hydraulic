using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hydraulic.HydraulicComponents.Positioners
{
    public class Top : Positioner
    {
        public override int Resolve(int size, int position)
        {
            position = 0;
            return ResolveChildren(size, position);
        }
    }

    public class Bottom : Positioner
    {
        public override int Resolve(int size, int position)
        {
            position = size;
            return ResolveChildren(size, position);
        }
    }

    public class Center : Positioner
    {
        public override int Resolve(int size, int position)
        {
            position = size/2;
            return ResolveChildren(size, position);
        }
    }


    public class Pixel : Positioner
    {
        private int _v;
        public Pixel(int v)
        {
            _v = v;
        }
        public override int Resolve(int size, int position)
        {
            position += _v;
            return ResolveChildren(size, position);
        }
    }

    public class Percent : Positioner
    {
        private float _pct;
        public Percent(float pct)
        {
            _pct = pct;
        }
        public override int Resolve(int size, int position)
        {
            position += (int)(size * _pct);
            return ResolveChildren(size, position);
        }
    }

    public class Mult : Positioner
    {
        private float _m;
        public Mult(float m)
        {
            _m = m;
        }
        public override int Resolve(int size, int position)
        {
            position = (int)(position *_m);
            return ResolveChildren(size, position);
        }
    }

    public class Div : Positioner
    {
        private float _m;
        public Div(float m)
        {
            _m = m;
        }
        public override int Resolve(int size, int position)
        {
            position = (int)(position / _m);
            return ResolveChildren(size, position);
        }
    }
}

