public class Solution {
    public bool WordPattern(string pattern, string s) {
        var words = s.Split(" ");
        if (pattern.Length != words.Length)
            return false;
        var pToS = new Dictionary<char, string>();
        var sToP = new Dictionary<string, char>();
        for (var i = 0; i < pattern.Length; i++)
        {
            if (pToS.ContainsKey(pattern[i]))
            {
                if (pToS[pattern[i]] != words[i])
                    return false;
            }
            else {
                pToS.Add(pattern[i], words[i]);
            }
            if (sToP.ContainsKey(words[i]))
            {
                if (sToP[words[i]] != pattern[i])
                    return false;
            }
            else {
                sToP.Add(words[i], pattern[i]);
            }
        }
        return true;
    }
}