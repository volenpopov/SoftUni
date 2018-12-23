using _02.ExtendedDatabase;
using System;
using System.Linq;

namespace _01.Database
{
    public class ExtendedDatabase
    {
        private const int DEFAULT_CAPACITY = 16;
        private Person[] array;

        public ExtendedDatabase()
        {
            this.array = new Person[DEFAULT_CAPACITY];
            this.NumberOfElements = 0;
        }

        public ExtendedDatabase(params Person[] people) : this()
        {
            ValidateArraySize(people);

            foreach (var person in people)
            {
                Add(person);
            }
        }

        public int Size => this.array.Length;

        public int NumberOfElements { get; private set; }

        public Person FindById(long id)
        {
            try
            {
                if (id < 0)
                    throw new ArgumentOutOfRangeException("Id must be a positive number!");
            }            
            catch(ArgumentOutOfRangeException)
            {
                throw new ArgumentException();
            }

            Person person = null;

            for (int i = 0; i < this.NumberOfElements; i++)
            {
                if (this.array[i].Id == id)
                    person = this.array[i];
            }
            
            if (person == null)
                throw new InvalidOperationException("Person with such Id doesn't exist!");

            return person;
        }

        public Person FindByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Name cannot be null, empty or whitespace!");

            Person person = null;

            for (int i = 0; i < this.NumberOfElements; i++)
            {
                if (this.array[i].Name == name)
                    person = this.array[i];
            }

            if (person == null)
                throw new InvalidOperationException("Person with such name doesn't exist!");

            return person;
        }

        public void Add(Person person)
        {
            if (this.NumberOfElements + 1 > DEFAULT_CAPACITY)
                throw new InvalidOperationException("Array is full!");

            CheckIfSuchPersonAlreadyExists(person);

            int lastFreeIndex = this.NumberOfElements;
            this.array[lastFreeIndex] = person;

            this.NumberOfElements++;
        }

        public void Remove()
        {
            if (this.NumberOfElements == 0)
                throw new InvalidOperationException("Array is empty!");

            int lastElementIndex = this.NumberOfElements;
            this.array[lastElementIndex] = null;

            this.NumberOfElements--;
        }

        public int[] Fetch()
        {
            int[] newArray = new int[this.NumberOfElements];

            Array.Copy(this.array, newArray, this.NumberOfElements);

            return newArray;
        }

        private void ValidateArraySize(Person[] array)
        {
            if (array.Length > DEFAULT_CAPACITY)
                throw new ArgumentException("Array cannot exceed default size!");                
        }

        private void CheckIfSuchPersonAlreadyExists(Person person)
        {
            for (int i = 0; i < this.NumberOfElements; i++)
            {
                if (this.array[i].Name == person.Name)
                    throw new InvalidOperationException("Person with such name already exists!");

                if (this.array[i].Id == person.Id)
                    throw new InvalidOperationException("Person with such Id already exists!");
            }
            
        }
    }
}
