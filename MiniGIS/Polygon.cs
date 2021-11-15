using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGIS
{
    public class Polygon: Polyline
    {
        public System.Drawing.SolidBrush fill;
        public Polygon(): base()
        {
            fill = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
        }
        public override void Draw(PaintEventArgs e)
        {
            List<System.Drawing.Point> newNodes = new List<System.Drawing.Point>();
            System.Drawing.SolidBrush fill2 = fill;
            foreach (GeoPoint point in nodes)
            {
                newNodes.Add(layer.map.MapToScreen(point));
            }

            if (selected)
            {
                fill2 = new SolidBrush(layer.map.selectedColor);
            }
            System.Drawing.SolidBrush colour = new System.Drawing.SolidBrush(style.colour);
            System.Drawing.Pen pen = new System.Drawing.Pen(colour, style.width);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            e.Graphics.DrawPolygon(pen, newNodes.ToArray());
            e.Graphics.FillPolygon(fill2, newNodes.ToArray());
        }

        //строим горизонтальный отрезок и находим количество пересечений
        //если нечётное число - выделяем
        // чётное - не выделяем
        public override MapObject isCross(GeoRect search)
        {
            var lineLength = (double)((GetBounce().maxX - GetBounce().minX) * 1.1);
            var test_line = new Line(new GeoPoint((search.maxX + search.minX)/2, (search.maxY + search.minY)/2),
            new GeoPoint((search.maxX + search.minX) / 2 + lineLength, (search.maxY + search.minY) / 2));

            if (test_line.beginPoint.x >= GetBounce().minX && test_line.beginPoint.x <= GetBounce().maxX
            && test_line.beginPoint.y>= GetBounce().minY && test_line.beginPoint.y <=GetBounce().maxY)
            {
                int count = 0;
                GeoPoint p1 = nodes[nodes.Count - 1];
                GeoPoint p2;
                for (int i = 0; i < nodes.Count; i++)
                {
                    p2 = nodes[i];

                    if (GeoRect.isCrossLines(p1, p2, test_line.beginPoint, test_line.endPoint))
                    {
                        count++;
                    }

                    p1 = p2;
                }

                if (count % 2 == 1)
                {
                    return this;
                }
            }
            return null;
        }
    }
}
