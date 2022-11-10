public class Solution {
    public int LongestOnes(int[] nums, int k) {
        var left = 0;
        int right;
        for (right = 0; right < nums.Length; right++) {
            if (nums[right] == 0) {
                k--;
            }
            if (k < 0) {
                k += 1 - nums[left];
                left++;
            }
        }
        return right - left;
    }
}