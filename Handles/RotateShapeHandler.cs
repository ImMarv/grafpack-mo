using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace grafpack_2202368.Handles
{
    class RotateShapeHandler : IInteractionHandler
    {
        private List<Shape> shapes;
        private Shape selectedShape;
        private bool isRotating;
        private Action redraw;
        private float lastAngle;

        public RotateShapeHandler(List<Shape> shapes, Action redraw)
        {
            this.shapes = shapes;
            this.redraw = redraw;
        }

        public void OnMouseDown(MouseEventArgs e)
        {
            foreach (var s in shapes.AsEnumerable().Reverse())
            {
                if (s.HitTest(e.Location))
                {
                    selectedShape = s;
                    isRotating = true;

                    lastAngle = (float)Math.Atan2(
                        e.Y - s.Center.Y,
                        e.X - s.Center.X);

                    break;
                }
            }
        }

        public void OnMouseMove(MouseEventArgs e)
        {
            if (!isRotating || selectedShape == null)
                return;

            PointF center = selectedShape.GetBoundingBox().Location;

            float dx = e.X - center.X;
            float dy = e.Y - center.Y;

            float currentAngle = (float)Math.Atan2(dy, dx);

            float delta = currentAngle - lastAngle;
            float deltaDegrees = delta * (180f / (float)Math.PI);

            selectedShape.Rotate(deltaDegrees);

            lastAngle = currentAngle;

            redraw();
        }

        public void OnMouseUp(MouseEventArgs e)
        {
            isRotating = false;
            selectedShape = null;
        }
    }
}
