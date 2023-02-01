public class Solution {
    public string GcdOfStrings(string str1, string str2) {
        var minStrLen = Math.Min(str1.Length, str2.Length);
        var maxConnomLen = minStrLen;
        var str1Len = str1.Length;
        var str2Len = str2.Length;
        var divisor = 2;
        while (maxConnomLen > 0) {
            if (str1Len % maxConnomLen == 0 && str2Len % maxConnomLen == 0)
            {
                var strDivisor = str1[0..maxConnomLen];
                if (CanDivide(str1, strDivisor) && CanDivide(str2, strDivisor))
                {
                    break;
                }
            }
            maxConnomLen = minStrLen / divisor;
            divisor++;
        }
        return maxConnomLen > 0 ? str1[0..maxConnomLen] : "";
    }

    private bool CanDivide(string str, string divisor)
    {
        if (str.Length % divisor.Length > 0)
            return false;
        var divisorId = 0;
        foreach (var ch in str) {
            if (ch != divisor[divisorId])
                return false;
            divisorId = (divisorId + 1) % divisor.Length;
        }
        return true;
    }
}