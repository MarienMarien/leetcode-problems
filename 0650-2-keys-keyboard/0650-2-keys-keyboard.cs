public class Solution {
    public int MinSteps(int n) {
         if (n == 1)
            return 0;
        return GetMinOperations(n, 2, 1, 2);
    }

    private int GetMinOperations(int n, int currentLen, int copyLen, int opCount)
    {
        if (currentLen == n)
            return opCount;
        if (currentLen > n)
            return Int32.MaxValue;

        var pasteOperationount = GetMinOperations(n, currentLen + copyLen, copyLen, opCount + 1);
        var copyPasteOperationCount = GetMinOperations(n, currentLen * 2, currentLen, opCount + 2);

        return Math.Min(pasteOperationount, copyPasteOperationCount);
    }
}