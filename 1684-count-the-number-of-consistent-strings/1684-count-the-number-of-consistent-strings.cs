public class Solution {
    public int CountConsistentStrings(string allowed, string[] words) {
        var alphabet = new int[26];
        foreach(var a in allowed)
        {
            alphabet[a - 'a']++;
        }

        var consistentCount = 0;
        foreach(var w in words)
        {
            var isConsistent = true;
            foreach(var ch in w)
            {
                if(alphabet[ch - 'a'] == 0)
                {
                    isConsistent = false;
                    break;
                }
            }
            if(isConsistent)
                consistentCount++;
        }

        return consistentCount;
    }
}