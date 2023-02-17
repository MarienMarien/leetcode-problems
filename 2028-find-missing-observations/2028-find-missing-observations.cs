public class Solution {
    public int[] MissingRolls(int[] rolls, int mean, int n) {
        var totalSum = (rolls.Length + n) * mean;
        var initialSum = 0;
        foreach (var r in rolls)
            initialSum += r;
        var neededSum = totalSum - initialSum;
        if (neededSum < n || neededSum > 6 * n )
            return Array.Empty<int>();
        var result = new int[n];
        var missedElement = neededSum / n;
        var extra = n - (neededSum % n);
        for (var i = 0; i < n; i++) {
            if (extra < n && i >= extra) {
                result[i] = missedElement + 1;
            } else
                result[i] = missedElement;
        }
        return result;
    }
}