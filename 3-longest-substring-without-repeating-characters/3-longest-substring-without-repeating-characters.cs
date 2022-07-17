public class Solution {
    public int LengthOfLongestSubstring(string s) {
        if (s == null || s.Length == 0)
            return 0;
        if (s.Length == 1)
            return 1;
        var charsSet = new Dictionary<char, int>();
        charsSet[s[0]] = 0;
        var start = 0;
        var end = 1;
        var longestSubstring = 0;
        while (end < s.Length) {
            if (charsSet.ContainsKey(s[end])) {
                longestSubstring = Math.Max(longestSubstring, end - start);
                if(start <= charsSet[s[end]])
                    start = charsSet[s[end]] + 1;
                charsSet[s[end]] = end;
            }
            charsSet[s[end]] = end;
            end++;
        }
        longestSubstring = Math.Max(longestSubstring, end - start);
        return longestSubstring;
    }
}