public class Solution {
    public int LongestSubarray(int[] nums) {
        var maxLen = 0;
        var currLen = 0;
        var currMax = 0;

        foreach(var n in nums)
        {
            if(currMax < n)
            {
                currMax = n;
                currLen = 0;
                maxLen = 0;
            }

            if(currMax == n)
            {
                currLen++;
            } else {
                currLen = 0;
            }

            maxLen = Math.Max(maxLen, currLen);
        }

        return maxLen;
    }
}