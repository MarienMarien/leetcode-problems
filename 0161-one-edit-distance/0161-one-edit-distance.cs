public class Solution {
    public bool IsOneEditDistance(string s, string t) {
        // make s always shorter
        if (s.Length > t.Length)
            return IsOneEditDistance(t, s);
        if (Math.Abs(s.Length - t.Length) > 1 || s == t)
            return false;
        if (s.Length == 0 && t.Length == 1)
            return true;
        var sId = 0;
        var tId = 0;
        var diffCount = 0;
        while (sId < s.Length) {
            if (tId >= t.Length || s[sId] != t[tId])
            {
                diffCount++;
                if (tId + 1 >= t.Length || s[sId] != t[tId + 1])
                    sId++;
                tId++;
                continue;
            }
            tId++;
            sId++;
        }
        if (tId < t.Length)
            diffCount++;
        return diffCount == 1;
    }
}