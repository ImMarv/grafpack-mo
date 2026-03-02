using System;
using System.Drawing;

namespace grafpack_2202368.Shapes
{
    public class Triangle : Shape
    {
        public Triangle(PointF center, float size)
        {
            float half = (float)(size * Math.Sqrt(3) / 6);

            Vertices.Add(new PointF(center.X + half, center.Y)); //v1
            Vertices.Add(new PointF((float)(center.X + half * Math.Cos(2 * Math.PI / 3)), (float)(center.Y + half * Math.Sin(2 * Math.PI / 3)))); //v2
            Vertices.Add(new PointF((float)(center.X + half * Math.Cos(4 * Math.PI / 3)), (float)(center.Y + half * Math.Sin(4 * Math.PI / 3)))); //v3
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
