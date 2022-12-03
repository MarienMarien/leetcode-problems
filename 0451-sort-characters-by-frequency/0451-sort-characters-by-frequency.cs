public class Solution {
    public string FrequencySort(string s) {
        var map = new Dictionary<char, int>();
        foreach(var ch in s){
            if(!map.ContainsKey(ch))
                map.Add(ch, 0);
            map[ch]++;
        }
        var mapSorted = map.OrderByDescending(ch => ch.Value);
        var sb = new StringBuilder();
        foreach(var item in mapSorted){
            sb.Append(item.Key, item.Value);
        }
        return sb.ToString();
    }
}