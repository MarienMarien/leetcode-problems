public class Solution {
    public bool CheckAlmostEquivalent(string word1, string word2) {
        var alphabet = new int[26];
        foreach(var ch in word1)
        {
            alphabet[ch - 'a'] += 1;
        }

        foreach(var ch in word2)
        {
            alphabet[ch - 'a'] -= 1;
        }

        foreach(var ch in alphabet)
        {
            if(Math.Abs(ch) > 3)
                return false;
        }

        return true;
    }
}