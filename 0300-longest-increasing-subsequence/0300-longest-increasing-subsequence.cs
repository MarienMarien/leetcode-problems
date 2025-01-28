public class Solution {
    public int LengthOfLIS(int[] nums) {
        var dp = new int[nums.Length];
        dp[0] = 1;
        var maxLen = 1;
        for (var end = 1; end < nums.Length; end++)
        {
            dp[end] = 1;
            for (var curr = 0; curr < end; curr++)
            {
                if (nums[curr] < nums[end])
                    dp[end] = Math.Max(dp[end], dp[curr] + 1);
            }
            maxLen = Math.Max(maxLen, dp[end]);
        }

        return maxLen;
    }
}