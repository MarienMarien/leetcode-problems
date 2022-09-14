public class Solution {
    public int ShipWithinDays(int[] weights, int days) {
        var lo = weights.Max();
        var hi = weights.Sum();
        while (lo < hi) {
            var capacity = (lo + hi) / 2;
            var daysNeeded = ShipForDays(weights, capacity);
            if (daysNeeded > days)
                lo = capacity + 1;
            else
                hi = capacity;
        }
        return lo;
    }

    private int ShipForDays(int[] weights, int capacity)
    {
        var daysCounted = 1;
        var currWeightSum = 0;
        for (var i = 0; i < weights.Length; i++)
        {
            if (currWeightSum + weights[i] > capacity)
            {
                daysCounted++;
                currWeightSum = 0;
            }
            currWeightSum += weights[i];
        }
        return daysCounted;
    }
}