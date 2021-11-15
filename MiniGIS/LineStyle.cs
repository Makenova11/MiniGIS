using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGIS
{
    public class LineStyle
    {
        public int width;
        public int type;
        public System.Drawing.Color colour;

        public LineStyle()
        {
            width = 4;
            type = 10;
            colour = System.Drawing.Color.Aqua;
        }

        public LineStyle(int w, byte t, System.Drawing.Color c)
        {
            width = w;
            type = t;
            colour = c;
        }
    }
}
