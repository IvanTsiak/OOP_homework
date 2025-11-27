using System;

// Порушено принцип підстановки Лісков 

interface IShape
{
    int GetArea();
}
class Rectangle : IShape
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }
    public int GetArea()
    {
        return Width * Height;
    }
}

//квадрат наслідується від прямокутника!!!
class Square : IShape
{
    public int Side { get; set; }
    public int GetArea()
    {
        return Side * Side;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle { Width = 5, Height = 10 };
            Console.WriteLine(rect.GetArea());

            Square square = new Square { Side = 5 };
            Console.WriteLine(square.GetArea());
            Console.ReadKey();
        }
    }
}