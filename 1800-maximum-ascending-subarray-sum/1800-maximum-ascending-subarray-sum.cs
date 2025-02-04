public class Solution {
    public int MaxAscendingSum(int[] nums) {
        var currSum = nums[0];
        var maxSum = currSum;
        for(var i = 1; i < nums.Length; i++)
        {
            if(nums[i - 1] >= nums[i])
            {
                maxSum = Math.Max(maxSum, currSum);
                currSum = 0;
            }
            currSum += nums[i];
        }

        maxSum = Math.Max(maxSum, currSum);
        return maxSum;
    }
}