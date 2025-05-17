public class Solution {
    public bool AreOccurrencesEqual(string s) {
        var alphabet = new int[26];
        var maxOccur = 0;
        foreach(var ch in s)
        {
            alphabet[ch - 'a']++;
            maxOccur = Math.Max(maxOccur, alphabet[ch - 'a']);
        }

        for(var i = 0; i < alphabet.Length; i++)
        {
            if(alphabet[i] > 0 && alphabet[i] != maxOccur)
                return false;
        }
        return true;
    }
}