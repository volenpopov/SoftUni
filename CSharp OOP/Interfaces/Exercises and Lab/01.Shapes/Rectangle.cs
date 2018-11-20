using System;

public class Rectangle : IDrawable
{
    public Rectangle(int width, int height)
    {
        this.Width = width;
        this.Height = height;
    }

    public int Width { get; private set; }

    public int Height { get; private set; }

    public void Draw()
    {
        Console.WriteLine(new string('*', this.Width));

        for (int i = 0; i < this.Height - 2; i++)
        {
            Console.Write('*');
            Console.Write(new string(' ', this.Width - 2));
            Console.WriteLine('*');
        }

        Console.WriteLine(new string('*', this.Width));
    }
}

