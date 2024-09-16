public class Solution {
    public bool AreOccurrencesEqual(string s) {
        var alphabet = new int[26];
        foreach(var ch in s)
        {
            alphabet[ch - 'a']++;
        }

        var freq = 0;
        foreach(var a in alphabet)
        {
            if(a != 0)
            {
                if(freq == 0)
                    freq = a;
                else if(a != freq)
                    return false;
            }
        }

        return true;
    }
}