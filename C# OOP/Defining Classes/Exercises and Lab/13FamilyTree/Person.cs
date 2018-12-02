using System;
using System.Collections.Generic;
using System.Text;


    public class Person
{
    private string name;
    private string birthday;
    private List<Person> parents;
    private List<Person> children;

    public override string ToString()
    {
        return string.Format($"{this.name} {this.birthday}");
    }

    public Person()
    {
        this.parents = new List<Person>();
        this.children = new List<Person>();
    }
    
    public Person(string Name)       
    {
        this.name = Name;
    }

    public string Birthday
    {
        get { return birthday; }
        set { birthday = value; }
    }

    public List<Person> Parents
    {
        get { return parents; }
        set { parents = value; }
    }

    public List<Person> Children
    {
        get { return children; }
        set { children = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

}

