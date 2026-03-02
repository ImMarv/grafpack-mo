using System;
using System.Drawing;


namespace grafpack_2202368.Shapes
{
    public class Square : Shape
    {
        public Square(PointF center, float size)
        {
            float half = size / 2;
            Center = center;

            Vertices.Add(new PointF(center.X - half, center.Y - half));
            Vertices.Add(new PointF(center.X + half, center.Y - half));
            Vertices.Add(new PointF(center.X + half, center.Y + half));
            Vertices.Add(new PointF(center.X - half, center.Y + half));
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
