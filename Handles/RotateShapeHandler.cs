using grafpack_2202368.shared;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafpack_2202368.Handles
{
    class RotateShapeHandler : IInteractionHandler
    {
        private List<Shape> shapes;
        private Shape selectedShape;
        private bool isRotating;
        private Action redraw;

        public RotateShapeHandler(List<Shape> shapes, Action redraw)
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
                    isRotating = true;
                    break;
                }
            }
        }

        public void OnMouseMove(MouseEventArgs e)
        {
            float currentAngle = 0;
            // calculate the angle based on mouse movement and shape center.
            if (isRotating) {
                PointF center = selectedShape.GetBoundingBox().Location;
                float dx = e.X - center.X;
                float dy = e.Y - center.Y;
                currentAngle = (float)(Math.Atan2(dy, dx) * 180 / Math.PI);
            }
            
            if (currentAngle > 0)
            {
                ++currentAngle;
            } else
            {
                --currentAngle;
            }
            if (isRotating && selectedShape != null)
            {
                selectedShape.Rotate(currentAngle);
                redraw();
            }
        }

        public void OnMouseUp(MouseEventArgs e)
        {
            isRotating = false;
            selectedShape = null;
        }
    }
}
