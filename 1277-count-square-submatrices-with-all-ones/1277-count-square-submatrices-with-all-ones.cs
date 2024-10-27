public class Solution {
    public int CountSquares(int[][] matrix) {
        var ans = 0;
        var dp = new int[matrix.Length][];
        for (int i = 0; i < matrix.Length; i++)
        {
            dp[i] = new int[matrix[0].Length];
            for (int j = 0; j < matrix[0].Length; j++)
            {
                Array.Fill(dp[i], -1);
            }
        }
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                ans += Solve(i, j, matrix, dp);
            }
        }

        return ans;
    }

    private int Solve(int i, int j, int[][] matrix, int[][] dp)
    {
        if (i >= matrix.Length || j >= matrix[0].Length || matrix[i][j] == 0)
        {
            return 0;
        }

        if (dp[i][j] != -1)
        {
            return dp[i][j];
        }

        var right = Solve(i, j + 1, matrix, dp);
        var diagonal = Solve(i + 1, j + 1, matrix, dp);
        var below = Solve(i + 1, j, matrix, dp);

        dp[i][j] = 1 + Math.Min(right, Math.Min(diagonal, below));
        return dp[i][j];
    }
}