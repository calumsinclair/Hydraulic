﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hydraulic.HydraulicComponents.Properties;

namespace Hydraulic
{
    public class ComponentDisplayState
    {

        private string[] images = new string[1];
        public ComponentDisplayState(string image)
        {
            images[0] = image;
        }

        public virtual string[] Images
        {
            get
            {
                return images;
            }
        }

        public string RepresentativeImage
        {
            get
            {
                return images[0];
            }
        }

        public virtual void UpdateDisplayState(IProperties props) { }
    }
}