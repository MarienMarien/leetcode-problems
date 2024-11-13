public class Solution {
    public long CountFairPairs(int[] nums, int lower, int upper) {
        Array.Sort(nums);
        var pairCount = 0L;
        
        for (var i = 0; i < nums.Length; i++)
        {
            var lowestPossibleId = FindElement(nums, 0, i - 1, lower - nums[i]);
            var highestPossibleId = FindElement(nums, 0, i - 1, upper - nums[i] + 1);
            pairCount +=  highestPossibleId - lowestPossibleId;
        }

        return pairCount;
    }

    private int FindElement(int[] nums, int start, int end, int target)
    {
        while (start <= end)
        {
            var mid = (start + end) / 2;
            if (nums[mid] < target)
                start = mid + 1;
            else
                end = mid - 1;
        }

        return start;
    }
}