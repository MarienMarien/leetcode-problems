public class Solution {
    public bool CheckSubarraySum(int[] nums, int k) {
        if(nums.Length < 2)
            return false;
        var runSum = 0;
        var runSumMods = new Dictionary<int, int>();
        for(var i = 0; i < nums.Length; i++)
        {
            runSum += nums[i];
            var runSumMod = runSum % k;
            if((runSumMod == 0 && i > 0) || (runSumMods.ContainsKey(runSumMod) && i - runSumMods[runSumMod] > 1))
                return true;
            runSumMods.TryAdd(runSumMod, i);
        }
        return false;
    }
}