public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length)
            return false;
        var alphabet = new int[26];
        var nonZeroCount = 0;
        for (var i = 0; i < s.Length; i++) {
            var sId = s[i] - 'a';
            alphabet[sId]++;
            var tId = t[i] - 'a';
            alphabet[tId]--;
            if (sId == tId)
                continue;
            if (alphabet[sId] - 1 == 0)
                nonZeroCount++;
            if (alphabet[tId] + 1 == 0)
                nonZeroCount++;
            if (alphabet[sId] == 0)
                nonZeroCount--;
            if (alphabet[tId] == 0)
                nonZeroCount--;
        }
        return nonZeroCount == 0;
    }
}