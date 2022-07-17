public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        var startPos = FindPos(nums, target,  -1);
        if (startPos == -1)
            return new int[] { startPos, startPos };
        var endPos = FindPos(nums, target,  1);
        return new int[] { startPos, endPos };
    }

    private int FindPos(int[] nums, int target, int koef)
    {
        var start = 0;
        var end = nums.Length - 1;
        while (start <= end)
        {
            var mid = (start + end) / 2;
            if (nums[mid] == target)
            {
                if (koef < 0)
                {
                    if (mid == start || nums[mid + koef] != target)
                        return mid;
                    end = mid - 1;
                }
                if (koef > 0)
                {
                    if (mid == end || nums[mid + koef] != target)
                        return mid;
                    start = mid + 1;
                }
            }
            else if (nums[mid] > target)
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }
        return -1;
    }
}