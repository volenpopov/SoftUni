namespace _04.BubbleSort
{    
    public class Bubble
    {
        private int[] nums;

        public Bubble(int[] nums)
        {
            this.nums = nums;
        }

        private int Pairs => this.nums.Length - 1;

        private int Counter { get; set; }

        private bool Sorted => this.Pairs == this.Counter;

        public void BubbleSort()
        {
            while (this.Sorted == false)
            {
                this.Counter = 0;

                for (int i = 0; i < this.nums.Length - 1; i++)
                {
                    if (this.nums[i] > this.nums[i + 1])
                    {
                        int temp = this.nums[i];
                        this.nums[i] = this.nums[i + 1];
                        this.nums[i + 1] = temp;
                    }
                    else
                        this.Counter++;
                }
            }
        }
    }
}
