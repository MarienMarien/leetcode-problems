public class Solution {
    public int[] BuildArray(int[] nums) {
        int[] ans = new int[nums.Length];
        for(var i = 0; i < nums.Length; i++){
            ans[i] = nums[nums[i]];
        }
        return ans;
    }
    
    
}