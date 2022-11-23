public class Solution {
    public char FindTheDifference(string s, string t) {
        var alphabet = new int[26];
        for (var i = 0; i < s.Length; i++) {
            alphabet[s[i] - 'a']++;
            alphabet[t[i] - 'a']--;
        }
        alphabet[t[t.Length - 1] - 'a']--;
        var j = 0;
        while (alphabet[j] == 0)
            j++;
        return (char)(j + 'a');
    }
}