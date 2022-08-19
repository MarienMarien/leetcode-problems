public class Solution {
    public bool CanJump(int[] nums) {
        var goodIdx = nums.Length - 1;
        for (var i = nums.Length - 2; i >= 0; i--) {
            if (goodIdx - i <= nums[i])
                goodIdx = i;
        }
        return goodIdx == 0;
    }
}