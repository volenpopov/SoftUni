using System;
using System.Collections.Generic;
using System.Text;

   public class Box
{
    private double length;
    private double Length
    {
        get { return length; }

        set
        {
            if (value <= 0)
            {
                Console.WriteLine("Length cannot be zero or negative.");
                Environment.Exit(0);
            }
            this.length = value;
        }
    }

    private double width;
    private double Width
    {
        get { return Width; }

        set
        {
            if (value <= 0)
            {
                Console.WriteLine("Width cannot be zero or negative.");
                Environment.Exit(0);
            }
                
            this.width = value;
        }
    }


    private double height;
    private double Height
    {
        get { return height; }

        set
        {
            if (value <= 0)
            {
                Console.WriteLine("Height cannot be zero or negative.");
                Environment.Exit(0);
            }
            this.height = value;
        }
    }

    public Box(double length, double width, double height)
    {
        this.Length = length;
        this.Width = width;
        this.Height = height;
    }

    public double GetSurfaceArea()
    {
        return (2 * length * width) + (2 * length * height) + (2 * width * height);
    }

    public double GetLateralArea()
    {
        return (2 * length * height) + (2 * width * height);
    }

    public double GetVolume()
    {
        return length * width * height;
    }
}

