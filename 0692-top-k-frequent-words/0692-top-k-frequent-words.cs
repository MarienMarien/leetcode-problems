public class Solution {
    public IList<string> TopKFrequent(string[] words, int k) {
        var map = new Dictionary<string, int>();
        foreach (var w in words) {
            if (!map.ContainsKey(w))
                map.Add(w, 0);
            map[w]++;
        }
        return map.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Take(k).Select(x => x.Key).ToList();
    }
}