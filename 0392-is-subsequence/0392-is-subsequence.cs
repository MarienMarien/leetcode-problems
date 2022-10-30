public class Solution {
    public bool IsSubsequence(string s, string t) {
        if (s.Length > t.Length)
            return false;
        var sId = 0;
        var tId = 0;
        while (tId < t.Length) {
            if (sId == s.Length)
                return true;
            if (s[sId] == t[tId])
                sId++;
            tId++;
        }
        return sId == s.Length;
    }
}