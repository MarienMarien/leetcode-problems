public class Solution {
    public int MaxWidthRamp(int[] nums) {
        var maxRight = new int[nums.Length];
        maxRight[^1] = nums[^1];
        for (var i = maxRight.Length - 2; i >= 0; i--)
        {
            maxRight[i] = Math.Max(nums[i], maxRight[i + 1]);
        }

        var left = 0;
        var right = 0;
        var maxRamp = 0;
        while (right < nums.Length)
        {
            while (left < right && nums[left] > maxRight[right])
            {
                left++;
            }
            maxRamp = Math.Max(maxRamp, right - left);
            right++;
        }

        return maxRamp;
    }
}