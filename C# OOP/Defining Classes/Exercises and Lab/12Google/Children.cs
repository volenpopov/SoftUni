using System;
using System.Collections.Generic;
using System.Text;


   public class Children
{
    private string childName;
    private string childBirthday;

    public Children(string ChildName, string ChildBirthday)
    {
        this.childName = ChildName;
        this.childBirthday = ChildBirthday;
    }

    public string ChildName
    {
        get { return childName; }
        set { childName = value; }
    }

    public string ChildBirthday
    {
        get { return childBirthday; }
        set { childBirthday = value; }
    }
}

