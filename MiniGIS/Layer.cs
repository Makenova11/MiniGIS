using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniGIS
{
    public class Layer
    {
        public List<MapObject> objects = new List<MapObject>();
        public string name = "Noname";
        private bool visible = true;
        public bool Visible 
        {
            get
            {
                return visible;
            }
            set
            {
                visible = value;
                map.Refresh();
            }

        }

        public Map map;
        public GeoRect Bounce = new GeoRect(0,0,0,0);

        public async void LoadFromFile(string fileName)
        {
            using (FileStream fstream = File.OpenRead(fileName))
            {
                byte[] array = new byte[fstream.Length];
                
                await fstream.ReadAsync(array, 0, array.Length);

                string textFromFile = System.Text.Encoding.Default.GetString(array);

                string[] wordCoords = textFromFile.Split(new char[] {'\r', '\n'},
                    StringSplitOptions.RemoveEmptyEntries);

                Pen pen = new Pen(Color.Black,5);
                Line line = new Line(new GeoPoint(0,0),new GeoPoint(0,0));

                for(int i =0;i<wordCoords.Length;i++)
                {
                    if(wordCoords[i] == "LINE")
                    {
                        line = new Line(
                            new GeoPoint(Convert.ToDouble(wordCoords[i + 1]), Convert.ToDouble(wordCoords[i + 2])),
                            new GeoPoint(Convert.ToDouble(wordCoords[i + 3]), Convert.ToDouble(wordCoords[i + 4])));
                        this.AddObject(line);
                    }
                }


            }
            // 2 файла, 1 координатная система
            // 2 с объектами разных типов
            //отображаем только один,
            //можно делать вручную, а можно программно делать запись
            //сплитим по строкам, смотрим на ключевое слово первое и рисуем потом
        }
        public void AddObject(MapObject obj)
        {
            obj.layer = this;
            Bounce = GeoRect.Union(Bounce, obj.Bounce);
            objects.Add(obj);
        }
        public void DeleteObject(MapObject obj)
        {
            objects.Remove(obj);
        }
        public void InsertObject(int index, MapObject obj)
        {
            obj.layer = this;
            Bounce = GeoRect.Union(Bounce, obj.Bounce);
            objects.Insert(index, obj);
        }
        public void DeleteIndex(int index)
        {
            objects.RemoveAt(index);
        }

        public void Draw(PaintEventArgs e)
        {
            foreach (MapObject obj in objects)
            {
                obj.Draw(e);
            }
        }

        /// <summary>
        /// Если пересекается, то возвращаем объект
        /// </summary>
        /// <param name="search">точка на которую нажали</param>
        /// <returns></returns>
        public MapObject FindObject(GeoRect search)
        {
            MapObject result = null;
            for (int i = objects.Count - 1; i >= 0; i--)
            {
                result = objects[i].isCross(search);//пересекается ли объект с точкой, на которую нажали
                if (result != null)
                {
                    return result;
                }
            }

            return result;
        }
    }
}
