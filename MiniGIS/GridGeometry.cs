using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniGIS
{
    public class GridGeometry
    {
        public GridGeometry(double _xMin, double _yMin, int _countX, int _countY, double _cell)
        {
            xMin = _xMin;
            yMin = _yMin;
            countX = _countX;
            countY = _countY;
            cell = _cell;
        }
        private double xMin;
        private double yMin;
        private int countX;
        private int countY;
        private double cell;

        public double XMin => xMin;
        public double XMax 
        {
            get
            {
                return xMin + cell * countX;
            }
          }

        public double YMax 
        { 
            get
            {
                return yMin + cell * countY;
            } 
        }
        public double YMin => yMin;
        public int CountX => countX;
        public int CountY => countY;
        public double Cell => cell;

    }
}
