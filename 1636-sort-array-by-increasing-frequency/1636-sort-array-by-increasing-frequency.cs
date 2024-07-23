public class Solution {
    public int[] FrequencySort(int[] nums) {
        var map = new Dictionary<int, int>();
        foreach (var n in nums)
        {
            if (!map.TryAdd(n, 1))
                map[n]++;
        }

        var sorted = map.OrderBy(p => p, 
            Comparer<KeyValuePair<int, int>>.Create((x, y) =>
            {
                if (x.Value == y.Value)
                    return y.Key - x.Key;
                return x.Value - y.Value;
            }));
        var res = new int[nums.Length];
        var resId = 0;
        foreach (var it in sorted)
        {
            for (var i = 0; i < it.Value; i++) {
                res[resId] = it.Key;
                resId++;
            }
        }

        return res;
    }
}