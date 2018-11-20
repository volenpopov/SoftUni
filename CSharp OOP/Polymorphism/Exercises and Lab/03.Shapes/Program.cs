using System;

class Program
{
    static void Main(string[] args)
    {

    }
}

public class Circle : Shape
{
    public Circle(double radius)
    {
        this.Radius = radius;
    }

    public double Radius { get; set; }

    public override double CalculateArea()
    {
        double result = Math.PI * (this.Radius * this.Radius);
        return result;
    }

    public override double CalculatePerimeter()
    {
        double result = 2 * Math.PI * this.Radius;
        return result;
    }

    public override string Draw()
    {
        string result = base.Draw() + this.GetType().Name;
        return result;
    }
}

public class Rectangle : Shape
{
    public Rectangle(double width, double height)
    {
        this.Width = width;
        this.Height = height;
    }

    public double Width { get; set; }
    public double Height { get; set; }

    public override double CalculateArea()
    {
        double result = Width * Height;
        return result;
    }

    public override double CalculatePerimeter()
    {
        double result = 2 * (Width + Height);
        return result;
    }

    public override string Draw()
    {
        string result = base.Draw() + this.GetType().Name;
        return result;
    }
}


public abstract class Shape
{
    public abstract double CalculatePerimeter();

    public abstract double CalculateArea();

    public virtual string Draw()
    {
        string result = "Drawing ";
        return result;
    }
}
