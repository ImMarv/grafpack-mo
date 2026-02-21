using System.Drawing;


namespace grafpack_2202368.Shapes
{
    class Square : Shape
    {
        public Square(PointF center, float size)
        {
            float half = size / 2;

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
    }
}
