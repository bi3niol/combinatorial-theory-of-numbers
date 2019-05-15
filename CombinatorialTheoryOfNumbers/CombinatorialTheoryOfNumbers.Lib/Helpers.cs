using System;
using System.Collections.Generic;
using System.Text;

namespace CombinatorialTheoryOfNumbers.Lib
{
    static class Helpers
    {
        public static int GetLengthOfLongestArithmeticSubsequence(List<int> coloredNumbers)
        {
            if (coloredNumbers.Count <= 2)
            {
                return coloredNumbers.Count;
            }
            int max = 2;
            int[] lengths = new int[coloredNumbers.Count];
            for (int i = 0; i < lengths.Length; i++)
            {
                lengths[i] = 2;
            }
            for (int i = lengths.Length - 2; i >= 0; i--)
            {
                int left = i - 1;
                int right = i + 1;
                while (left >= 0 && right < lengths.Length)
                {
                    if (coloredNumbers[left] + coloredNumbers[right] == 2 * coloredNumbers[i])
                    {
                        lengths[i] = Math.Max(lengths[right] + 1, lengths[i]);
                        max = Math.Max(max, lengths[i]);
                        left--;
                        right++;
                    }
                    else if (coloredNumbers[left] + coloredNumbers[right] < 2 * coloredNumbers[i])
                    {
                        right++;
                    }
                    else
                    {
                        left--;
                    }
                }
            }
            return max;
        }
    }
}
