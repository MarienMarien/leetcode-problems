public class Solution {
    public int CharacterReplacement(string s, int k) {
        var windowAlphabet = new Dictionary<char, int>();
        var windowStart = 0;
        var longestSubStr = 0;
        var windowMaxFreq = 0;
        var i = 0;
        for(; i < s.Length; i++)
        {
            if(!windowAlphabet.TryAdd(s[i], 1))
                windowAlphabet[s[i]]++;
            
            windowMaxFreq = Math.Max(windowMaxFreq, windowAlphabet[s[i]]);
            longestSubStr = Math.Max(longestSubStr, i - windowStart);
            while(windowStart < i && i - windowStart + 1 - windowMaxFreq > k)
            {
                windowAlphabet[s[windowStart]]--;
                windowStart++;
            }
            
        }
        longestSubStr = Math.Max(longestSubStr, i - windowStart);

        return longestSubStr;
    }
}