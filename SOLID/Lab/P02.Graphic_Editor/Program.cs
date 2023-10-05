using System.Collections.Generic;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            List<IShape> shapes = new();

            shapes.Add(new Circle());
            shapes.Add(new Rectangle());
            shapes.Add(new Square());

            GraphicEditor graphic = new();

            foreach (var shape in shapes)
            {
                graphic.DrawShape(shape);
            }

        }
    }
}
