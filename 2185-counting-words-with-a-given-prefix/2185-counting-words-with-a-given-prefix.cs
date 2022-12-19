public class Solution {
    public int PrefixCount(string[] words, string pref) {
        var count = 0;
        foreach (var w in words) { 
            if(w[0] == pref[0] && w.StartsWith(pref))
                count++;
        }
        return count;
    }
}