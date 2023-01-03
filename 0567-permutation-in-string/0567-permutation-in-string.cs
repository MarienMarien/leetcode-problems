public class Solution {
    public bool CheckInclusion(string s1, string s2) {
        var dict = new Dictionary<char, int>();
        foreach (var ch in s1) {
            if (!dict.TryAdd(ch, 1))
                dict[ch]++;
        }
        for (var i = 0; i < s2.Length && s2.Length - i >= s1.Length; i++) {
            if (!dict.ContainsKey(s2[i]))
                continue;
            var dict2 = new Dictionary<char, int>();
            var found = true;
            for (var j = i; j < i + s1.Length; j++) {
                if (!dict.ContainsKey(s2[j]))
                {
                    found = false;
                    break;
                }
                dict2.TryAdd(s2[j], 0);
                dict2[s2[j]]++;
                if (dict2[s2[j]] > dict[s2[j]]) {
                    found = false;
                    break;
                }
            }
            if (found)
                return true;
        }
        return false;
    }
}