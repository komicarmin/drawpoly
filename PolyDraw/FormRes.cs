using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolyDraw
{
    public partial class FormRes : Form
    {
        List<List<PointF>> polygons;
        Graphics g;
        Pen pen;

        public FormRes()
        {
            InitializeComponent();
        }

        private void FormRes_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.ScaleTransform(Global.zoom, Global.zoom);
            g.TranslateTransform(Global.offX, Global.offY);

            pen = new Pen(Color.Black, .01f);
            foreach (List<PointF> p in polygons)
            {
                //Console.WriteLine(p.First().X + " - " + p.First().Y);
                g.DrawPolygon(pen, p.ToArray());
            }

            g.Dispose();
        }

        private void FormRes_Load(object sender, EventArgs e)
        {
            polygons = new List<List<PointF>>();
            //var lines = File.ReadLines(@"E:\Downloads\poly\poly1.txt");
            var lines = File.ReadLines(@Global.resData);
            List<PointF> poly = new List<PointF>();
            foreach (var line in lines)
            {
                if (!line.Trim().Equals(""))
                {
                    //Console.WriteLine(line);
                    string[] tmp = line.Split(',');
                    //Console.WriteLine(float.Parse(tmp[0]));
                    poly.Add(new PointF(float.Parse(tmp[0], CultureInfo.InvariantCulture), float.Parse(tmp[1], CultureInfo.InvariantCulture)));

                }
                else
                {
                    if (poly.Count != 0)
                        polygons.Add(poly);
                    poly = new List<PointF>();
                }
            }

        }
    }
}
