public class Solution {
    public int NumberOfArithmeticSlices(int[] nums) {
        var dp = new List<int>();
        dp.Add(0);
        int sum = 0;
        for (var i = 2; i < nums.Length; i++) {
            if (nums[i] - nums[i - 1] == nums[i - 1] - nums[i - 2]) {
                dp.Add(1 + dp[dp.Count - 1]);
                sum += dp[dp.Count - 1];
            }
            else {
                dp.Add(0);
            }
        }
        return sum;
    }
}