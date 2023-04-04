public class Solution {
    public string LongestNiceSubstring(string s) {
        if (s.Length < 2)
            return string.Empty;
        var maxNiceLen = 0;
        var maxNiceStart = 0;
        var maxNiceEnd = 0;
        for (var i = 0; i < s.Length - 1; i++) {
            for (var j = i + 1; j < s.Length; j++) {
                if (IsNice(s, i, j) && j - i > maxNiceLen) {
                    maxNiceLen = j - i;
                    maxNiceStart = i;
                    maxNiceEnd = j + 1;
                }
            }
        }
        return s[maxNiceStart..(maxNiceEnd)];
    }

    private bool IsNice(string s, int start, int end)
    {
        var map = new Dictionary<char,bool>();
        var isNice = true;
        for (var i = start; i <= end; i++) {
            var val = false;
            if (char.IsLower(s[i])) {
                var upper = char.ToUpper(s[i]);
                val = map.ContainsKey(upper);
                if (!map.TryAdd(s[i], val))
                    map[s[i]] = val;
                if (val)
                    map[upper] = val;
            }
            if (char.IsUpper(s[i])) {
                var lower = char.ToLower(s[i]);
                val = map.ContainsKey(lower);
                if (!map.TryAdd(s[i], val))
                    map[s[i]] = val;
                if(val)
                    map[lower] = val;
            }
        }
        return map.Values.All(x => x == true);
    }
}