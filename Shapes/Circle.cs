using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafpack_2202368.Shapes
{
    class Circle : Shape
    {
        public Circle(PointF center, float size, int v) 
        {
            int numVertices = v > 0 ? v : 20; // Default to 20 vertices if v is not positive
            float radius = size / 2;
            for (int i = 0; i < numVertices; i++)
            {
                float angle = (float)(i * 2 * Math.PI / numVertices);
                float x = center.X + radius * (float)Math.Cos(angle);
                float y = center.Y + radius * (float)Math.Sin(angle);
                Vertices.Add(new PointF(x, y));
            }
        }

        public override void Draw(Bitmap canvas)
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                PointF p1 = Vertices[i];
                PointF p2 = Vertices[(i + 1) % Vertices.Count];

                DrawLine(canvas, p1, p2);
            }
        }
    }
}
