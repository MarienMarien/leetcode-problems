public class Solution {
    public int FindMin(int[] nums) {
        if (nums.Length == 1 || nums[0] < nums[nums.Length - 1])
            return nums[0];
        int mid;
        var start = 0;
        var end = nums.Length - 1;
        var min = int.MaxValue;
        while (start < end)
        {
            if (end - start == 1) {
                min = Math.Min(nums[start], nums[end]);
                break;
            }
            mid = start + (end - start) / 2;
            min = Math.Min(min, nums[mid]);
            if (nums[start] < nums[mid])
            {
                start = mid;
                continue;
            }
            if (nums[mid] < nums[end])
            {
                end = mid;
                continue;
            }
        }
        return min;
    }
}