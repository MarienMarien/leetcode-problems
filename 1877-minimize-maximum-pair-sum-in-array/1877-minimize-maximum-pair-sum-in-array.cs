public class Solution {
    public int MinPairSum(int[] nums) {
        Array.Sort(nums);
        var start = 0;
        var end = nums.Length - 1;
        var max = 0;
        while(start < end) {
            max = Math.Max(max, nums[start] + nums[end]);
            start++;
            end--;
        }
        return max;
    }
}