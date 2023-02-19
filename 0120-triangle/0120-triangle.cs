public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        var dp = new List<int>(triangle[^1]);
        for(var i = triangle.Count - 2; i >= 0; i--) {
            for(var j = 0; j < triangle[i].Count; j++){
                dp[j] = Math.Min(triangle[i][j] + dp[j], triangle[i][j] + dp[j + 1]);
            }
        }
        return dp[0];
    }
}