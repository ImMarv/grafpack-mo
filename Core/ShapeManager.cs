using System.Collections.Generic;
using grafpack_2202368.Shapes;

namespace grafpack_2202368.Core
{
    public class ShapeManager
    {
        public List<Shape> Shapes = new List<Shape>();

        public Shape GetSelectedShape()
        {
            foreach (Shape s in Shapes)
                if (s.IsSelected)
                    return s;

            return null;
        }

        public void DeleteSelectedShape()
        {
            Shape s = GetSelectedShape();
            if (s != null)
                Shapes.Remove(s);
        }
    }
}