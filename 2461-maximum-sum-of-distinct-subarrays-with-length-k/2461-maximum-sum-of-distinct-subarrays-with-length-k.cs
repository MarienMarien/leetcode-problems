public class Solution {
    public long MaximumSubarraySum(int[] nums, int k) {
        var currSum = 0L;
        var maxSum = 0L;
        var windowStartId = 0;
        var visited = new Dictionary<int, int>();

        for (var i = 0; i < nums.Length; i++)
        {
            if (visited.ContainsKey(nums[i]))
            {
                while (windowStartId <= visited[nums[i]])
                {
                    currSum -= nums[windowStartId];
                    windowStartId++;
                }
            }
            currSum += nums[i];
            visited[nums[i]] = i;
            if (i - windowStartId + 1 == k)
            {
                maxSum = Math.Max(maxSum, currSum);
                currSum -= nums[windowStartId];
                windowStartId++;
            }
        }
        return maxSum;
    }
}