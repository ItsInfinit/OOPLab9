using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace InfOOPLab9
{
    public partial class Form1 : Form
    {
        private float r;
        private float h;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            r = (float)double.Parse(rTextBox.Text);
            h = (float)double.Parse(hTextBox.Text);

            Bitmap bitmap = new Bitmap(graphicDraw.Width, graphicDraw.Height);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.Clear(Color.White);

                double scaleX = graphicDraw.Width / 20.0;
                double scaleY = graphicDraw.Height / 20.0;

                DrawCoordinateSystem(graphics, scaleX, scaleY);

                DrawFunction(graphics, scaleX, scaleY);
            }

            graphicDraw.Image = bitmap;
        }

        private void DrawCoordinateSystem(Graphics graphics, double scaleX, double scaleY)
        {
            graphics.DrawLine(Pens.Black, 0, graphicDraw.Height / 2, graphicDraw.Width, graphicDraw.Height / 2);
            graphics.DrawLine(Pens.Black, graphicDraw.Width / 2, 0, graphicDraw.Width / 2, graphicDraw.Height);

            graphics.DrawString("X", DefaultFont, Brushes.Black, graphicDraw.Width - 20, graphicDraw.Height / 2 - 15);
            graphics.DrawString("Y", DefaultFont, Brushes.Black, graphicDraw.Width / 2 + 5, 5);

            for (int i = -10; i <= 10; i++)
            {
                int x = graphicDraw.Width / 2 + (int)(i * scaleX);
                graphics.DrawString(i.ToString(), DefaultFont, Brushes.Black, x, graphicDraw.Height / 2 + 5);
            }

            for (int i = -10; i <= 10; i++)
            {
                int y = graphicDraw.Height / 2 - (int)(i * scaleY);
                graphics.DrawString(i.ToString(), DefaultFont, Brushes.Black, graphicDraw.Width / 2 - 15, y);
            }
        }

        private void DrawFunction(Graphics graphics, double scaleX, double scaleY)
        {
            int numPoints = 100;

            double tMin = 0;
            double tMax = 2 * Math.PI;

            double xPrev = r * tMin - h * Math.Sin(tMin);
            double yPrev = r - h * Math.Cos(tMin);
            int pixelXPrev = graphicDraw.Width / 2 + (int)(xPrev * scaleX);
            int pixelYPrev = graphicDraw.Height / 2 - (int)(yPrev * scaleY);

            for (int i = 1; i <= numPoints; i++)
            {
                double t = tMin + (i / (double)numPoints) * (tMax - tMin);

                double x = r * t - h * Math.Sin(t);
                double y = r - h * Math.Cos(t);

                int pixelX = graphicDraw.Width / 2 + (int)(x * scaleX);
                int pixelY = graphicDraw.Height / 2 - (int)(y * scaleY);

                graphics.DrawLine(Pens.Red, pixelXPrev, pixelYPrev, pixelX, pixelY);

                xPrev = x;
                yPrev = y;
                pixelXPrev = pixelX;
                pixelYPrev = pixelY;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
    }
}
