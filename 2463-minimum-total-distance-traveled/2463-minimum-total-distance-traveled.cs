public class Solution {
    public long MinimumTotalDistance(IList<int> robot, int[][] factory) {
        robot = robot.Order().ToList();
        Array.Sort(factory, Comparer<int[]>.Create((x, y) => x[0] - y[0]));

        var factoryPositions = new List<int>();
        foreach (var f in factory)
        {
            for (var i = 0; i < f[1]; i++)
            {
                factoryPositions.Add(f[0]);
            }
        }

        var robotCount = robot.Count();
        var factoryCount = factoryPositions.Count();
        var dp = new long[robotCount + 1,factoryCount + 1];

        for (var i = 0; i < robotCount; i++)
        {
            dp[i,factoryCount] = (long)1e12;
        }

        for (var i = robotCount - 1; i >= 0; i--)
        {
            for (var j = factoryCount - 1; j >= 0; j--)
            {
                long assign = Math.Abs(robot[i] - factoryPositions[j]) + dp[i + 1,j + 1];
                long skip = dp[i,j + 1];
                dp[i,j] = Math.Min(assign, skip);
            }
        }

        return dp[0,0];
    }
}