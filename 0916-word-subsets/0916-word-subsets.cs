public class Solution {
    public IList<string> WordSubsets(string[] words1, string[] words2) {
        var alphabet = new Dictionary<char, int>();
        foreach (var w in words2)
        {
            var map = new Dictionary<char, int>();
            foreach (var ch in w)
            {
                if (!map.TryAdd(ch, 1))
                    map[ch]++;
                if(!alphabet.TryAdd(ch, map[ch]))
                alphabet[ch] = Math.Max(alphabet[ch], map[ch]);
            }
        }

        var universaStrs = new List<string>();
        foreach (var w in words1)
        {
            var map = new Dictionary<char, int>();
            var matched = 0;
            foreach (var ch in w)
            {
                if (!map.TryAdd(ch, 1))
                    map[ch]++;
                if (!alphabet.ContainsKey(ch))
                    continue;
                if (map[ch] == alphabet[ch])
                    matched++;
            }
            if (matched == alphabet.Count)
                universaStrs.Add(w);
        }

        return universaStrs;
    }
}