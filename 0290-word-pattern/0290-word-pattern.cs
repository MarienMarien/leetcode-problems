public class Solution {
    public bool WordPattern(string pattern, string s) {
        var words = s.Split(" ");
        if (words.Length != pattern.Length)
            return false;
        var matchedSet = new HashSet<string>();
        var map = new Dictionary<char, string>();
        for (var i = 0; i < pattern.Length; i++) {
            if (!map.ContainsKey(pattern[i])) {
                if (matchedSet.Contains(words[i]))
                {
                    map.Add(pattern[i], "");
                }
                else
                {
                    map.Add(pattern[i], words[i]);
                    matchedSet.Add(words[i]);
                }
            }
        }
        for (var i = 0; i < pattern.Length; i++) {
            if (words[i] != map[pattern[i]])
                return false;
        }
        return true;
       /*
       // 2 hashMaps approach
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
        */
    }
}