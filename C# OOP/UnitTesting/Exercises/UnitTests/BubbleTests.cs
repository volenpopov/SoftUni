using _04.BubbleSort;
using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

namespace UnitTests
{
    class BubbleTests
    {
        private Bubble bubble;

        [Test]
        [TestCase(new int[] { 1, 2, 3})]
        [TestCase(new int[] { 1, 5, 2, 10, 3 })]
        [TestCase(new int[] { -1 })]
        [TestCase(new int[] { })]
        public void TestValidConstructor(int[] nums)
        {
            this.bubble = new Bubble(nums);

            FieldInfo fieldInfo = GetFieldInfo(this.bubble, typeof(int[]));

            int[] fieldValues = (int[])fieldInfo.GetValue(this.bubble);

            Assert.That(fieldValues, Is.EqualTo(nums));
        }

        [Test]
        [TestCase(new int[] { 3, 4, 1, 5, 2 })]
        [TestCase(new int[] { 12, 1, 24, 3, 0, -6 })]
        public void TestValidSort(int[] nums)
        {
            this.bubble = new Bubble(nums);
            this.bubble.BubbleSort();

            FieldInfo fieldInfo = GetFieldInfo(this.bubble, typeof(int[]));

            int[] fieldValues = (int[])fieldInfo.GetValue(this.bubble);

            Array.Sort(nums);

            Assert.That(fieldValues, Is.EqualTo(nums));
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
