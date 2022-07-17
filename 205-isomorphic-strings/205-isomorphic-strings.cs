public class Solution {
    public bool IsIsomorphic(string s, string t) {
        var sTot = new Dictionary<char, char>();
        var tTos = new Dictionary<char, char>();
        for (var i = 0; i < s.Length; i++) {
            if (sTot.ContainsKey(s[i]))
            {
                if (t[i] != sTot[s[i]]) return false;
            }
            else {
                sTot[s[i]] = t[i];
            }
            if (tTos.ContainsKey(t[i]))
            {
                if (s[i] != tTos[t[i]]) return false;
            }
            else {
                tTos[t[i]] = s[i];
            }
        }
        return true;
    }
}