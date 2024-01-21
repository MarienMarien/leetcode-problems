public class Solution {
    public int Rob(int[] nums) {
        if(nums.Length <= 1)
            return nums[0];

        var maxStart1 = nums[0];
        var maxStart2 = Math.Max(nums[0], nums[1]);
        var maxStolen = maxStart2;
        for(var i = 2; i < nums.Length; i++)
        {
            maxStolen = Math.Max(maxStart2, maxStart1 + nums[i]);
            maxStart1 = maxStart2;
            maxStart2 = maxStolen;
        }

        return maxStolen;
    }
}