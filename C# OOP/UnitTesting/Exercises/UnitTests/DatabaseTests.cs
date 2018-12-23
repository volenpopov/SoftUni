
using NUnit.Framework;
using System;

namespace UnitTests
{
    
    using _01.Database;
    using System.Linq;
    using System.Reflection;

    public class DatabaseTests
    {
        private const int DEFAULT_SIZE = 16;

        private Database db;

        private void Initialize()
        {
            this.db = new Database();
        }

        private void Initialize(params int[] inputArray)
        {
            this.db = new Database(inputArray);
        }

        [Test]
        public void DefaultConstructorShouldInitializeArrayWithDefault_Size()
        {
            Initialize();
            Assert.That(this.db.Size, Is.EqualTo(DEFAULT_SIZE), 
                "Array size is wrong!");
        }

        [Test]
        public void ConstructorParameterShouldNotExceedDefaultCapacity()
        {
            int[] inputArray = new int[DEFAULT_SIZE + 1];

            Assert.That(() => Initialize(inputArray),
                Throws.ArgumentException
                .With.Message.EqualTo("Array cannot exceed default size!"));
        }

        [Test]
        public void ArrayShouldEqualInputArrayGivenAsParameterInTheCtor()
        {
            int[] inputArray = { 1, 2, 3, 4, 5};

            Initialize(inputArray);

            int[] buffer = new int[DEFAULT_SIZE - inputArray.Length];
            int[] inputArrayWithBuffer = inputArray.Concat(buffer).ToArray();

            FieldInfo fieldInfo = GetFieldInfo(this.db, typeof(int[]));

            int[] fieldValues = (int[])fieldInfo.GetValue(this.db);

            Assert.That(fieldValues, Is.EqualTo(inputArrayWithBuffer));
        }

        [Test]
        public void AddCommandShouldNotAddIfCapacityIsReached()
        {
            Initialize(new int[DEFAULT_SIZE]);

            Assert.That(() => this.db.Add(1),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Array is full!"));
        }

        [Test]
        public void AddCommandShouldIncreaseNumberOfElementInArray()
        {
            Initialize();

            this.db.Add(1);

            Assert.That(this.db.NumberOfElements, Is.EqualTo(1));
        }

        [Test]
        public void RemoveCommandCannotExecuteOnEmptyArray()
        {
            Initialize();

            Assert.That(() => this.db.Remove(),
                Throws.InvalidOperationException
                .With.Message.EqualTo("Array is empty!"));
        }

        [Test]
        public void RemoveCommandShouldDecreaseNumberOfElementInArray()
        {
            Initialize(1);
            this.db.Remove();

            Assert.That(this.db.NumberOfElements, Is.EqualTo(0));
        }

        [Test]
        public void FetchCommandReturnPopulatedArrayWithoutBuffer()
        {
            Initialize(1, 2, 3, 4, 5);

            FieldInfo fieldInfo = GetFieldInfo(this.db, typeof(int[]));

            int[] fieldValues = (int[]) fieldInfo.GetValue(this.db);

            int[] fieldArrayWithoutBuffer = new int[this.db.NumberOfElements];
            Array.Copy(fieldValues, fieldArrayWithoutBuffer, this.db.NumberOfElements);

            int[] fetchArray = this.db.Fetch();

            Assert.That(fieldArrayWithoutBuffer, Is.EqualTo(fetchArray));
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
