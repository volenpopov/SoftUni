using System;
using System.Collections.Generic;
using System.Text;


public class Rectangle
{
    private string id;
    private double width;
    private double height;
    private double topLeftX;
    private double topLeftY;

    public double TopLeftY
    {
        get { return topLeftY; }
        set { topLeftY = value; }
    }

    public double TopLeftX
    {
        get { return topLeftX; }
        set { topLeftX = value; }
    }

    public Rectangle(string Id, double Width, double Height, double topleftX, double topleftY)
    {
        this.id = Id;
        this.width = Width;
        this.height = Height;
        this.topLeftX = topleftX;
        this.topLeftY = topleftY;
    }

    public double Height
    {
        get { return height; }
        set { height = value; }
    }


    public double Width
    {
        get { return width; }
        set { width = value; }
    }


    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public bool CheckIfIntersect(Rectangle rectangle)
    {
        return rectangle.topLeftX + rectangle.width >= this.topLeftX &&
                rectangle.topLeftX <= this.topLeftX + this.width &&
                rectangle.topLeftY >= this.topLeftY - this.height &&
                rectangle.topLeftY - rectangle.height <= this.topLeftY;
    }
}

