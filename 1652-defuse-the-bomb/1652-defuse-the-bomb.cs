public class Solution {
    public int[] Decrypt(int[] code, int k) {
        var windowSum = 0;
        var windowStartId = -1;
        var absK = Math.Abs(k);
        if (k != 0) {
            var codeId = k < 0 ? code.Length + k : 1;
            windowStartId = codeId;
            
            for (var i = 0; i < absK; i++)
            {
                windowSum += code[codeId];
                codeId = (codeId + 1) % code.Length;
            }
        }

        var res = new int[code.Length];
        for (var i = 0; i < res.Length; i++)
        {
            res[i] = windowSum;
            if (k != 0)
            {
                windowSum = k != 0 ? windowSum - code[windowStartId] + code[(windowStartId + absK) % code.Length] : 0;
                windowStartId = (windowStartId + 1) % code.Length;
            }
        }
        return res;
    }
}