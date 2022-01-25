using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGIS
{
    public class Line : MapObject
    {
        public GeoPoint beginPoint;
        public GeoPoint endPoint;
        public LineStyle style;

        public Line(GeoPoint begin, GeoPoint end)
        {
            beginPoint = begin;
            endPoint = end;
            style = new LineStyle();
        }

        public Line(GeoPoint begin, GeoPoint end, LineStyle st)
        {
            beginPoint = begin;
            endPoint = end;
            style = st;
        }
        public override void Draw(PaintEventArgs e)
        {
            System.Drawing.Point begin = layer.map.MapToScreen(beginPoint);
            System.Drawing.Point end = layer.map.MapToScreen(endPoint);
            System.Drawing.SolidBrush colour = new System.Drawing.SolidBrush(style.colour);
            if (selected)
            {
                colour = new SolidBrush(layer.map.selectedColor);
            }
            System.Drawing.Pen pen = new System.Drawing.Pen(colour, style.width);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            e.Graphics.DrawLine(pen, begin.X, begin.Y, end.X, end.Y);
        }

        public override GeoRect GetBounce()
        {
            return new GeoRect(
                Math.Min(beginPoint.x, endPoint.x),
                Math.Max(beginPoint.x, endPoint.x),
                Math.Min(beginPoint.y, endPoint.y),
                Math.Max(beginPoint.y, endPoint.y)
            );
        }

        public override MapObject isCross(GeoRect search)
        {
            if (GeoRect.isCrossLines(beginPoint, endPoint, new GeoPoint(search.minX, search.minY),
                    new GeoPoint(search.minX, search.maxY)) ||
                GeoRect.isCrossLines(beginPoint, endPoint, new GeoPoint(search.minX, search.maxY),
                    new GeoPoint(search.maxX, search.maxY)) ||
                GeoRect.isCrossLines(beginPoint, endPoint, new GeoPoint(search.maxX, search.maxY),
                    new GeoPoint(search.maxX, search.minY)) ||
                GeoRect.isCrossLines(beginPoint, endPoint, new GeoPoint(search.maxX, search.minY),
                    new GeoPoint(search.minX, search.minY)))
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
