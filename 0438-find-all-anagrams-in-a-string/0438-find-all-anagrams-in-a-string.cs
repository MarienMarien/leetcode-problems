public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        if (s.Length < p.Length)
            return new List<int>();
        IList<int> list = new List<int>();
        var pAlphabet = new int[26];
        var sAlphabet = new int[26];
        foreach (var ch in p) {
            pAlphabet[ch - 'a']++;
        }

        for (var i = 0; i < s.Length; i++) { 
            sAlphabet[s[i] - 'a']++;
            if(i >= p.Length)
                sAlphabet[s[i - p.Length] - 'a']--;
            if (Enumerable.SequenceEqual(sAlphabet, pAlphabet))
                list.Add(i - p.Length + 1);
        }
        return list;
    }
}