public class Solution {
    public int MinSubArrayLen(int target, int[] nums) {
        var ans = Int32.MaxValue;
        var left = 0;
        var sum = 0;
        for (var i = 0; i < nums.Length; i++) {
            sum += nums[i];
            while (sum >= target) {
                ans = Math.Min(ans, i + 1 - left);
                sum -= nums[left++];
            }
        }
        return (ans == Int32.MaxValue) ? 0 : ans;
    }
}