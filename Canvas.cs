using grafpack_2202368.Shapes;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace grafpack_2202368
{
    public partial class Canvas : Form
    {
        Bitmap canvas;
        List<Shape> shapes = new List<Shape>();

        public Canvas()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            canvas = new Bitmap(ClientSize.Width, ClientSize.Height);

            // TEMP TEST SHAPE
            shapes.Add(new Square(new PointF(200, 200), 100));

            Redraw();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(canvas, 0, 0);
        }

        void Redraw()
        {
            canvas = new Bitmap(ClientSize.Width, ClientSize.Height);

            foreach (Shape s in shapes)
            {
                s.Draw(canvas);
            }

            Invalidate();
        }
    }
}
