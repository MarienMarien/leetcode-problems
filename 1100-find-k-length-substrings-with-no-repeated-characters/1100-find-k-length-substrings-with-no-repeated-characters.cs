public class Solution {
    public int NumKLenSubstrNoRepeats(string s, int k) {
        var lastCharId = new Dictionary<char, int>();
        var windowStartId = 0;
        var n = s.Length;
        var substrCount = 0;
        for(var i = 0; i < n; i++)
        {
            var currChar = s[i];
            if(lastCharId.ContainsKey(currChar) && lastCharId[currChar] >= windowStartId)
            {
                windowStartId = lastCharId[currChar] + 1;
            }

            lastCharId[currChar] = i;
            var windowLen = i - windowStartId + 1;
            if(windowLen == k)
            {
                substrCount++; 
                windowStartId++;
            }
        }

        return substrCount;
    }
}