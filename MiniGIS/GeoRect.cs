using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace MiniGIS
{
    public class GeoRect
    {
        public double minX;

        public double minY;

        public double maxY;

        public double maxX;

        public bool isExist
        {
            get
            {
                if (minX == 0 && maxX == 0 && minY == 0 && maxY == 0)
                {
                    return false;
                }

                return true;
            }
        }

        public GeoRect(double _minX, double _maxX, double _minY, double _maxY)
        {
            minX = _minX;
            maxX = _maxX;
            minY = _minY;
            maxY = _maxY;
        }

        public static GeoRect Union(GeoRect A, GeoRect B)
        {
            //проверка на null
            GeoRect C = new GeoRect(
                Math.Min(A.minX, B.minX),
                Math.Max(A.maxX, B.maxX),
                Math.Min(A.minY, B.minY),
                Math.Max(A.maxY, B.maxY)
                );

            return C;
        }

       
        public static bool isIntersect(GeoRect a, GeoRect b)
        {
            Rectangle rect1 = new Rectangle((int)a.minX, 
                                            (int)a.minY, 
                                            (int)a.maxX-(int)a.minX,
                                            (int)a.maxY-(int)a.minY);

            Rectangle rect2 = new Rectangle((int)b.minX,
                                            (int)b.minY,
                                            (int)b.maxX - (int)b.minX,
                                            (int)b.maxY - (int)b.minY);

            if (rect1.IntersectsWith(rect2))
            {
                return true;
            }

            return false;
        }

        private const double EPS = 1E-9;
        public static bool isCrossLines(GeoPoint a, GeoPoint b, GeoPoint c, GeoPoint d)
        {
            double A1 = (a.y - b.y);
            double B1 = (b.x - a.x);
            double C1 = (-A1 * a.x - B1 * a.y);
            double A2 = (c.y - d.y);
            double B2 = (d.x - c.x);
            double C2 = (-A2 * c.x - B2 * c.y);
            double zn = det(A1, B1, A2, B2);
            if (zn != 0)
            {
                double x = -det(C1, B1, C2, B2) * 1.0 / zn;
                double y = -det(A1, C1, A2, C2) * 1.0 / zn;

                return between(a.x, b.x, x) && between(a.y, b.y, y)
                                            && between(c.x, d.x, x) && between(c.y, d.y, y);
            }
            else
            
                return det(A1, C1, A2, C2) == 0 && det(B1, C1, B2, C2) == 0
                                                && intersect_1(a.x, b.x, c.x, d.x)
                                                && intersect_1(a.y, b.y, c.y, d.y);
            
        }

        private static double det(double a, double b, double c, double d)
        {
            return a * d - b * c;
        }

        private static bool between(double a, double b, double c)
        {
            return Math.Min(a, b) <= c + EPS && c <= Math.Max(a, b) + EPS;
        }

        private static bool intersect_1(double a, double b, double c, double d)
        {
            if(a>b)
            {
                double cur = a;
                a = b;
                b = cur;
            }

            if (c > 0)
            {
                double cur = c;
                c = d;
                d = cur;
            }

            return Math.Max(a, c) <= Math.Min(b, d);
        }
    }
}
