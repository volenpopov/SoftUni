using _03.ListIterator;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace UnitTests
{
    class ListIteratorTests
    {
        private ListIterator iterator;

        private void Initialize(string[] input)
        {
            this.iterator = new ListIterator(input);
        }

        [Test]
        public void TestValidConstructor()
        {
            string[] input = new string[] { "pesho", "gosho" };

            Initialize(input);

            FieldInfo fieldInfo = GetFieldInfo(this.iterator, typeof(string[]));

            string[] fieldValues = (string[]) fieldInfo.GetValue(this.iterator);

           Assert.That(fieldValues, Is.EqualTo(input));
        }

        [Test]
        public void MoveMethodShouldIncreaseCurrentIndexByOne()
        {
            string[] input = new string[] { "pesho", "gosho" };

            Initialize(input);

            this.iterator.Move();

            PropertyInfo propInfo = GetPropertyInfo(this.iterator, typeof(int));

            int propValue = (int) propInfo.GetValue(this.iterator);

            Assert.That(propValue, Is.EqualTo(1));
        }

        [Test]
        public void CannotMoveIfEndOfCollection()
        {
            string[] input = new string[] { "pesho", "gosho" };

            Initialize(input);

            PropertyInfo propInfo = GetPropertyInfo(this.iterator, typeof(int));
            propInfo.SetValue(this.iterator, 1);

            Assert.That(this.iterator.Move(), Is.EqualTo(false));
        }

        [Test]
        public void NoNextElementIfEndOfCollection()
        {
            string[] input = new string[] { "pesho" };

            Initialize(input);

            Assert.That(this.iterator.HasNext(), Is.EqualTo(false));
        }

        [Test]
        public void TestValidHasNextElement()
        {
            string[] input = new string[] { "pesho", "gosho" };

            Initialize(input);

            Assert.That(this.iterator.HasNext(), Is.EqualTo(true));
        }

        private PropertyInfo GetPropertyInfo(object obj, Type propType)
        {
            PropertyInfo propInfo = obj.GetType()
                .GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)
                .First(p => p.PropertyType == propType);

            return propInfo;
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
