public class Solution {
    public int SearchInsert(int[] nums, int target) {
        if (nums == null || nums.Length == 0 || target < nums[0])
            return 0;
        if (nums[nums.Length - 1] < target)
            return nums.Length;
        return SearchPos(nums, 0, nums.Length - 1, target);
    }

    private int SearchPos(int[] nums, int start, int end, int target)
    {
        var mid = (start + end) / 2;
        if (nums[mid] == target)
            return mid;
        if (start == end)
            return target < nums[end] ? end : end + 1;
        if (target < nums[mid])
            return SearchPos(nums, start, mid, target);
        else
            return SearchPos(nums, mid + 1, end, target);
    }
}