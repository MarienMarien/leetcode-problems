public class Solution {
    public int StrStr(string haystack, string needle) {
        var res = -1;
        if (needle.Length > haystack.Length)
            return res;
        var hId = 0;
        var nId = 1;
        var haystackLen = haystack.Length;
        var needleLen = needle.Length;
        while (hId < haystack.Length)
        {
            if (haystack[hId] == needle[0] && haystackLen - hId >= needleLen)
            {
                while (nId < needle.Length)
                {
                    if (haystack[hId + nId] != needle[nId])
                    {
                        nId = 1;
                        break;
                    }
                    nId++;
                }
                if (nId == needle.Length)
                    return hId;
            }
            hId++;
        }
        return res;
    }
}