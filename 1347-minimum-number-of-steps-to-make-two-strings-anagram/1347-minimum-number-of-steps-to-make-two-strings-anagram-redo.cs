public class Solution {
    public int MinSteps(string s, string t) {
        var alphabet = new int[26];
        var minSteps = 0;
        for(var i = 0; i < s.Length; i++)
        {
            var sCh = s[i] - 'a';
            var tCh = t[i] - 'a';
            alphabet[sCh]++;
            alphabet[tCh]--;
        }

        foreach(var ch in alphabet)
        {
            if(ch > 0)
                minSteps += ch;
        }
        return minSteps;
    }
}