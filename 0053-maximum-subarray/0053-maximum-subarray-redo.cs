public class Solution {
    public int MaxSubArray(int[] nums) {
        var currSum = nums[0];
        var maxSum = nums[0];
        for(var i = 1; i < nums.Length; i++)
        {
            currSum = Math.Max(nums[i], currSum + nums[i]);
            maxSum = Math.Max(maxSum, currSum);
        }

        return maxSum;
    }
}