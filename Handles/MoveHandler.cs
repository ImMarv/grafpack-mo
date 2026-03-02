using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace grafpack_2202368.Handles
{
    class MoveHandler : IInteractionHandler
    {
        private List<Shape> shapes;
        private Shape selectedShape;
        private bool isMoving;
        private PointF lastMousePos;
        private Action redraw;
        public MoveHandler(List<Shape> shapes, Action redraw)
        {
            this.shapes = shapes;
            this.redraw = redraw;
        }

        public void OnMouseDown(MouseEventArgs e)
        {
            for (int i = shapes.Count - 1; i >= 0; i--)
            {

                if (shapes[i].HitTest(e.Location))
                {
                    selectedShape = shapes[i];
                    isMoving = true;
                    lastMousePos = e.Location;
                    break;
                }
            }
        }

        public void OnMouseMove(MouseEventArgs e)
        {
            if (isMoving && selectedShape != null)
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
            isMoving = false;
            selectedShape = null;
        }
    }
}
