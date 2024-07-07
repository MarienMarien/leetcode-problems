public class Solution {
    public int MinDifference(int[] nums) {
        if (nums.Length <= 4)
            return 0;

        Array.Sort(nums);

        var right = nums.Length - 4; 
        var left = 0;

        var minDiff = int.MaxValue;

        for (; right < nums.Length; right++, left++)
        {
            minDiff = Math.Min(minDiff, nums[right] - nums[left]);
        }

        return minDiff;
    }
}