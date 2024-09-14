public class Solution {
    public int LongestSubarray(int[] nums) {
        var maxLen = 1;
        var currMax = nums[0];
        var currLen = 1;

        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1])
            {
                currLen++;
            }
            else
            {
                if (nums[i - 1] >= currMax)
                {
                    maxLen = nums[i - 1] == currMax ? Math.Max(maxLen, currLen) : currLen;
                    currMax = nums[i - 1];
                }
                currLen = 1;
            }

            if (i == nums.Length - 1)
            {
                if (nums[i] >= currMax)
                {
                    maxLen = nums[i] == currMax ? Math.Max(maxLen, currLen) : currLen;
                }
            }
        }

        return maxLen;
    }
}