public class Solution {
    public int[] MaximumBeauty(int[][] items, int[] queries) {
        Array.Sort(items, Comparer<int[]>.Create((x, y) => x[0] - y[0]));
        var prevKey = items[0][0];
        var maxBeautySoFar = items[0][1];
        var maxBeautyForPrice = new Dictionary<int, int>();
        foreach (var it in items)
        {
            maxBeautySoFar = Math.Max(maxBeautySoFar, it[1]);
            maxBeautyForPrice[it[0]] = maxBeautySoFar;
        }

        var res = new int[queries.Length];
        var prices = maxBeautyForPrice.Keys.ToList();
        for(var i = 0; i < queries.Length; i++)
        {
            if (maxBeautyForPrice.ContainsKey(queries[i]))
            {
                res[i] = maxBeautyForPrice[queries[i]];
                continue;
            }

            if (queries[i] < prices[0])
            {
                res[i] = 0;
                continue;
            }

            if (queries[i] > prices[^1])
            {
                res[i] = maxBeautyForPrice[prices[^1]];
                continue;
            }

            var start = 0;
            var end = prices.Count - 1;
            while (start < end)
            {
                var mid = (start + end) / 2;
                if (prices[mid] < queries[i])
                    start = mid + 1;
                else
                    end = mid;
            }
            res[i] = maxBeautyForPrice[prices[start - 1]];
        }

        return res;
    }
}