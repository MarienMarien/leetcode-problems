public class Solution {
    public int MinimizeArrayValue(int[] nums) {
        long ans = 0;
        long prefixSum = 0;
        for (int i = 0; i < nums.Length; ++i)
        {
            prefixSum += nums[i];
            ans = Math.Max(ans, (prefixSum + i) / (i + 1));
        }
        return (int)ans;
    }
}