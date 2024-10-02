public class Solution {
    public int[] ArrayRankTransform(int[] arr) {
        var map = new Dictionary<int, ISet<int>>();
        for(var i = 0; i < arr.Length; i++)
        {
            if (!map.TryAdd(arr[i], new HashSet<int> { i }))
                map[arr[i]].Add(i);
        }

        var ranks = new int[arr.Length];
        var sortedMap = map.OrderBy(x => x.Key);
        var rank = 1;
        foreach (var item in sortedMap)
        {
            foreach (var id in item.Value)
            {
                ranks[id] = rank;
            }
            rank++;
        }

        return ranks;
    }
}