using grafpack_2202368.Shapes;
using grafpack_2202368.shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafpack_2202368.Handles
{
    class CreateShapeHandler : IInteractionHandler
    {
        private readonly List<Shape> shapes;
        private readonly ShapeType shapeType;
        private readonly Action redraw;

        private bool isCreating;
        private PointF startPoint;
        private PointF lastMousePos;
        private Shape previewShape = null;
        public Shape PreviewShape => previewShape;

        public CreateShapeHandler(List<Shape> shapes, Action redraw, ShapeType shape)
        { 
            this.shapes = shapes;
            this.redraw = redraw;
            this.shapeType = shape;
        }
        
        public void OnMouseDown(MouseEventArgs e)
        {
            startPoint = e.Location;
            isCreating = true;
        }

        public void OnMouseMove(MouseEventArgs e)
        {
            if (!isCreating) return;
            float dx = e.X - startPoint.X;
            float dy = e.Y - startPoint.Y;

            float size = Math.Max(Math.Abs(dx), Math.Abs(dy));

            switch (shapeType) 
            {
                case ShapeType.Square:
                    previewShape = new Square(startPoint, size);
                    break;
                case ShapeType.Circle:
                    float radius = (float)Math.Sqrt(dx * dx + dy * dy);
                    previewShape = new Circle(startPoint, radius, 60);
                    break;
                case ShapeType.Triangle:
                    previewShape = new Triangle(startPoint, size);
                    break;
            }
            redraw();
        }

        public void OnMouseUp(MouseEventArgs e)
        {
            if (!isCreating || previewShape == null) return;

            shapes.Add(previewShape);
            previewShape = null;
            isCreating = false;

            redraw();
        }
    }
}

