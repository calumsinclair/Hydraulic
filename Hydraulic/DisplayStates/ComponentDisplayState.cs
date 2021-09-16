using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hydraulic.HydraulicComponents.Properties;

namespace Hydraulic
{
    public class ComponentDisplayState
    {

        private string[] images = new string[1];
        private (int, int)[] image_sizes = new (int,int)[1];

        public ComponentDisplayState(string image)
        {
            images[0] = image;
            image_sizes[0] = (50,50);
        }

        public virtual string[] Images
        {
            get
            {
                return images;
            }
        }

        public virtual (int, int)[] ImageSize
        {
            get
            {
                return image_sizes;
            }
        }

        public virtual int RepresentativeIndex
        {
            get
            {
                return 0;
            }
        }

        public virtual void UpdateDisplayState(IProperties props) { }

        public virtual (int,int) Measure()
        {
            // Sum in x, Max in y
            return ImageSize.Aggregate(
                ((int, int) a, (int, int) b) => (a.Item1 + b.Item1, Math.Max(a.Item2, b.Item2))
            );
        }
    }
}
