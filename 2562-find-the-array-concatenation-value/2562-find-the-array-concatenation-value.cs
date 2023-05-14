public class Solution {
    public long FindTheArrayConcVal(int[] nums) {
        long res = 0;
        int left = 0;
        int right = nums.Length - 1;
        while(left < right){
            int mag = nums[right].ToString().Length;
            res += (nums[left] * (long)Math.Pow(10, mag)) + nums[right];
            left++;
            right--;
        }
        if(left == right){
            res += nums[left];
        }
        return res;
    }
}