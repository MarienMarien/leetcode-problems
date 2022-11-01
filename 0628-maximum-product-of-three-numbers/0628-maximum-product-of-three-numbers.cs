public class Solution {
    public int MaximumProduct(int[] nums) {
        if (nums == null || nums.Length < 3)
            return 0;
        Array.Sort(nums);
        var lastId = nums.Length - 1;
        return Math.Max(nums[0] * nums[1] * nums[lastId], nums[lastId] * nums[lastId - 1] * nums[lastId - 2]);
    }
}