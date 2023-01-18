public class Solution {
    public int MaxSubarraySumCircular(int[] nums) {
        var currMax = 0;
        var currMin = 0;
        var sum = 0;
        var maxSum = nums[0];
        var minSum = nums[0];
        foreach (var n in nums) {
            currMax = Math.Max(currMax, 0) + n;
            maxSum = Math.Max(maxSum, currMax);
            currMin = Math.Min(currMin, 0) + n;
            minSum = Math.Min(minSum, currMin);
            sum += n;
        }
        return sum == minSum ? maxSum : Math.Max(maxSum, sum - minSum);
    }
}