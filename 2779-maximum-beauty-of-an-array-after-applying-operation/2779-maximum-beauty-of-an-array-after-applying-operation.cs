public class Solution {
    public int MaximumBeauty(int[] nums, int k) {
        Array.Sort(nums);
        var maxDiff = 2 * k;
        var windowStartId = 0;
        var maxBeauty = 0;
        for(var i = 0; i < nums.Length; i++)
        {
            while(nums[i] - nums[windowStartId] > maxDiff)
                windowStartId++;
            maxBeauty = Math.Max(maxBeauty, i - windowStartId + 1);
        }

        return maxBeauty;
    }
}