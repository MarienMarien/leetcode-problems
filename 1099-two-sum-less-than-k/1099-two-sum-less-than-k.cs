public class Solution {
    public int TwoSumLessThanK(int[] nums, int k) {
        var max = -1;
        Array.Sort(nums);
        var start = 0; var end = nums.Length - 1;
        while (start < end) {
            if (nums[start] + nums[end] >= k)
            {
                end--;
            }
            else {
                max = Math.Max(max, nums[start] + nums[end]);
                start++;
            }
        }

        return max;
    }
}