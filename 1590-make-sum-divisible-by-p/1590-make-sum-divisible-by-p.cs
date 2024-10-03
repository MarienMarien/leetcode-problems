public class Solution {
    public int MinSubarray(int[] nums, int p) {
        var totalSum = 0;

        foreach (var n in nums)
        {
            totalSum = (totalSum + n) % p;
        }

        var targetExtra = totalSum % p;
        if (targetExtra == 0)
            return 0;

        var mods = new Dictionary<int, int> { { 0, -1 } };
        var currSum = 0;
        var minLen = nums.Length;
        for (var i = 0; i < nums.Length; i++)
        { 
            currSum = (currSum + nums[i]) % p;
            var needToRem = (currSum - targetExtra + p) % p;
            if (mods.ContainsKey(needToRem))
            {
                minLen = Math.Min(minLen, i - mods[needToRem]);
            }
            mods[currSum] = i;
        }

        return minLen == nums.Length ? -1 : minLen;
    }
}