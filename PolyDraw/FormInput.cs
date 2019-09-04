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
    public partial class FormInput : Form
    {
        List<List<PointF>> polygons;
        Graphics g;
        Pen pen;
        FormRes fr;

        public FormInput()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            float.TryParse(textBox1.Text, out Global.offX);
            float.TryParse(textBox2.Text, out Global.offY);
            float.TryParse(textBox3.Text, out Global.zoom);
            g = e.Graphics;
            g.ScaleTransform(Global.zoom, Global.zoom);
            g.TranslateTransform(Global.offX, Global.offY);

            pen = new Pen(Color.Black, .01f);
            foreach (List<PointF> p in polygons) {
                //Console.WriteLine(p.First().X + " - " + p.First().Y);
                g.DrawPolygon(pen, p.ToArray());
            }

            g.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            polygons = new List<List<PointF>>();
            //var lines = File.ReadLines(@"E:\Downloads\poly\poly1.txt");
            var lines = File.ReadLines(@Global.inputData);
            List<PointF> poly = new List<PointF>();
            bool first = true;
            foreach (var line in lines)
            {
                if (!line.Trim().Equals(""))
                {
                    //Console.WriteLine(line);
                    string[] tmp = line.Split(',');
                    if (first) {
                        Global.offX = -1 * float.Parse(tmp[0], CultureInfo.InvariantCulture) + 10;
                        Global.offY = -1 * float.Parse(tmp[1], CultureInfo.InvariantCulture) + 10;
                        textBox1.Text = Global.offX.ToString();
                        textBox2.Text = Global.offY.ToString();
                        first = false;
                    }
                    poly.Add(new PointF(float.Parse(tmp[0], CultureInfo.InvariantCulture), float.Parse(tmp[1], CultureInfo.InvariantCulture)));

                }
                else
                {
                    if (poly.Count != 0)
                        polygons.Add(poly);
                    poly = new List<PointF>();
                }
            }

            fr = new FormRes();
            fr.Show();
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (float.TryParse(textBox3.Text, out Global.zoom) == false)
            {
                Global.zoom = 1;
                textBox3.Text = "1";
            }
            this.Invalidate();
            fr.Invalidate();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (float.TryParse(textBox1.Text, out Global.offX) == false)
            {
                Global.offX = 0;
                textBox1.Text = "0";
            }
            this.Invalidate();
            fr.Invalidate();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (float.TryParse(textBox2.Text, out Global.offY) == false)
            {
                Global.offY = 0;
                textBox2.Text = "0";
            }
            this.Invalidate();
            fr.Invalidate();
        }
    }
}
