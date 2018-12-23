using System;

namespace _01.Database
{
    public class Database
    {
        private const int DEFAULT_CAPACITY = 16;
        private int[] array;

        public Database()
        {
            this.array = new int[DEFAULT_CAPACITY];
            this.NumberOfElements = 0;
        }

        public Database(params int[] nums) : this()
        {
            ValidateArraySize(nums);

            Array.Copy(nums, this.array, nums.Length);
            this.NumberOfElements = nums.Length;
        }

        public int Size => this.array.Length;

        public int NumberOfElements { get; private set; }

        public void Add(int num)
        {
            if (this.NumberOfElements + 1 > DEFAULT_CAPACITY)
                throw new InvalidOperationException($"Array is full!");

            int lastFreeIndex = this.NumberOfElements;
            this.array[lastFreeIndex] = num;

            this.NumberOfElements++;
        }

        public void Remove()
        {
            if (this.NumberOfElements == 0)
                throw new InvalidOperationException("Array is empty!");

            int lastElementIndex = this.NumberOfElements;
            this.array[lastElementIndex] = default(int);

            this.NumberOfElements--;
        }

        public int[] Fetch()
        {
            int[] newArray = new int[this.NumberOfElements];

            Array.Copy(this.array, newArray, this.NumberOfElements);

            return newArray;
        }

        private void ValidateArraySize(int[] array)
        {
            if (array.Length > DEFAULT_CAPACITY)
                throw new ArgumentException("Array cannot exceed default size!");                
        }
    }
}
