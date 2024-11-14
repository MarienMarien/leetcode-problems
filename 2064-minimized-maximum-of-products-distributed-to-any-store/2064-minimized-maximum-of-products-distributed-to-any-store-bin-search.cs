public class Solution {
    public int MinimizedMaximum(int n, int[] quantities) {
        var max = quantities.Max();
        var lo = 0;
        var hi = max;

        while (lo < hi)
        {
            var mid = (lo + hi) / 2;
            if (CanDistribute(mid, n, quantities))
                hi = mid;
            else
                lo = mid + 1;
        }

        return lo;
    }

    private bool CanDistribute(int distributed, int n, int[] quantities)
    {
        var qId = 0;
        var distributeRem = quantities[qId];

        for (var store = 0; store < n; store++)
        {
            if (distributeRem <= distributed)
            {
                qId++;
                if (qId == quantities.Length)
                    return true;
                distributeRem = quantities[qId];
                continue;
            }
            distributeRem -= distributed;
        }

        return false;
    }
}