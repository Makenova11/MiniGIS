using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGIS
{
    public class GridLayer:BaseLayer
    {
        double[,] matrix;
        public GridLayer(GridGeometry _gridGeometry)
        {
            gridGeometry = _gridGeometry;
            matrix = new double[_gridGeometry.CountY, _gridGeometry.CountX];
        }
        public GridLayer()
        {
            gridGeometry = null;

        }

        /// <summary>
        /// Получает значения матрицы
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public double GetNode(int i, int j)
        {
            return matrix[i, j];
        }
        /// <summary>
        /// Устанавливает значение матрицы
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="value"></param>
        public void SetNode(int i, int j, double value)
        {
            matrix[i, j] = value;
        }
        
     
        private GridGeometry gridGeometry;
        public GridGeometry GridGeometry
        {
            get { return gridGeometry; }
        }

        
        public override void Draw(PaintEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void LoadFromFile(string fileName)
        {
            throw new NotImplementedException();
        }

        protected override GeoRect GetBounce()
        {
            return null;
        }

        
    };
}
