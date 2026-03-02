using grafpack_2202368.Handles;
using grafpack_2202368.Shapes;
using grafpack_2202368.shared;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace grafpack_2202368
{
    public partial class Canvas : Form
    {
        enum ShapeMode
        {
            None,
            CreateSquare,
            CreateCircle,
            CreateTriangle,
            Move,
            Rotate,
            Delete,
            Scale
        }
        IInteractionHandler currentHandler;
        Bitmap canvas;
        List<Shape> shapes = new List<Shape>();
        public Canvas()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            canvas = new Bitmap(ClientSize.Width, ClientSize.Height);

            // TEMP TEST SHAPE
            shapes.Add(new Square(new PointF(200, 200), 100));
            shapes.Add(new Triangle(new PointF(200, 200), 100));
            shapes.Add(new Circle(new PointF(400, 200), 100, 10));

            SetCreateSquareMode();
            Redraw();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(canvas, 0, 0);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            currentHandler?.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            currentHandler?.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            currentHandler?.OnMouseUp(e);
        }
        public Shape PreviewShape
        {
            get
            {
                if (currentHandler is CreateShapeHandler createHandler)
                    return createHandler.PreviewShape;

                return null;
            }
        }

        void Redraw()
        {
            using (Graphics g = Graphics.FromImage(canvas))
            {
                g.Clear(Color.White);
            }

            foreach (Shape s in shapes)
            {
                s.Draw(canvas);
            }

            PreviewShape?.Draw(canvas);

            Invalidate();
        }

        void SetCreateSquareMode()
        {
            currentHandler = new CreateShapeHandler(
                shapes,
                Redraw,
                ShapeType.Square);
        }

        void SetCreateCircleMode()
        {
            currentHandler = new CreateShapeHandler(
                shapes,
                Redraw,
                ShapeType.Circle
                );
        }

        void SetCreateTriangleMode()
        {
            currentHandler = new CreateShapeHandler(
                shapes,
                Redraw,
                ShapeType.Triangle);
        }
    }
}
