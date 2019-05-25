using System;
using System.Collections.Generic;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            List<IShape> figures = new List<IShape>();

            string input = Console.ReadLine();

            while (input == "Square" || input == "Rectangle" || input == "Circle")
            {
                PopulateFiguresList(figures, input);

                input = Console.ReadLine();
            }

            GraphicEditor shapeVisualisator = new GraphicEditor();

            foreach (var shape in figures)
            {
                shapeVisualisator.DrawShape(shape);
            }
        }

        private static void PopulateFiguresList(List<IShape> figures, string input)
        {
            IShape currentFigure;

            try
            {
                switch (input)
                {
                    case "Square":
                        currentFigure = new Square();
                        break;
                    case "Rectangle":
                        currentFigure = new Rectangle();
                        break;
                    case "Circle":
                        currentFigure = new Circle();
                        break;
                    default:
                        throw new ArgumentException("No such shape exists!");
                }

                figures.Add(currentFigure);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
