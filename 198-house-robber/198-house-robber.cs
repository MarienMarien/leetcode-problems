public class Solution {
    public int Rob(int[] nums) {
          if (nums == null || nums.Length == 0)
                return 0;
            if (nums.Length == 1)
                return nums[0];
            if (nums.Length == 2)
                return Math.Max(nums[0], nums[1]);

            var len = nums.Length;
            var stolen = new int[len];
            stolen[0] = nums[0];
            stolen[1] = Math.Max(nums[0], nums[1]);
            for (var i = 2; i < len; i++) {
                stolen[i] = Math.Max(nums[i] + stolen[i - 2], stolen[i - 1]);

            }
            
            return stolen[len - 1];
    }
}