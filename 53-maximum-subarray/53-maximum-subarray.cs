public class Solution {
    public int MaxSubArray(int[] nums) {
        var currentSum = nums[0];
        var sum = nums[0];
        for (var i = 1; i < nums.Length; i++) {
            currentSum = Math.Max(nums[i], currentSum + nums[i]);
            sum = Math.Max(sum, currentSum);
            if (currentSum < 0)
                currentSum = 0;
        }
        return sum;
    }
}