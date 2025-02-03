public class Solution {
    public int LongestMonotonicSubarray(int[] nums) {
        bool? isIncreasing = null;
        var longestMonotonicSubaray = 1;
        var currentMonotonicSubarrayLen = 1;
        for(var i = 1; i < nums.Length; i++)
        {
            if(nums[i] == nums[i - 1])
            {
                longestMonotonicSubaray = Math.Max(longestMonotonicSubaray, currentMonotonicSubarrayLen);
                currentMonotonicSubarrayLen = 1;
                isIncreasing = null;
                continue;
            }
            if(!isIncreasing.HasValue)
            {
                isIncreasing = nums[i] > nums[i - 1];
            }
            if((nums[i] > nums[i - 1]) == isIncreasing)
            {
                currentMonotonicSubarrayLen++;
                continue;
            }
            longestMonotonicSubaray = Math.Max(longestMonotonicSubaray, currentMonotonicSubarrayLen);
            currentMonotonicSubarrayLen = 2;
            isIncreasing = !isIncreasing;
        }

        longestMonotonicSubaray = Math.Max(longestMonotonicSubaray, currentMonotonicSubarrayLen);
        return longestMonotonicSubaray;
    }
}