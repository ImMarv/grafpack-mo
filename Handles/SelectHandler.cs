using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace grafpack_2202368.Handles
{
    class SelectHandler : IInteractionHandler
    {
        private List<Shape> shapes;
        private Action redraw;

        public SelectHandler(List<Shape> shapes, Action redraw)
        {
            this.shapes = shapes;
            this.redraw = redraw;
        }

        public void OnMouseDown(MouseEventArgs e)
        {
            Shape hitShape = null;

            // check topmost first
            for (int i = shapes.Count - 1; i >= 0; i--)
            {
                if (shapes[i].HitTest(e.Location))
                {
                    hitShape = shapes[i];
                    break;
                }
            }

            // clear previous selections
            foreach (Shape s in shapes)
                s.IsSelected = false;

            // select new shape
            if (hitShape != null)
                hitShape.IsSelected = true;

            redraw();
        }

        public void OnMouseMove(MouseEventArgs e) { }

        public void OnMouseUp(MouseEventArgs e) { }
    }
}