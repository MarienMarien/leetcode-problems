public class Solution {
    public int[] MissingRolls(int[] rolls, int mean, int n) {
        var totalObservations = rolls.Length + n;
        var rollsSum = rolls.Sum();

        var missingSum = mean * totalObservations - rollsSum;
        var possibleMissingVal = missingSum / n;
        var extra = missingSum % n;
        if(missingSum < n || missingSum > 6 * n)
            return Array.Empty<int>();

        var missing = new int[n];
        for (var i = 0; i < n; i++)
        {
            missing[i] = possibleMissingVal;
            if(i < extra)
                missing[i] += 1;
        }

        return missing;
    }
}