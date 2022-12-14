public class Solution {
    public int Rob(int[] nums) {
         var stolen = new int[nums.Length];
         stolen[0] = nums[0];
         for (var i = 1; i < nums.Length; i++) {
             if(i > 1)
                stolen[i] = Math.Max(nums[i] + stolen[i - 2], stolen[i - 1]);
            else
                stolen[i] = Math.Max(nums[i], stolen[i - 1]);
         }
         return stolen[^1];
    }
}