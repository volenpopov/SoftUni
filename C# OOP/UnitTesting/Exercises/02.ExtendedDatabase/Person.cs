namespace _02.ExtendedDatabase
{
    public class Person
    {
        public Person(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public string Name { get; private set; }

        public int Id { get; private set; }
    }
}
