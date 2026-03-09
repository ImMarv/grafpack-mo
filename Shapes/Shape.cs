using System;
using System.Collections.Generic;
using System.Drawing;

public abstract class Shape
{
    public List<PointF> Vertices = new List<PointF>();
    public PointF Center { get; protected set; }
    public bool Contains(PointF point)
    {
        return false; // Placeholder for hit testing
    }

    public abstract void Draw(Bitmap canvas);

    protected void PutPixel(Bitmap canvas, int x, int y, Color color)
    {
        if (x >= 0 && x < canvas.Width &&
            y >= 0 && y < canvas.Height)
        {
            canvas.SetPixel(x, y, color);
        }
    }

    protected void DrawLine(Bitmap canvas, PointF p1, PointF p2)
    {
        int x1 = (int)p1.X;
        int y1 = (int)p1.Y;
        int x2 = (int)p2.X;
        int y2 = (int)p2.Y;

        int dx = Math.Abs(x2 - x1);
        int dy = Math.Abs(y2 - y1);

        int sx = x1 < x2 ? 1 : -1;
        int sy = y1 < y2 ? 1 : -1;

        int err = dx - dy;

        while (true)
        {
            PutPixel(canvas, x1, y1, Color.Black);

            if (x1 == x2 && y1 == y2)
                break;

            int e2 = 2 * err;

            if (e2 > -dy)
            {
                err -= dy;
                x1 += sx;
            }

            if (e2 < dx)
            {
                err += dx;
                y1 += sy;
            }
        }
    }

    public abstract RectangleF GetBoundingBox();

    public virtual bool HitTest(PointF point)
    {
        return GetBoundingBox().Contains(point);
    }

    public virtual void Move(float dx, float dy)
    {
        for (int i = 0; i < Vertices.Count; i++)
        {
            Vertices[i] = new PointF(
                Vertices[i].X + dx,
                Vertices[i].Y + dy);
        }

        Center = new PointF(Center.X + dx, Center.Y + dy);
    }

    public virtual void Rotate(float angleDegrees)
    {
        float angleRadians = (float)(angleDegrees * Math.PI / 180);
        float cosA = (float)Math.Cos(angleRadians);
        float sinA = (float)Math.Sin(angleRadians);
        for (int i = 0; i < Vertices.Count; i++)
        {
            float x = Vertices[i].X - Center.X;
            float y = Vertices[i].Y - Center.Y;
            float rotatedX = x * cosA - y * sinA;
            float rotatedY = x * sinA + y * cosA;
            Vertices[i] = new PointF(
                rotatedX + Center.X,
                rotatedY + Center.Y);
        }
    }
}
