using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGIS
{
    public class Polyline : MapObject
    {
        public List<GeoPoint> nodes = new List<GeoPoint>();
        public LineStyle style;

        public Polyline()
        {
            style = new LineStyle();
        }
        public Polyline(List<GeoPoint> list)
        {
            style = new LineStyle();

            foreach (var i in list)
            {
                nodes.Add(i);
            }
        }

        public void DeleteNode(GeoPoint node)
        {
            nodes.Remove(node);
        }

        public void DeleteIndex(int index)
        {
            nodes.RemoveAt(index);
        }

        public void AddNode(GeoPoint node)
        {
            nodes.Add(node);
        }

        public void InsertNode(GeoPoint node, int index)
        {
            nodes.Insert(index, node);
        }

        public override void Draw(PaintEventArgs e)
        {
            List<System.Drawing.Point> newNodes = new List<System.Drawing.Point>();
            foreach (GeoPoint point in nodes)
            {
                newNodes.Add(layer.map.MapToScreen(point));
            }
            System.Drawing.SolidBrush colour = new System.Drawing.SolidBrush(style.colour);
            if (selected) colour = new SolidBrush(layer.map.selectedColor);
            System.Drawing.Pen pen = new System.Drawing.Pen(colour, style.width);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            e.Graphics.DrawLines(pen, newNodes.ToArray());
        }

        public override GeoRect GetBounce()
        {
            double minX = nodes.Select( c => c.x).Min();
            double minY = nodes.Select(c => c.y).Min();
            double maxX = nodes.Select(c => c.x).Max();
            double maxY = nodes.Select(c => c.y).Max();

            return new GeoRect(minX, maxX, minY, maxY);
        }

        public override MapObject isCross(GeoRect search)
        {
            for (int i = 0; i < nodes.Count-1; i++)
            {
                if(GeoRect.isCrossLines(new GeoPoint(nodes[i].x, nodes[i].y),
                       new GeoPoint(nodes[i + 1].x, nodes[i + 1].y), 
                       new GeoPoint(search.minX, search.minY),
                       new GeoPoint(search.minX, search.maxY)) ||
                   GeoRect.isCrossLines(new GeoPoint(nodes[i].x, nodes[i].y),
                       new GeoPoint(nodes[i + 1].x, nodes[i + 1].y),
                       new GeoPoint(search.minX, search.maxY),
                       new GeoPoint(search.maxX, search.maxY)) ||
                   GeoRect.isCrossLines(new GeoPoint(nodes[i].x, nodes[i].y),
                       new GeoPoint(nodes[i + 1].x, nodes[i + 1].y),
                       new GeoPoint(search.maxX, search.maxY),
                       new GeoPoint(search.maxX, search.minY)) ||
                   GeoRect.isCrossLines(new GeoPoint(nodes[i].x, nodes[i].y),
                       new GeoPoint(nodes[i + 1].x, nodes[i + 1].y),
                       new GeoPoint(search.maxX, search.minY),
                       new GeoPoint(search.minX, search.minY))
                )
                {
                    return this;
                }
            }
            return null;
        }
    }
}
