public class Solution {
    public int MaxSumAfterOperation(int[] nums) {
        var maxWithoutSquare = nums[0];
        var maxWithSquare = nums[0] * nums[0];
        var maxSum = maxWithSquare;

        for (var i = 1; i < nums.Length; i++)
        {
            var sq = nums[i] * nums[i];
            maxWithSquare = Math.Max(Math.Max(sq, maxWithoutSquare + sq), maxWithSquare + nums[i]);
            maxWithoutSquare = Math.Max(nums[i], maxWithoutSquare + nums[i]);

            maxSum = Math.Max(maxSum, maxWithSquare);
        }

        return maxSum;
    }
}