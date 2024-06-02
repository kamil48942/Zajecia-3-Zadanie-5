using System;
using System.Drawing;
using System.Windows.Forms;

namespace SinusoidApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Metoda rysująca sinusoidę w okienku aplikacji
        private void DrawSinusoid(Graphics g)
        {
            // Ustawienia pędzla i skali
            Pen pen = new Pen(Color.Blue, 2);
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;
            int amplitude = height / 4; // amplituda sinusoidy
            int centerY = height / 2; // środek osi Y

            // Rysowanie osi Y
            g.DrawLine(Pens.Black, width / 2, 0, width / 2, height);

            // Rysowanie osi X
            g.DrawLine(Pens.Black, 0, centerY, width, centerY);

            // Rysowanie sinusoidy
            for (int x = 0; x < width; x++)
            {
                double radians = (double)x / width * 2 * Math.PI * 4; 
                int y = centerY - (int)(amplitude * Math.Sin(radians));
                g.DrawEllipse(pen, x, y, 2, 2);
            }
        }

        // Przeciążona metoda OnPaint do rysowania na formularzu
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawSinusoid(e.Graphics);
        }

        // Metoda obsługująca zdarzenie Load formularza
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
