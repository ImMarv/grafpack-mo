using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafpack_2202368.Handles
{
    class MoveHandler : IInteractionHandler
    {
        private List<Shape> shapes;
        private Shape selectedShape;
        private bool isDragging;
        private PointF lastMousePos;
        private Action redraw;
        public MoveHandler(List<Shape> shapes, Action redraw)
        {
            this.shapes = shapes;
            this.redraw = redraw;
        }

        public void OnMouseDown(MouseEventArgs e)
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

        public void OnMouseMove(MouseEventArgs e)
        {
            if (isDragging && selectedShape != null)
            {
                float dx = e.X - lastMousePos.X;
                float dy = e.Y - lastMousePos.Y;
                selectedShape.Move(dx, dy);
                lastMousePos = e.Location;
                redraw();
            }
        }

        public void OnMouseUp(MouseEventArgs e)
        {
            isDragging = false;
            selectedShape = null;
        }
    }
}
