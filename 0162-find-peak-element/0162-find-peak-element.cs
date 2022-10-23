public class Solution {
    public int FindPeakElement(int[] nums) {
        if (nums.Length == 1)
            return 0;
        var mid = (nums.Length - 1) / 2;
        var p1 = GetPeak(nums, 0, mid);
        var p2 = GetPeak(nums, mid + 1, nums.Length - 1);
        return nums[p1] >= nums[p2] ? p1 : p2;
    }

    private int GetPeak(int[] nums, int start, int end)
    {
        if (end - start < 2)
            return nums[start] >= nums[end] ? start : end;
        var mid = (end - start) / 2;
        var p1 = GetPeak(nums, start, start + mid);
        var p2 = GetPeak(nums, start + mid + 1, end);
        return nums[p1] >= nums[p2] ? p1 : p2;
    }
}