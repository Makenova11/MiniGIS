using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGIS
{
    public abstract class BaseLayer
    {
        public string name = "Noname";
        private bool visible = true;
        public bool Visible 
        {
            get
            {
                return visible;
            }
            set
            {
                visible = value;
                map.Refresh();
            }

        }

        public Map map;
        public GeoRect Bounds
        {
            get
            {
                return GetBounce();
            }
        }
        protected abstract GeoRect GetBounce();

        public abstract void Draw(PaintEventArgs e);
        public abstract void LoadFromFile(string fileName);
    }
}
