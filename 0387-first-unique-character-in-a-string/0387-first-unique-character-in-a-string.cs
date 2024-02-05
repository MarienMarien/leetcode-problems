public class Solution {
    public int FirstUniqChar(string s) {
        var alphabet = new int[26];
        foreach(var ch in s)
        {
            alphabet[ch - 'a']++;
        }
        for(var i = 0; i < s.Length; i++)
        {
            if(alphabet[s[i] - 'a'] == 1)
                return i;
        }

        return -1;
    }
}