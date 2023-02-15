public class Solution {
    public IList<string> FindAndReplacePattern(string[] words, string pattern) {
        var ans = new List<string>();
        foreach (var w in words) {
            var map = new Dictionary<char, char>();
            var checkSet = new HashSet<char>();
            var isMatch = true;
            for (var i = 0; i < w.Length; i++) {
                if (map.ContainsKey(w[i]))
                {
                    if (map[w[i]] != pattern[i]) {
                        isMatch = false;
                        break;
                    }
                }
                else {
                    if (checkSet.Contains(pattern[i])) {
                        isMatch = false;
                        break;
                    }
                    map.Add(w[i], pattern[i]);
                    checkSet.Add(pattern[i]);
                }
            }
            if(isMatch)
                ans.Add(w);
        }

        return ans;
    }
}