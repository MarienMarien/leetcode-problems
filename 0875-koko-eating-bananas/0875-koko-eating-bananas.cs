public class Solution {
    public int MinEatingSpeed(int[] piles, int h) {
        var maxPile = 0;
        foreach (var p in piles)
            maxPile = Math.Max(maxPile, p);
        var start = 1;
        var end = maxPile;
        while (start < end) {
            var mid = (start + end) / 2;
            if (IsFastEnough(piles, mid, h))
                end = mid;
            else
                start = mid + 1;
        }
        return start;
    }

    private bool IsFastEnough(int[] piles, int mid, int h)
    {
        var hoursNeeded = 0.0;
        foreach (var p in piles) {
            hoursNeeded += Math.Ceiling((double)p / mid);
        }
        return hoursNeeded <= h;
    }
}