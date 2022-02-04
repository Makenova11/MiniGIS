using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGIS
{
    public abstract class MapObject
    {
        public BaseLayer layer;
        public abstract void Draw(PaintEventArgs e);

        public bool selected = false;

        public GeoRect Bounce
        {
            get
            {
                return GetBounce();
            }
        }

        public abstract GeoRect GetBounce();

        public abstract MapObject isCross(GeoRect search);
    }
}
