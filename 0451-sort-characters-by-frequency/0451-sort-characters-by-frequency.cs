public class Solution {
    public string FrequencySort(string s) {
        var map = new Dictionary<char, int>();
        foreach (var ch in s) { 
            if(!map.ContainsKey(ch))
                map.Add(ch, 0);
            map[ch]++;
        }
        var pq = new PriorityQueue<char, int>();
        foreach (var pair in map) {
            pq.Enqueue(pair.Key, pair.Value * -1);
        }
        var sb = new StringBuilder();
        while (pq.Count > 0) {
            var ch = pq.Dequeue();
            sb.Append(ch, map[ch]);
        }
        return sb.ToString();
    }
}