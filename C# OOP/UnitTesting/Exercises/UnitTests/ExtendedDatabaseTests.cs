using _01.Database;
using _02.ExtendedDatabase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace UnitTests
{
    public class ExtendedDatabaseTests
    {
        private const int DEFAULT_SIZE = 16;

        private ExtendedDatabase db;

        private void Initialize()
        {
            this.db = new ExtendedDatabase();
        }

        private void Initialize(params Person[] people)
        {
            this.db = new ExtendedDatabase(people);
        }

        [Test]        
        public void TestInvalidConstructor()
        {
            Person[] people = new Person[]
            {
                new Person(3, "Pesho"),
                new Person(5, "Pesho")
            };

            Assert.That(() => Initialize(people), Throws.InvalidOperationException);
        }

        [Test]
        public void AddMethodShouldNotAddIfNameExists()
        {
            Person[] people = new Person[]
            {
                new Person(3, "Pesho"),
                new Person(10, "Gosho")
            };

            Initialize(people);

            Person personToAdd = new Person(15, "Gosho");

            Assert.That(() => this.db.Add(personToAdd), Throws.InvalidOperationException);
        }

        [Test]
        public void AddMethodShouldNotAddIfIdExists()
        {
            Person[] people = new Person[]
            {
                new Person(3, "Pesho"),
                new Person(10, "Gosho")
            };

            Initialize(people);

            Person personToAdd = new Person(10, "Mitko");

            Assert.That(() => this.db.Add(personToAdd), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase(1)]
        [TestCase(3)]
        public void TestFindByIdMethodValid(long id)
        {
            Person[] people = new Person[]
            {
                new Person(1, "Pesho"),
                new Person(3, "Gosho")
            };

            Initialize(people);

            Assert.That(this.db.FindById(id), 
                Is.EqualTo(people.First(p => p.Id == id)));
        }

        [Test]
        public void FindByIdMethodNegativeIdArgOutOfRangeException()
        {
            Initialize();

            Assert.That(() => this.db.FindById(-1),
            Throws.ArgumentException);
        }

        [Test]
        public void FindByIdMethodInvalidOperIdDoesntExist()
        {
            Initialize(new Person(1, "Pesho"));

            Assert.That(() => this.db.FindById(3),
            Throws.InvalidOperationException);
        }

        [Test]
        [TestCase("")]
        [TestCase(" ")]
        public void FindByNameMethodEmptyStringArgNullException(string name)
        {
            Initialize();

            Assert.That(() => this.db.FindByName(name),
            Throws.ArgumentNullException);
        }
        
        [Test]
        public void FindByNameMethodNameDoesntExistInvalidOperExcep()
        {
            Initialize(new Person(1, "Pesho"));

            Assert.That(() => this.db.FindByName("Gosho"),
            Throws.InvalidOperationException);
        }

        private FieldInfo GetFieldInfo(object obj, Type fieldType)
        {
            FieldInfo fieldInfo = obj.GetType()
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(f => f.FieldType == fieldType);

            return fieldInfo;
        }
    }
}
