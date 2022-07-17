public class Solution {
    public int RemoveDuplicates(int[] nums) {
        var right = 0;
            for (var left = 1; left < nums.Length; left++) {
                if (nums[left] != nums[right]) {
                    right++;
                    nums[right] = nums[left];
                }
            }
            return right +1;
    }
}