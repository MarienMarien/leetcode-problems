public class Solution {
    public long MaximumSubarraySum(int[] nums, int k) {
        var maxSum = 0L;
        var distinctNums = new Dictionary<int, (int id, long sum)>();
        var windowStartId = 0;
        var currSum = 0L;
        for (var i = 0; i < nums.Length; i++)
        {
            if (distinctNums.Count > 0 && distinctNums.ContainsKey(nums[i]))
            {
                if (distinctNums[nums[i]].id >= windowStartId)
                {
                    windowStartId = distinctNums[nums[i]].id + 1;
                }
            }
            distinctNums[nums[i]] = (i, currSum);
            currSum += nums[i];

            if (i - windowStartId + 1 == k)
            {
                maxSum = Math.Max(maxSum, currSum - distinctNums[nums[windowStartId]].sum);
                windowStartId++;
            }
        }

        return maxSum;
    }
}