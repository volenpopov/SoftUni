using System;

public class Program
{
    static void Main(string[] args)
    {
        string figure = Console.ReadLine();
        if (figure == "Square")
        {
            int size = int.Parse(Console.ReadLine());
            Square square = new Square(size);
            
        }

        else
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            Rectangle rectangle = new Rectangle(width, length);
            
        }
    }
}

