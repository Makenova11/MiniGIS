﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MiniGIS
{
    public enum mapToolType
    {
        zoomIn,
        zoomOut,
        hand,
        currentObject,
        ruler
    }
    public partial class Map : UserControl
    {
        public double mapScale = 1;
        public GeoPoint mapCenter = new GeoPoint(0, 0);
        public List<Layer> layers = new List<Layer>();
        public List<Layer> layers2 = new List<Layer>();
        public System.Drawing.Point mouseDownPosition;
        public bool isMouseDown = false;
        public Color selectedColor = Color.BlueViolet;
        public double rectSize = 2;
        public LayerControl layerControl;

        /// <summary>
        /// Объединяем слои
        /// </summary>
        public GeoRect Bounce
        {
            get
            {
                GeoRect geoRect = new GeoRect(0, 0, 0, 0);
                foreach (var i in layers)
                {
                    if (i.Visible)
                    {
                        geoRect = GeoRect.Union(geoRect, i.Bounce);
                    }
                }
                return geoRect;
            }
        }

        /// <summary>
        /// Центрирование
        /// </summary>
        public void zoomToAll()
        {
            mapCenter.x = (Bounce.minX + Bounce.maxX) / 2;
            mapCenter.y = (Bounce.minY + Bounce.maxY) / 2;

            double dX = (double)Math.Abs(Bounce.minX - Bounce.maxX);
            double dY = (double)Math.Abs(Bounce.minY - Bounce.maxY);

            if (dX / Width > dY / Height)
            {
                mapScale = (double)dX / (double)Width * 0.8;
            }
            else
            {
                mapScale = (double)dY / (double)Height * 0.8;
            }
            Refresh();

        }

        public Point p;
        public int shake = 10;
        public Size rectangleSize = new Size(1, 1);
        private Pen pen = new Pen(Color.Red);

        public mapToolType activeTool = mapToolType.hand;

        //ИДЗ Линейка
        public Line lineRuler;

        public Layer RulerLayer;
        //Прямоугольник
        public Layer Cosmetic;
        public Polyline Border;
        public GeoRect georect;
        List<GeoPoint> listGeopoint = new List<GeoPoint>();

        // Отслеживание клавиши
        public bool flag = false;

        public Map()
        {
            InitializeComponent();
            //var l = new Layer();
            //l.name = "Coords";
            //l.map = this;
            //layers.Add(l);


            //layers[0].AddObject(new Line(new GeoPoint(0, -200), new GeoPoint(0, 200)));
            //layers[0].AddObject(new Line(new GeoPoint(-200, 0), new GeoPoint(200, 0)));

            //var pl = new Polyline();

            //pl.style.colour = System.Drawing.Color.Blue;
            //pl.style.width = 4;
            //pl.AddNode(new GeoPoint(-50 + 10, -10));
            //pl.AddNode(new GeoPoint(-50 + 20, -30));
            //pl.AddNode(new GeoPoint(-50 + 30, -20));
            //pl.AddNode(new GeoPoint(-50 + 40, -40));
            //layers[0].AddObject(pl);

            //var pg = new Polygon();
            //pg.style.colour = System.Drawing.Color.BlueViolet;
            //pg.style.width = 2;

            //pg.AddNode(new GeoPoint(130, 10));
            //pg.AddNode(new GeoPoint(80, 100));
            //pg.AddNode(new GeoPoint(50, 30));
            //pg.fill = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
            //layers[0].AddObject(pg);


            //var x = new Point(new GeoPoint(200, 20));
            //var newstylex = new SymbolStyle(System.Drawing.Color.Black, 14, (byte)'X', "Century Gothic");
            //x.style = newstylex;
            //layers[0].AddObject(x);

            //var y = new Point(new GeoPoint(20, 180));
            //var newstyley = new SymbolStyle(System.Drawing.Color.Black, 14, (byte)'Y', "Century Gothic");
            //y.style = newstyley;
            //layers[0].AddObject(y);

            //Прямоугольник

            listGeopoint.Add(new GeoPoint(0, 0));
            listGeopoint.Add(new GeoPoint(0, 0));
            listGeopoint.Add(new GeoPoint(0, 0));
            listGeopoint.Add(new GeoPoint(0, 0));
            listGeopoint.Add(new GeoPoint(0, 0));

            Cosmetic = new Layer() { map = this };
            Border = new Polyline(listGeopoint);
            Cosmetic.AddObject(Border);
            layers.Add(Cosmetic);
            
            //новый слой 
            //Layer newLayer = new Layer();
            //newLayer.name = "Layer2";
            //newLayer.map = this;
            //var pg2 = new Polygon();
            //pg2.style.colour = System.Drawing.Color.Chartreuse;
            //pg2.style.width = 2;

            //pg2.AddNode(new GeoPoint(-130, -10));
            //pg2.AddNode(new GeoPoint(-80, -100));
            //pg2.AddNode(new GeoPoint(-50, -30));
            //pg2.fill = new System.Drawing.SolidBrush(System.Drawing.Color.Chartreuse);
            //newLayer.AddObject(pg2);
            //layers.Add(newLayer);

            //ИДЗ Линейка
            lineRuler = new Line(new GeoPoint(0, 0), new GeoPoint(0, 0));
            RulerLayer = new Layer();
            RulerLayer.name = "Ruler layer";
            RulerLayer.map = this;
            lineRuler.style.colour = Color.Gold;
            lineRuler.style.width = 2;
            RulerLayer.AddObject(lineRuler);
            layers.Add(RulerLayer);
        }

        public void AddLayer(Layer lr)
        {
            layers.Add(lr);
            lr.map = this;
            if (layerControl != null)
            {
                layerControl.RefreshList();
            }
        }
        public void DeleteLayer(Layer lr)
        {
            layers.Remove(lr);
            layerControl.RefreshList();
        }
        public void InsertLayer(int index, Layer lr)
        {
            layers.Insert(index, lr);
            lr.map = this;
            layerControl.RefreshList();
        }
        public void DeleteIndex(int index)
        {
            layers.RemoveAt(index);
            layerControl.RefreshList();
        }

        public System.Drawing.Point MapToScreen(GeoPoint point)
        {
            int x = (int)((point.x - mapCenter.x) * mapScale + Width / 2 + 0.5);
            int y = (int)((mapCenter.y - point.y) * mapScale + Height / 2 + 0.5);

            System.Drawing.Point MapToScreen = new System.Drawing.Point(x, y);
            return MapToScreen;
        }

        public GeoPoint ScreenToMap(System.Drawing.Point point)
        {
            int x = (int)((point.X - Width / 2) / mapScale + mapCenter.x);
            int y = (int)((Height / 2 - point.Y) / mapScale + mapCenter.y);

            GeoPoint ScreenToMap = new GeoPoint(x, y);
            return ScreenToMap;
        }

        private void Map_Paint(object sender, PaintEventArgs e)
        {
            foreach (Layer lr in layers)
            {
                if (lr.Visible)
                {
                    lr.Draw(e);
                }
            }

            //foreach (Layer lr in layers2)
            //{
            //    lr.Draw(e);
            //}
        }

        private void Map_MouseDown(object sender, MouseEventArgs e)
        {
            if (activeTool != mapToolType.ruler)
            {
                RulerLayer.DeleteObject(lineRuler);
                Refresh();
            }

            if (e.Button == MouseButtons.Left)
            {
                mouseDownPosition = e.Location;
                isMouseDown = true;
                p = new Point(e.X, e.Y);
            }
        }

        private void Map_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isMouseDown == true)
            {
                switch (activeTool)
                {
                    case mapToolType.zoomIn:
                        RulerLayer.DeleteObject(lineRuler);
                        Refresh();
                        if (Math.Abs(p.Location.y - e.Y) >= 10 || Math.Abs(p.Location.x - e.X) >= 10)
                        {

                            GeoPoint point1 = ScreenToMap(mouseDownPosition);
                            GeoPoint point2 = ScreenToMap(e.Location);
                            Cosmetic.DeleteObject(Border);
                            Border.nodes[0] = point1;
                            Border.nodes[1] = new GeoPoint(point2.x, point1.y);
                            Border.nodes[2] = point2;
                            Border.nodes[3] = new GeoPoint(point1.x, point2.y);
                            Border.nodes[4] = point1;


                            Cosmetic.AddObject(Border);
                            Refresh();
                        }


                        break;
                    case mapToolType.zoomOut:
                        RulerLayer.DeleteObject(lineRuler);
                        Refresh();
                        break;
                    case mapToolType.hand:
                        RulerLayer.DeleteObject(lineRuler);
                        Refresh();
                        var dx = (e.Location.X - mouseDownPosition.X) / mapScale;
                        var dy = (e.Location.Y - mouseDownPosition.Y) / mapScale;
                        mapCenter.x -= dx;
                        mapCenter.y += dy;
                        mouseDownPosition = e.Location;
                        Refresh();
                        break;
                    case mapToolType.currentObject:
                        RulerLayer.DeleteObject(lineRuler);
                        Refresh();
                        break;
                    case mapToolType.ruler:
                        GeoPoint p1 = ScreenToMap(mouseDownPosition);
                        GeoPoint p2 = ScreenToMap(e.Location);
                        RulerLayer.DeleteObject(lineRuler);
                        lineRuler.beginPoint = p1;
                        lineRuler.endPoint = p2;
                        
                        RulerLayer.AddObject(lineRuler);
                        Refresh();
                        break;
                    default:

                        break;

                }

            }
        }

        private MapObject FindObject(GeoRect search)
        {
            MapObject result = null;
            for (int i = layers.Count - 1; i >= 0; i--)
            {
                if (layers[i].Visible)
                {
                    result = layers[i].FindObject(search);
                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return result;
        }
        private void Map_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;

            switch (activeTool)
            {
                case mapToolType.zoomIn:
                    if (Math.Abs(p.Location.y - e.Y) >= 10 || Math.Abs(p.Location.x - e.X) >= 10)
                    {
                        Cosmetic.DeleteObject(Border);


                        mapCenter.x = (Border.nodes[0].x + Border.nodes[1].x) / 2;
                        mapCenter.y = (Border.nodes[0].y + Border.nodes[2].y) / 2;

                        double dX = Math.Abs(e.Location.X - mouseDownPosition.X);
                        double dY = Math.Abs(e.Location.Y - mouseDownPosition.Y);

                        if (dX / Width > dY / Height)
                        {
                            mapScale /= (double)dX / Height;
                        }
                        else
                        {
                            mapScale /= (double)dY / Height;
                        }

                        Refresh();

                    }
                    else
                    {
                        mapCenter = ScreenToMap(e.Location);
                        mapScale *= 1.25;
                        Refresh();
                    }

                    break;

                case mapToolType.zoomOut:

                    mapCenter = ScreenToMap(e.Location);
                    mapScale /= 1.25;
                    Refresh();

                    break;

                case mapToolType.hand:
                    var dx = (e.Location.X - mouseDownPosition.X) / mapScale;
                    var dy = (e.Location.Y - mouseDownPosition.Y) / mapScale;
                    mapCenter.x -= dx;
                    mapCenter.y -= dy;
                    mouseDownPosition = e.Location;
                    Refresh();
                    break;
                case mapToolType.currentObject:

                    if (Math.Abs(e.Location.X - mouseDownPosition.X) < shake ||
                        Math.Abs(e.Location.Y - mouseDownPosition.Y) < shake)
                    {
                        GeoPoint searchCenter = ScreenToMap(e.Location);
                        rectSize /= mapScale;
                        GeoRect search = new GeoRect(searchCenter.x - rectSize, searchCenter.x + rectSize,
                            searchCenter.y - rectSize, searchCenter.y + rectSize);

                        MapObject searchObject = FindObject(search);
                        if (flag)
                        {
                            if (searchObject != null) 
                            {
                                searchObject.selected = true;
                            }
                        }
                        else
                        {
                            foreach (var i in layers)
                            {
                                foreach (var j in i.objects)
                                {
                                    j.selected = false;

                                }
                            }
                            if (searchObject != null) // если нашли выделяем
                            {
                                searchObject.selected = true;
                            }
                            
                        }

                        Refresh();

                    }

                    break;
                case mapToolType.ruler:
                    
                    mouseDownPosition = e.Location;
                    //zoomToAll();
                    Refresh();
                    break;
            }

        }

        private void Map_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                flag = true;
            }
        }

        private void Map_KeyUp(object sender, KeyEventArgs e)
        {
            if (flag)
            {
                flag = false;
            }
        }
    }
}
