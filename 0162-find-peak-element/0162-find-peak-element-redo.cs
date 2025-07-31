public class Solution {
    public int FindPeakElement(int[] nums) {
        if(nums.Length < 2)
            return 0;
        return GetPeak(nums, 0, nums.Length - 1);
    }

    private int GetPeak(int[] nums, int start, int end)
    {
        if(end - start < 2)
            return nums[start] >= nums[end] ? start : end;
        var mid = (start + end) / 2;
        var left = GetPeak(nums, start, mid);
        var right = GetPeak(nums, mid + 1, end);
        return nums[left] >= nums[right] ? left : right;
    }
}