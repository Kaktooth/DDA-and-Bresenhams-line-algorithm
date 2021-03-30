using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsGrapics1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            pictureBox3.Image = new Bitmap(pictureBox3.Width, pictureBox3.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (var g = Graphics.FromImage(pictureBox1.Image))
            {
                Brush b = Brushes.Black;


                float x1 = Convert.ToInt32(textBox1.Text);
                float x2 = Convert.ToInt32(textBox3.Text);
                float y1 = Convert.ToInt32(textBox2.Text);
                float y2 = Convert.ToInt32(textBox4.Text);

                float X = 0;
                float Y = 0;

                float length = 0;
                if (Math.Abs(x2 - x1) >= Math.Abs(y2 - y1))
                {
                    length = Math.Abs(x2 - x1);
                }
                else length = Math.Abs(y2 - y1);

                float Px = (x2 - x1) / length;
                float Py = (y2 - y1) / length;

                X = x1 + 0.5f * Math.Sign(Px);
                Y = y1 + 0.5f * Math.Sign(Py);
                int i = 1;
                while (i < length)
                {
                    g.FillRectangle(b, X, Y, 1, 1);
                    X = X + Px;
                    Y = Y + Py;
                    i += 1;
                   
                }
                pictureBox1.Refresh();
            }
            stopwatch.Stop();
            label5.Text = stopwatch.Elapsed.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (var g = Graphics.FromImage(pictureBox2.Image))
            {
                Brush b = Brushes.Black;
                float x1 = Convert.ToInt32(textBox1.Text);
                float x2 = Convert.ToInt32(textBox3.Text);
                float y1 = Convert.ToInt32(textBox2.Text);
                float y2 = Convert.ToInt32(textBox4.Text);

                float x = x1;
                float y = y1;
                float Px = Math.Abs(x2 - x1);
                float Py = Math.Abs(y2 - y1);
               
                float s1 = Math.Sign(x2 - x1);
                float s2 = Math.Sign(y2 - y1);

                float temp = 0;
                int exchange = 0;
                if (Py > Px)
                {
                    temp = Px;
                    Px = Py;
                    Py = temp;
                    exchange = 1;
                }
                else exchange = 0;

                float E = 2 * Py - Px;

                for (int i = 1; i < (int)Px; i++)
                {
                    g.FillRectangle(b, (int)x, (int)y, 1, 1);

                    while (E >= 0)
                    {
                        
                        if (exchange == 1) x = x + s1;
                        else y = y + s2;
                        E = E - 2 * Px;  
                    }
                    if (exchange == 1) y = y + s2;
                    else x = x + s1;

                    E = E + 2 * Py;
                }
                pictureBox2.Refresh();
            }
            stopwatch.Stop();
            label6.Text = stopwatch.Elapsed.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (var g = Graphics.FromImage(pictureBox3.Image))
            {
                Pen b = Pens.Black;


                float x1 = Convert.ToInt32(textBox1.Text);
                float x2 = Convert.ToInt32(textBox3.Text);
                float y1 = Convert.ToInt32(textBox2.Text);
                float y2 = Convert.ToInt32(textBox4.Text);

                g.DrawLine(b, x1, y1, x2, y2);


                pictureBox3.Refresh();
            }
            stopwatch.Stop();
            label7.Text = stopwatch.Elapsed.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var g = Graphics.FromImage(pictureBox1.Image))
            {
                pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox2.Image = new Bitmap(pictureBox2.Width, pictureBox2.Height);
                pictureBox3.Image = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            }
        }
    }
}
