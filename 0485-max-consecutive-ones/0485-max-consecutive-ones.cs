public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        var start = 0; 
        var end = 0;
        var max = 0;
        while(end < nums.Length){
            if(nums[end] != 1){
                max = Math.Max(max, end - start);
                start = end + 1;
            }
            end++;
        }
        max = Math.Max(max, end - start);
        return max;
    }
}