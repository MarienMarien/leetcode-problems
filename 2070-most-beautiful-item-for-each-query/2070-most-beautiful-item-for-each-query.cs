public class Solution {
     public int[] MaximumBeauty(int[][] items, int[] queries)
    {
        Array.Sort(items, ((x, y) => x[0] - y[0]));
        var map = new Dictionary<int, int>();
        var maxBeauty = 0;
        foreach (var it in items) {
            maxBeauty = Math.Max(maxBeauty, it[1]);
            if(!map.TryAdd(it[0], maxBeauty))
                map[it[0]] = maxBeauty;
        }
        var prices = map.Keys.ToList();
        var ans = new int[queries.Length];
        for(var i = 0; i < queries.Length; i++)
        {
            if (map.ContainsKey(queries[i]))
            {
                ans[i] = map[queries[i]];
            }
            else
            {
                var closestItemPrice = FindNearestPrice(prices, queries[i]);
                ans[i] = map.ContainsKey(closestItemPrice) ? map[closestItemPrice] : 0;
            }
        }
        return ans;
    }

    private int FindNearestPrice(IList<int> keys, int query)
    {
        if (query < keys[0])
            return -1;
        if (query > keys[^1])
            return keys[^1];
        var start = 0; 
        var end = keys.Count - 1;
        while (start < end) {
            var mid = (start + end) / 2;
            if (keys[mid] < query)
            {
                start = mid + 1;
            }
            else {
                end = mid;
            }
        }
        return keys[start - 1];
    }
}