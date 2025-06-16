public class Solution {
    public int MaximumDifference(int[] nums) {
        var maxs = new int[nums.Length];
        maxs[^1] = nums.Length - 1;
        for(var i = nums.Length - 2; i >= 0; i--)
        {
            maxs[i] = nums[maxs[i + 1]] < nums[i] ? i : maxs[i + 1];
        }
        var maxDiff = -1;
        for(var i = 0; i < nums.Length - 1; i++)
        {
            if(i == maxs[i] || nums[maxs[i]] == nums[i])
                continue;
            maxDiff = Math.Max(nums[maxs[i]] - nums[i], maxDiff);
        }

        return maxDiff;
    }
}