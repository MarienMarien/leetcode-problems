public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        if(nums.Length < 2)
            return false;
        var runSum = 0;
        var runSumMods = new Dictionary<int, int> { {0, -1} };
        for(var i = 0; i < nums.Length; i++)
        {
            runSum += nums[i];
            var runSumMod = runSum % k;
            if(runSumMods.ContainsKey(runSumMod) && i - runSumMods[runSumMod] > 1)
                return true;
            runSumMods.TryAdd(runSumMod, i);
        }
        return false;
    }
}