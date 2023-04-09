public class Solution {
    public int LengthOfLIS(int[] nums) {
        var dp = new int[nums.Length];
        var max = 0;
        for (var i = 1; i < nums.Length; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (nums[j] < nums[i])
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
            }
            max = Math.Max(max, dp[i]);
        }
        return max + 1;
    }
}