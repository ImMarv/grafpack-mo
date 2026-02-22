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
        Shape selectedShape = null;
        bool isDragging = false;
        PointF lastMousePos;

        public Canvas()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            canvas = new Bitmap(ClientSize.Width, ClientSize.Height);

            // TEMP TEST SHAPE
            shapes.Add(new Square(new PointF(200, 200), 100));
            shapes.Add(new Triangle(new PointF(200, 200), 100));
            shapes.Add(new Circle(new PointF(400, 200), 100, 10));

            Redraw();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(canvas, 0, 0);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            foreach (Shape s in shapes)
            {
                if (s.Vertices.Count > 0 &&
                    e.X >= s.Vertices[0].X - 30 && e.X <= s.Vertices[0].X + 30 &&
                    e.Y >= s.Vertices[0].Y - 30 && e.Y <= s.Vertices[0].Y + 30)
                {
                    selectedShape = s;
                    isDragging = true;
                    lastMousePos = e.Location;
                    break;
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isDragging && selectedShape != null)
            {
                float dx = e.X - lastMousePos.X;
                float dy = e.Y - lastMousePos.Y;
                selectedShape.Move(dx, dy);
                lastMousePos = e.Location;
                Redraw();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            isDragging = false;
            selectedShape = null;
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
