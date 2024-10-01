public class Solution {
    public int LargestUniqueNumber(int[] nums) {
        var countMap = new Dictionary<int, int>();
        foreach(var n in nums)
        {
            if(!countMap.TryAdd(n, 1))
                countMap[n]++;
        }

        var ans = -1;
        foreach(var item in countMap)
        {
            if(item.Value > 1)
                continue;
            if(item.Key > ans)
                ans = item.Key;
        }

        return ans;
    }
}