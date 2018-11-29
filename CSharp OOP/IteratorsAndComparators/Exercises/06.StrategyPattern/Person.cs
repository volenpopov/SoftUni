
public class Person
{
    public Person(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }

    public string Name { get; }

    public int Age { get; }
}
