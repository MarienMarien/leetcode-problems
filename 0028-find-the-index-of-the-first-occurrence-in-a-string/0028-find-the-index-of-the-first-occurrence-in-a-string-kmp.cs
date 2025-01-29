public class Solution {
    public int StrStr(string haystack, string needle) {
        var haystackLen = haystack.Length;
        var needleLen = needle.Length;

        var longestBorder = new int[needleLen];
        var prevOccur = 0;
        var id = 1;
        while (id < needleLen)
        {
            if (needle[id] == needle[prevOccur])
            {
                prevOccur++;
                longestBorder[id] = prevOccur;
                id++;
                continue;
            }
            // otherwise, if needle[id] != needle[prev]
            if (prevOccur == 0)
            {
                longestBorder[id] = 0;
                id++;
            }
            else 
            {
                prevOccur = longestBorder[prevOccur - 1];
            }
        }

        var haystackId = 0;
        var needleId = 0;
        while (haystackId < haystackLen)
        {
            if (haystack[haystackId] == needle[needleId])
            {
                haystackId++;
                needleId++;
                if (needleId == needleLen)
                {
                    return haystackId - needleLen;
                }
                continue;
            }
            // otherwise
            if (needleId == 0)
            {
                haystackId++;
            }
            else 
            {
                needleId = longestBorder[needleId - 1];
            }

        }

        return -1;
    }
}