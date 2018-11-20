using System;
using System.Collections.Generic;
using System.Text;

    public class Rectangle
{
    private int length;

    private int width;

    public void Draw(int length, int width)
    {
        for (int row = 0; row < length; row++)
        {
            Console.Write("|");
            for (int column = 0; column < width; column++)
            {
                if (row % 2 == 0)
                    Console.Write("-");
                else
                    Console.Write(" ");
            }
            Console.WriteLine("|");
        }
    }

    public Rectangle(int width, int length)
    {
        this.width = width;
        this.length = length;
    }

    public int Width
    {
        get { return width; }
        set { width = value; }
    }

    public int Length
    {
        get { return length; }
        set { length = value; }
    }
}

