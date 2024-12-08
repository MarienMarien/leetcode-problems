public class Solution {
    public int MaxLength(int[] ribbons, int k) {
        var totalLen = 0L;
        foreach (var r in ribbons)
            totalLen += r;
        if (totalLen < k)
            return 0;
        var end = (int)(totalLen / k);
        if (CountCuts(ribbons, end) == k)
            return end;
        var start = 1;
        while (start < end)
        {
            var mid = (end + start + 1) / 2;
            var cuts = CountCuts(ribbons, mid);
            if (cuts >= k)
            {
                start = mid;
            }
            else {
                end = mid - 1;
            }
        }
        return start;
    }

    private int CountCuts(int[] ribbons, int cutLen)
    {
        var cutsCount = 0;
        foreach (var r in ribbons)
        {
            cutsCount += r / cutLen;
        }

        return cutsCount;
    }
}