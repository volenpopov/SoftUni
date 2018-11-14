using System;
using System.Collections.Generic;
using System.Text;


    public class Parent
{
    private string parentName;
    private string parentBirthday;

    public Parent(string ParentName, string ParentBirthday)
    {
        this.parentName = ParentName;
        this.parentBirthday = ParentBirthday;
    }

    public string ParentName
    {
        get { return parentName; }
        set { parentName = value; }
    }

    public string ParentBirthday
    {
        get { return parentBirthday; }
        set { parentBirthday = value; }
    }
}

