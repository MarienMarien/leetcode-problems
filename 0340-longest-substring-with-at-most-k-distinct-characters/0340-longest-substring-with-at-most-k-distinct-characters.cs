public class Solution {
    public int LengthOfLongestSubstringKDistinct(string s, int k) {
        if (k == 0)
            return 0;
        if (k > s.Length)
            return s.Length;
        var map = new Dictionary<char, int>();
        var maxLen = 0;
        for (var i = 0; i < s.Length; i++)
        {
            if (!map.TryAdd(s[i], 1))
                map[s[i]]++;
            if (map.Count <= k)
            {
                maxLen++;
            }
            else
            {
                map[s[i - maxLen]]--;
                if (map[s[i - maxLen]] == 0)
                    map.Remove(s[i - maxLen]);
            }
        }
        return maxLen;
    }
}