public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (s.Length < 2)
            return s.Length;
        var set = new HashSet<char>();
        var start = 0;
        set.Add(s[start]);
        var end = 1;
        var maxLen = 0;
        while (end < s.Length)
        {
            var curr = s[end];
            if (set.Contains(curr))
            {
                maxLen = Math.Max(maxLen, set.Count);
                while (start < end && s[start] != curr)
                {
                    set.Remove(s[start]);
                    start++;
                }
                start++;
                end++;
                continue;
            }
            set.Add(curr);
            end++;
        }
        maxLen = Math.Max(maxLen, set.Count);
        return maxLen;
    }
}