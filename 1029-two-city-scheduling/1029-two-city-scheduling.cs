public class Solution {
    public int TwoCitySchedCost(int[][] costs) {
        Array.Sort(costs,
            Comparer<int[]>.Create((x, y) => {
                return (x[0] - x[1]) - (y[0] - y[1]);
            })
        );
        var n = costs.Length / 2;
        var sum = 0;
        for (var i = 0; i < n; i++) {
            sum += costs[i][0] + costs[i + n][1];
        }
        return sum;
    }
}