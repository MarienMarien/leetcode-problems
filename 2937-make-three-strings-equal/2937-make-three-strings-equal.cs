public class Solution {
    public int FindMinimumOperations(string s1, string s2, string s3) {
        if(s1[0] != s2[0] || s1[0] != s3[0])
            return -1;
        const char dflt = '-';
        var len = Math.Min(s1.Length, Math.Min(s2.Length, s3.Length));
        var opCount = 0;
        var i = 0;
        for(; i < len; i++)
        {
            if(s1[i] != s2[i] || s1[i] != s3[i])
                break;
        }
        opCount += s1.Length + s2.Length + s3.Length - 3 * i;
        return opCount;
    }
}