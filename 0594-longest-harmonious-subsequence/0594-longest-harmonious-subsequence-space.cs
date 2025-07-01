public class Solution {
    public int FindLHS(int[] nums) {
        var map = new Dictionary<int, int>();
        foreach(var n in nums)
        {
            if(!map.TryAdd(n, 1))
                map[n]++;
        }

        var maxLen = 0;
        foreach(var n in map)
        {
            var harmoniousNum = n.Key - 1;
            if(!map.ContainsKey(harmoniousNum))
                continue;
            var countCandidate = n.Value + map[harmoniousNum];
            maxLen = Math.Max(maxLen, countCandidate);
        }

        return maxLen;
    }
}