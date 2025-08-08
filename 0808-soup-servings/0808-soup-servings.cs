public class Solution {
    public double SoupServings(int n) {
        var initialServing = (int)Math.Ceiling(n / 25.0);
        var dp = new Dictionary<int, IDictionary<int, double>>();

        for (var i = 1; i <= initialServing; i++)
        {
            if (CalculateDP(i, i, dp) > 1 - 1e-5)
            {
                return 1.0;
            }
        }
        return CalculateDP(initialServing, initialServing, dp);
    }

    private double CalculateDP(int i, int j, IDictionary<int, IDictionary<int, double>> dp)
    {
        if (i <= 0 && j <= 0)
        {
            return 0.5;
        }
        if (i <= 0)
        {
            return 1.0;
        }
        if (j <= 0)
        {
            return 0.0;
        }
        if (dp.ContainsKey(i) && dp[i].ContainsKey(j))
        {
            return dp[i][j];
        }
        var result = (CalculateDP(i - 4, j, dp) + CalculateDP(i - 3, j - 1, dp) +CalculateDP(i - 2, j - 2, dp) + CalculateDP(i - 1, j - 3, dp)) / 4.0;
        dp.TryAdd(i, new Dictionary<int, double>());
        dp[i].Add(j, result);

        return result;
    }
}