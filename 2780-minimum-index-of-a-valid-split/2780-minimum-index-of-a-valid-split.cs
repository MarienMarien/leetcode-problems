public class Solution {
    public int MinimumIndex(IList<int> nums) {
        var dominant = 0;
        var freq = new Dictionary<int, int> { { dominant, 0 } };
        
        foreach(var n in nums)
        {
            if(!freq.TryAdd(n, 1))
                freq[n]++;
            if(freq[n] > freq[dominant])
                dominant = n;
        }

        var dominantCount = freq[dominant];
        var dominantCurrCount = 0;
        var numsLen = nums.Count;
        for(var i = 0; i < nums.Count; i++)
        {
            if(nums[i] != dominant)
                continue;
            dominantCurrCount++;
            var leftLen = i + 1;
            var isLeftPartValid = dominantCurrCount > leftLen / 2;
            var rightLen = numsLen - i - 1;
            var isRightPartValid = dominantCount - dominantCurrCount > rightLen / 2;
            if(isLeftPartValid && isRightPartValid)
                return i;
        }

        return -1;
    }
}