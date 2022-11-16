public class Solution {
    public bool BackspaceCompare(string s, string t) {
        var sId = s.Length - 1;
        var tId = t.Length - 1;
        var sShCount = 0;
        var tShCount = 0;
        while (sId >= 0 || tId >= 0) {
            while (sId >= 0) {
                if (s[sId] == '#')
                {
                    sShCount++;
                    sId--;
                }
                else if (sShCount > 0)
                {
                    sShCount--;
                    sId--;
                }
                else break;
            }
            while (tId >= 0)
            {
                if (t[tId] == '#')
                {
                    tShCount++;
                    tId--;
                }
                else if (tShCount > 0)
                {
                    tShCount--;
                    tId--;
                }
                else break;
            }
            if (tId >= 0 && sId >= 0 && t[tId] != s[sId])
                return false;
            if ((sId >= 0) != (tId >= 0))
                return false;
            sId--;
            tId--;
            
        }
        return sId < 0 && tId < 0;
    }
}