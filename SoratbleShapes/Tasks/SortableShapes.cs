using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks
{
    public class SortableShapes
    {
        abstract class Shape : IComparable
        {
            string name;
            public string Name { get { return name; } }
            public Shape(string name)
            {
                this.name = name;
            }
            public abstract double Area();
           
           
            public int CompareTo(object sh)
            {
                Shape shape = sh as Shape;
                return this.Area().CompareTo(shape.Area());
            }
        }

        class Circle : Shape
        {
            double radius;
            const double PI = 3.14;
            public double Radius { get { return radius; } }
            public Circle(string name, double radius) : base(name)
            { this.radius = radius; }
            public override double Area()
            {
                return PI * radius * radius;
            }        
        }

        class Square : Shape
        {
            double side;
            public double Side { get { return side; } }
            public Square(string name, double side) : base(name)
            {
                this.side = side;
            }
            public override double Area()
            {
                return side * side;
            }                      
        }

        class Rectangle : Shape
        {
            double width;
            public double Width { get { return width; } }
            double height;
            public double Height { get { return height; } }
            public Rectangle(string name, double width, double height) : base(name)
            {
                this.width = width;
                this.height = height;
            }
            public override double Area()
            {
                return width * height;
            }            
        }

        class Triangle : Shape
        {
            double height;
            double Base;
            public double Height { get { return height; } }
           
            public Triangle(string name, double height, double Base) : base(name)
            {
                this.height = height;
                this.Base = Base;
            }
            public override double Area()
            {
                return Base * height / 2;
            }            
        }

        class Program
        {                       
            static void Main(string[] args)
            {
                List<Shape> shapes = new List<Shape>();
                shapes.Add(item: new Circle("Circle", 1.1234D));
                shapes.Add(item: new Square("Square", 1.1234D));
                shapes.Add(item: new Rectangle("Rectangle", 1.5D, 2D));
                shapes.Add(item: new Triangle("Triangle", 2D, 5D));

                shapes.Sort();
                foreach (Shape s in shapes)
                {                   
                    Console.WriteLine(s.Area());
                }                                           

                Console.ReadKey();
            }
        }
    }
}
