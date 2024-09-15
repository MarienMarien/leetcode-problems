public class Solution {
    public int FindTheLongestSubstring(string s) {
        var alphabet = new int[26];
        alphabet['a' - 'a'] = 1;
        alphabet['e' - 'a'] = 2;
        alphabet['i' - 'a'] = 4;
        alphabet['o' - 'a'] = 8;
        alphabet['u' - 'a'] = 16;

        var prefixXor = 0;
        var longestSubstr = 0;

        var prevOddOccurance = new int[32];
        Array.Fill(prevOddOccurance, -1);

        for (var i = 0; i < s.Length; i++)
        {
            prefixXor ^= alphabet[s[i] - 'a'];
            if (prevOddOccurance[prefixXor] == -1 && prefixXor != 0)
                prevOddOccurance[prefixXor] = i;
            longestSubstr = Math.Max(longestSubstr, i - prevOddOccurance[prefixXor]);
        }

        return longestSubstr;
    }
}