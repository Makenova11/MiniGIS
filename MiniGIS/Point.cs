using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGIS
{
    public class GeoPoint
    {
        public double x;
        public double y;

        public GeoPoint(double x1, double y1)
        {
            x = x1;
            y = y1;
        }
    }

    public class Point : MapObject
    {
        public GeoPoint Location;
        public SymbolStyle style;
        public Point (GeoPoint point)
        {
            Location = point;
            style = new SymbolStyle();
        }
        public Point(double x1, double y1)
        {
            Location = new GeoPoint(x1, y1);
            style = new SymbolStyle();
        }

        public override void Draw(PaintEventArgs e)
        {
            System.Drawing.Point point = layer.map.MapToScreen(Location);
            string s = Convert.ToChar(style.type).ToString();
            System.Drawing.Font f = new System.Drawing.Font(style.font, style.size);
            var ms = e.Graphics.MeasureString(s, f);
            point.X -= (int)(ms.Width / 2);
            point.Y -= (int)(ms.Height / 2);
            System.Drawing.SolidBrush colour;
            if (selected)
            {

                colour = new SolidBrush(layer.map.selectedColor);
            }
            else
            {
                colour = new System.Drawing.SolidBrush(style.colour);
            }
            e.Graphics.DrawString(s, f, colour, point);
        }

        public override GeoRect GetBounce()
        {
            return new GeoRect(Location.x, Location.x,Location.y,Location.y);
        }

        public override MapObject isCross(GeoRect search)
        {
            Graphics grafics = layer.map.CreateGraphics();
            string symbol = Convert.ToChar(style.type).ToString();
            Font font = new Font(style.font, style.size);
            SizeF size = grafics.MeasureString(symbol, font);

            GeoRect rect = new GeoRect(Location.x - size.Width / (2 * layer.map.mapScale),
                Location.x + size.Width / (2 * layer.map.mapScale),
                Location.y - size.Height / (2 * layer.map.mapScale),
                Location.y + size.Height / (2 * layer.map.mapScale));

            if (GeoRect.isIntersect(search,rect))
            {
                return this;
            }
            else
            {
                return null;
            }

        }
    }
}
