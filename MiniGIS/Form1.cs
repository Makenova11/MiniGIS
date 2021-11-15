using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGIS
{
    public partial class MiniGIS_Makenova : Form
    {
        public MiniGIS_Makenova()
        {
            InitializeComponent();
            layerControl1.map = map1;
            map1.layerControl = layerControl1;
            layerControl1.RefreshList();
            
        }

        private double lineBeginx;//ИДЗ для хранения н.з. х
        private void toolStripButton_ZoomIn_Click(object sender, EventArgs e)
        {
            map1.activeTool = mapToolType.zoomIn; // подумать над выделением при нажатии

            toolStripButton_ZoomIn.Checked = true;
            toolStripRulerLabel.Visible = false;
            toolStripButton_ZoomOut.Checked = false;
            toolStripButton_Hand.Checked = false;
            toolStripButton_Center.Checked = false;
            toolStripButton_CurrentObject.Checked = false;
            RulerStripButton.Checked = false;
        }

        private void toolStripButton_ZoomOut_Click(object sender, EventArgs e)
        {
            map1.activeTool = mapToolType.zoomOut;
            toolStripButton_ZoomOut.Checked = true;
            toolStripRulerLabel.Visible = false;
            toolStripButton_ZoomIn.Checked = false;
            toolStripButton_Hand.Checked = false;
            toolStripButton_Center.Checked = false;
            toolStripButton_CurrentObject.Checked = false;
            RulerStripButton.Checked = false;

        }

        private void toolStripButton_Hand_Click(object sender, EventArgs e)
        {
            map1.activeTool = mapToolType.hand;
            toolStripButton_Hand.Checked = true;
            toolStripRulerLabel.Visible = false;
            toolStripButton_ZoomIn.Checked = false;
            toolStripButton_ZoomOut.Checked = false;
            toolStripButton_Center.Checked = false;
            toolStripButton_CurrentObject.Checked = false;
            RulerStripButton.Checked = false;
        }

        private void toolStripButton_CurrentObject_Click(object sender, EventArgs e)
        {
            map1.activeTool = mapToolType.currentObject;
            toolStripButton_Center.Checked = true;
            toolStripRulerLabel.Visible = false;
            toolStripButton_ZoomIn.Checked = false;
            toolStripButton_ZoomOut.Checked = false;
            toolStripButton_Hand.Checked = false;
            toolStripButton_Center.Checked = false;
            RulerStripButton.Checked = false;
        }

        /// <summary>
        /// Центрирование
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_Center_Click(object sender, EventArgs e)
        {
            map1.zoomToAll();
            toolStripRulerLabel.Visible = false;
            toolStripButton_ZoomIn.Checked = false;
            toolStripButton_ZoomOut.Checked = false;
            toolStripButton_Hand.Checked = false;
            toolStripButton_CurrentObject.Checked = false;
            RulerStripButton.Checked = false;
        }

        private void map1_MouseMove(object sender, MouseEventArgs e)
        {
            //lineBeginx = e.X;
            //if (map1.activeTool == mapToolType.ruler)
            //{
            //    toolStripRulerLabel.Text = "Значение вычисляется";
            //}

            toolStripStatusLabel1.Text = "(" + e.X + "," + e.Y + ")";
            var newpoint = map1.ScreenToMap(e.Location);
            toolStripStatusLabel2.Text = "(" + newpoint.x + "," + newpoint.y + ")";
            var point = map1.MapToScreen(newpoint);
            toolStripStatusLabel3.Text = "(" + point.X + "," + point.Y + ")";
        }

        /// <summary>
        /// ИДЗ Линейка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RulerStripButton_Click(object sender, EventArgs e)
        {
            map1.activeTool = mapToolType.ruler;
            toolStripRulerLabel.Visible = true;
            RulerStripButton.Checked = true;



            toolStripButton_ZoomIn.Checked = false;
            toolStripButton_ZoomOut.Checked = false;
            toolStripButton_Hand.Checked = false;
            toolStripButton_Center.Checked = false;
            toolStripButton_CurrentObject.Checked = false;
        }

        private void map1_MouseUp(object sender, MouseEventArgs e)
        {
            if (map1.activeTool == mapToolType.ruler)
            {
                double resultRuler = Math.Round(e.X - lineBeginx,2);
                toolStripRulerLabel.Text = "Длина равна " + Math.Abs(resultRuler).ToString();
            }
        }

        private void map1_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (map1.activeTool == mapToolType.ruler)
            {
                lineBeginx = e.X;
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (MifFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (MifFileDialog.FileName != null)
                {
                    try
                    {
                        Layer mifLayer = new Layer();
                        mifLayer.name = MifFileDialog.FileName;
                        mifLayer.LoadFromFile(MifFileDialog.FileName);
                        map1.AddLayer(mifLayer);
                        
                        map1.zoomToAll();
                        map1.Refresh();
                        layerControl1.RefreshList();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Ошибка открытия файла ", exception.Message);
                    }
                }
            }
        }
    }
}
