public class Solution {
    public int[] GetConcatenation(int[] nums) {
        int len = nums.Length;
        int[] ans = new int[len*2];
        for(var i = 0; i<len; i++){
            ans[i] = nums[i];
            ans[i+len] = nums[i];
        }
        return ans;
    }
}