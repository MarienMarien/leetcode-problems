public class Solution {
    public int FirstUniqChar(string s) {
        if (s.Length == 0)
            return -1;
        if (s.Length == 1)
            return 0;
        var alphabet = new int[26];
        for (var i = 0; i < s.Length; i++)
        {
            var alphabetId = s[i] - 'a';
            alphabet[alphabetId]++;
        }

        for (var i = 0; i < s.Length; i++)
        {
            var alphabetId = s[i] - 'a';
            if (alphabet[alphabetId] == 1)
                return i;
        }
        return -1;
    }
}