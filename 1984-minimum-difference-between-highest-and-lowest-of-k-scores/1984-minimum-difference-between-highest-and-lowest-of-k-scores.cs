public class Solution {
    public int MinimumDifference(int[] nums, int k) {
        if (k == 1 || nums == null || nums.Length == 0)
                return 0;
            Array.Sort(nums);
            var minDiff = Int32.MaxValue;
            var i = 0;
            while (i <= nums.Length - k) {
                var currDiff = nums[i + k - 1] - nums[i];
                minDiff = Math.Min(minDiff, currDiff);
                i++;
            }
            return minDiff;
    }
}