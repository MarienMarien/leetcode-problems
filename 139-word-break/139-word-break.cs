public class Solution {
    Dictionary<string, bool> cache = new Dictionary<string, bool>();
    public bool WordBreak(string s, IList<string> wordDict) {
        if (s.Length == 0)
            return true;

        if (cache.TryGetValue(s, out bool result))
            return result;

        if (wordDict.Contains(s))
            return true;

        bool isContains = false;
        for (int i = 1; i < s.Length; i++)
        {
            isContains = wordDict.Contains(s[0..i]) && WordBreak(s[i..], wordDict);
            cache[s] = isContains;

            if (isContains)
                return true;
        }

        return false;
    }
}