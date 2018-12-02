

using System;

public class Animal : ISoundProducable
{
    private const string ErrorMessage = "Invalid input!";

    private string name;
    private int age;
    private string gender;

    public override string ToString()
    {
        return $"{this.GetType().Name}\n" +
            $"{this.Name} {this.Age} {this.Gender}\n" +
            $"{this.ProduceSound()}";
    }

    public Animal(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public virtual string ProduceSound()
    {
        return "";
    }

    public string Gender
    {
        get { return gender; }
        set
        {
            CheckNotEmptyString(value);
            gender = value;
        }
    }


    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0)
                throw new ArgumentException(ErrorMessage);

            age = value;
        }
    }


    public string Name
    {
        get { return name; }
        set
        {
            CheckNotEmptyString(value);
            name = value;
        }
    }

    private void CheckNotEmptyString(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException(ErrorMessage);
    }

}

