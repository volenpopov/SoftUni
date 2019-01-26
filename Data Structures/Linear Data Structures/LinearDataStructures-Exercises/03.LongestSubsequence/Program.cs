using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LongestSubsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = Console.ReadLine().Split().Select(int.Parse).ToList();
            
            Console.WriteLine(string.Join(" ", GetLongestSubsequenceOfEqualNums(input)));
        }

        private static List<int> GetLongestSubsequenceOfEqualNums(List<int> inputList)
        {
            int[] nums = inputList.Distinct().ToArray();

            int maxCounter = 0;
            int counter = 0;
            int startIndex = 0;
            bool firstElement = true;

            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < inputList.Count - 1; j++)
                {
                    if (nums[i] == inputList[j]
                        && inputList[j] == inputList[j + 1])
                    {
                        counter++;
                        if (counter > maxCounter && !firstElement)
                        {
                            startIndex = j - counter + 1;
                            maxCounter = counter;
                        }
                            
                        else if (firstElement)
                            maxCounter = counter;
                    }
                    else
                    {
                        firstElement = false;
                        counter = 0;
                    }
                        
                }
            }

            maxCounter = maxCounter++ > inputList.Count - 1 - startIndex 
                ? maxCounter = (inputList.Count - 1 - startIndex) 
                : maxCounter;

            return new List<int>(inputList.GetRange(startIndex, maxCounter).ToList());
        }
    }
}
