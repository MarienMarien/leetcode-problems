public class Solution {
    private bool?[,] _dp;
    public bool CanPartition(int[] nums) {
        var sum = nums.Sum();
        if(sum % 2 == 1)
            return false;
        var half = sum / 2;
        _dp = new bool?[half + 1, nums.Length + 1];
        return CanPartition(nums, 0, half, 0);
    }

    private bool CanPartition(int[] nums, int i, int half, int currSum)
    {
        if(currSum == half)
            return true;
        if(currSum > half || i >= nums.Length)
            return false;
        if(_dp[currSum, i] != null)
            return _dp[currSum, i].Value;
        _dp[currSum, i] = CanPartition(nums, i + 1, half, currSum + nums[i]) 
            || CanPartition(nums, i + 1, half, currSum);
        return _dp[currSum, i].Value;
    }
}