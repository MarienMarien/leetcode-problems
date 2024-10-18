public class Solution {
    public int CountMaxOrSubsets(int[] nums) {
        var maxBitwiseOr = 0;
        foreach (var n in nums)
            maxBitwiseOr |= n;

        return CountSubsets(nums, 0, maxBitwiseOr, 0);
    }

    private int CountSubsets(int[] nums, int currBitwiseOr, int maxBitwiseOr, int startId)
    {
        var currCount = 0;
        for (var i = startId; i < nums.Length; i++)
        {
            if ((currBitwiseOr | nums[i]) == maxBitwiseOr)
                currCount++;
            currCount += CountSubsets(nums, currBitwiseOr | nums[i], maxBitwiseOr, i + 1);
        }

        return currCount;
    }
}