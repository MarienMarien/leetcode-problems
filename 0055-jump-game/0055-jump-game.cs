public class Solution {
    public bool CanJump(int[] nums) {
      var goodIdx = nums.Length - 1;
      var i = nums.Length - 2;
      while (i >= 0) {
          if(nums[i] >= goodIdx - i) 
            goodIdx = i;
        i--;
      }
      return goodIdx == 0;
    }
}