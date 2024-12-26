public class Solution {
    private int _waysCount;
    public int FindTargetSumWays(int[] nums, int target)
    {
        CheckWays(nums, 0, 0, target);
        return _waysCount;
    }

    private void CheckWays(int[] nums, int currId, int currSum, int target)
    {
        if (currId >= nums.Length)
        {
            if (currSum == target)
                _waysCount++;
            return;
        }
        var nextId = currId + 1;
        CheckWays(nums, nextId, currSum + nums[currId], target);
        CheckWays(nums, nextId, currSum - nums[currId], target);
    }
}