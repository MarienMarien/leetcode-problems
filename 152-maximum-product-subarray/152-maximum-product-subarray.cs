public class Solution {
    public int MaxProduct(int[] nums) {
        if(nums.Length == 0)
            return 0;
        var currentMax = nums[0];
        var currentMin = nums[0];
        var res = currentMax;
        for (var i = 1; i < nums.Length; i++) {
            var tmpMax = Math.Max(nums[i], Math.Max(currentMax * nums[i], currentMin * nums[i]));
            currentMin = Math.Min(nums[i], Math.Min(currentMax * nums[i], currentMin * nums[i]));
            currentMax = tmpMax;
            res = Math.Max(res, currentMax);
        }
        return res;
    }
}