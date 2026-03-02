using System;
using System.Drawing;

namespace grafpack_2202368.Shapes
{
    public class Triangle : Shape
    {
        public Triangle(PointF center, float size)
        {
            float half = (float)(size * Math.Sqrt(3) / 6);
            Center = center;

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

        public override RectangleF GetBoundingBox()
        {
            float minX = Math.Min(Vertices[0].X, Math.Min(Vertices[1].X, Vertices[2].X));
            float maxX = Math.Max(Vertices[0].X, Math.Max(Vertices[1].X, Vertices[2].X));
            float minY = Math.Min(Vertices[0].Y, Math.Min(Vertices[1].Y, Vertices[2].Y));
            float maxY = Math.Max(Vertices[0].Y, Math.Max(Vertices[1].Y, Vertices[2].Y));

            foreach (var v in Vertices)
            {
                minX = Math.Min(minX, v.X);
                maxX = Math.Max(maxX, v.X);
                minY = Math.Min(minY, v.Y);
                maxY = Math.Max(maxY, v.Y);
            }
            return new RectangleF(minX, minY, maxX - minX, maxY - minY);
        }
    }
}
