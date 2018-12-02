using System;
using System.Collections.Generic;
using System.Text;


    public class Square
{
    private int size;

    public void Draw(int size)
    {
        for (int row = 0; row < size; row++)
        {
            Console.Write("|");
            for (int column = 0; column < size; column++)
            {
                if (row % 2 == 0)
                    Console.Write("-");
                else
                    Console.Write(" ");
            }
            Console.WriteLine("|");
        }
    }

    public Square(int size)
    {
        this.size = size;   
    }

    public int Size
    {
        get { return size; }
        set { size = value; }
    }

}

