using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MiniGIS
{
    public class SymbolStyle
    {
        public System.Drawing.Color colour;
        public int size;
        public byte type;
        public string font;

        public SymbolStyle()
        {
            colour = System.Drawing.Color.Aqua;
            size = 16;
            type = 0xD0;
            font = "Wingdings";
        }

        public SymbolStyle(System.Drawing.Color c, int s, byte t, string f)
        {
            colour = c;
            size = s;
            type = t;
            font = f;
        }

    }
}
