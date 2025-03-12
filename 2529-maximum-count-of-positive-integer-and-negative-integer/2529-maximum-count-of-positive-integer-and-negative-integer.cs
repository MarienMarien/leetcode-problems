public class Solution {
    public int MaximumCount(int[] nums) {
        var n = nums.Length;
        var lastNegativeId = -1;
        var firstPositiveId = n;
        var start = 0;
        var end = n - 1;
        while(start <= end)
        {
            var mid = (start + end) / 2;
            if(nums[mid] >= 0)
            {
                end = mid - 1;
            }
            else 
            {
                lastNegativeId = mid;
                start = mid + 1;
            }
        }
        start = 0;
        end = n - 1;
        while(start <= end)
        {
            var mid = (start + end) / 2;
            if(nums[mid] <= 0)
            {
                start = mid + 1;
            }
            else 
            {
                firstPositiveId = mid;
                end = mid - 1;
            }
        }

        return Math.Max(n - firstPositiveId, lastNegativeId - 0 + 1);
    }
}