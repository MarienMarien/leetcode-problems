public class Solution {
    public int MaximalNetworkRank(int n, int[][] roads) {
        var map = new Dictionary<int, ISet<int>>();
        foreach (var r in roads) {
            map.TryAdd(r[0], new HashSet<int>());
            map[r[0]].Add(r[1]);
            map.TryAdd(r[1], new HashSet<int>());
            map[r[1]].Add(r[0]);
        }

        var maxRank = 0;
        for (var city1 = 0; city1 < n - 1; city1++)
        {
            for (var city2 = city1 + 1; city2 < n; city2++)
            {
                var currRank = 0;
                if (map.ContainsKey(city1)) { 
                    currRank += map[city1].Count;
                    if (map[city1].Contains(city2))
                        currRank--;
                }
                if (map.ContainsKey(city2))
                {
                    currRank += map[city2].Count;
                }

                maxRank = Math.Max(maxRank, currRank);
            }
        }
        return maxRank;
    }
}