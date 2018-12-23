using System;

namespace _03.ListIterator
{
    public class ListIterator
    {
        private string[] elements;

        public ListIterator(string[] input)
        {
            this.elements = input;
            this.currentIndex = 0;
        }

        private int currentIndex { get; set; }

        public bool Move()
        {
            bool result = false;

            if (this.currentIndex < this.elements.Length - 1)
            {
                this.currentIndex++;
                result = true;
            }

            return result;
        }

        public bool HasNext()
        {            
            return this.currentIndex < this.elements.Length - 1;            
        }

        public void Print()
        {
            Console.WriteLine(this.elements[this.currentIndex]);
        }
    }
}
