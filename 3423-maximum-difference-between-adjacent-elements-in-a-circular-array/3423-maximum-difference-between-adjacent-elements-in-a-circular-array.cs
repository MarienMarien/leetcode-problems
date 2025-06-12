public class Solution {
    public int MaxAdjacentDistance(int[] nums) {
        var diff = Math.Abs(nums[0] - nums[^1]);
        for(var i = 1; i < nums.Length; i++)
        {
            diff = Math.Max(diff, Math.Abs(nums[i] - nums[i - 1]));
        }

        return diff;
    }
}