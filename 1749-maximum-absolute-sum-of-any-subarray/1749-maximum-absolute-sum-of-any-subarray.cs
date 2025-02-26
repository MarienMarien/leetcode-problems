public class Solution {
    public int MaxAbsoluteSum(int[] nums) {
        var min = nums[0];
        var max = nums[0];
        var maxAbs = Math.Abs(nums[0]);
        for(var i = 1; i < nums.Length; i++)
        {
            min = Math.Min(min + nums[i], nums[i]);
            max = Math.Max(max + nums[i], nums[i]);
            maxAbs = Math.Max(maxAbs, Math.Max(Math.Abs(min), Math.Abs(max)));
        }

        return maxAbs;
    }
}