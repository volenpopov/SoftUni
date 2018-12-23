using CustomLinkedList;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace UnitTests
{
    class CustomLinkedListTests
    {
        private int Initial_Count = 0;

        private DynamicList<int> list;

        private void Initialize()
        {
            this.list = new DynamicList<int>();
        }

        [Test]
        public void CtorShouldSetCountToZero()
        {
            Initialize();

            Assert.That(this.list.Count, Is.EqualTo(Initial_Count));
        }

        [Test]
        public void TestValidCountProperty()
        {
            Initialize();

            this.list.Add(1);
            this.list.Add(5);
            this.list.Remove(1);
            this.list.Add(2);
            this.list.RemoveAt(0);

            Assert.That(this.list.Count, Is.EqualTo(1));
        }

        [Test]
        public void TestInvalidCountProperty()
        {
            Initialize();

            this.list.Add(1);
            this.list.Add(5);         
            this.list.Remove(1);

            Assert.That(() => this.list.Count != 3);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(5000)]
        [TestCase(1)]
        public void TestInvalidPositionMethod(int index)
        {
            Initialize();
            this.list.Add(5);

            int returnValue = 0;
            Assert.Throws<ArgumentOutOfRangeException>(
                () => returnValue = this.list[index]);          
        }

        [Test]
        public void TestValidGetPositionMethod()
        {
            Initialize();
            this.list.Add(5);

            Assert.That(this.list[0], Is.EqualTo(5));
        }
        
        [Test]
        [TestCase(3)]
        [TestCase(15)]
        public void TestValidSetPositionMethod(int num)
        {
            Initialize();
            this.list.Add(100);
            this.list[0] = num;

            Assert.That(this.list[0], Is.EqualTo(num));
        }

        [Test]
        [TestCase(2)]
        [TestCase(0)]
        public void TestValidRemoveAtMethod(int index)
        {
            Initialize();
            this.list.Add(4);
            this.list.Add(12);
            this.list.Add(7);

            int removedValue = this.list[index];

            Assert.That(this.list.RemoveAt(index), Is.EqualTo(removedValue));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(3)]
        [TestCase(1000)]
        public void TestInvalidRemoveAtMethod(int index)
        {
            Initialize();
            this.list.Add(4);
            this.list.Add(12);
            this.list.Add(7);

            Assert.Throws<ArgumentOutOfRangeException>
                (() => this.list.RemoveAt(index));
        }

        [Test]
        [TestCase(4, ExpectedResult = 0)]
        [TestCase(7, ExpectedResult = 1)]
        [TestCase(12, ExpectedResult = 2)]
        [TestCase(99, ExpectedResult = -1)]
        public int TestRemoveMethod(int num)
        {
            Initialize();
            this.list.Add(4);
            this.list.Add(7);
            this.list.Add(12);

            return this.list.Remove(num);
        }

        [Test]
        [TestCase(4, ExpectedResult = 0)]
        [TestCase(7, ExpectedResult = 1)]
        [TestCase(12, ExpectedResult = 2)]
        [TestCase(99, ExpectedResult = -1)]
        public int TestIndexOfMethod(int num)
        {
            Initialize();
            this.list.Add(4);
            this.list.Add(7);
            this.list.Add(12);

            return this.list.IndexOf(num);
        }

        [Test]
        [TestCase(4, ExpectedResult = true)]
        [TestCase(7, ExpectedResult = true)]
        [TestCase(12, ExpectedResult = true)]
        [TestCase(99, ExpectedResult = false)]
        public bool TestContainsMethod(int num)
        {
            Initialize();
            this.list.Add(4);
            this.list.Add(7);
            this.list.Add(12);

            return this.list.Contains(num);
        }
    }
}
