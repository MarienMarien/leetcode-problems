public class Solution {
    public int MissingElement(int[] nums, int k) {
        var ans = nums[^1] + k;
        var missedCount = 0;
        for(var i = 1; i < nums.Length; i++) {
            missedCount += nums[i] - nums[i - 1] - 1;
            if (missedCount >= k) {
                ans = nums[i] - (missedCount - k + 1);
                break;
            }
        }
        if (missedCount < k) {
            ans -= missedCount;
        }
        return ans;
    }
}