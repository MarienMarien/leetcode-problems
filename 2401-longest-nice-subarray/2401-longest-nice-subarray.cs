public class Solution {
    public int LongestNiceSubarray(int[] nums) {
        var setBits = 0;
        var start = 0;
        var maxLen = 0;
        for(var end = 0; end < nums.Length; end++)
        {
            while((setBits & nums[end]) != 0)
            {
                setBits ^= nums[start];
                start++;
            }

            setBits |= nums[end];
            maxLen = Math.Max(maxLen, end - start + 1);
        }

        return maxLen;
    }
}