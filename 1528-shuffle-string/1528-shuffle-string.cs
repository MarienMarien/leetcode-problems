public class Solution {
    public string RestoreString(string s, int[] indices) {
        var newS = new char[s.Length];
        for (var i = 0; i < indices.Length; i++)
        {
            newS[indices[i]] = s[i];
        }
        return new string(newS);
    }
}