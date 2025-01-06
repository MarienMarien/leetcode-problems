public class Solution {
    public int[] MinOperations(string boxes) {
        const char ONE = '1';
        var l2r = new int[boxes.Length];
        var r2l = new int[boxes.Length];
        var opCount = 0;
        var onesCount = 0;
        for (var i = 0; i < boxes.Length; i++)
        {
            l2r[i] = opCount;
            if (boxes[i] == ONE)
                onesCount++;
            opCount += onesCount;
        }

        opCount = 0;
        onesCount = 0;
        for (var i = boxes.Length - 1; i >= 0; i--)
        {
            r2l[i] = opCount;
            if (boxes[i] == ONE)
                onesCount++;
            opCount += onesCount;
        }

        var ans = new int[boxes.Length];
        for (var i = 0; i < boxes.Length; i++)
        {
            ans[i] = l2r[i] + r2l[i];
        }
        return ans;
    }
}