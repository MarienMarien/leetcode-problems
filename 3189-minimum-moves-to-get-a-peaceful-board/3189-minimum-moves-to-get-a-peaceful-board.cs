public class Solution {
    public int MinMoves(int[][] rooks) {
        Array.Sort(rooks, Comparer<int[]>.Create((x, y) => x[0] - y[0]));
        var movesCount = 0;

        for (var i = 0; i < rooks.Length; i++)
        {
            movesCount += Math.Abs(rooks[i][0] - i);
        }

        Array.Sort(rooks, Comparer<int[]>.Create((x, y) => x[1] - y[1]));

        for (var i = 0; i < rooks.Length; i++)
        {
            movesCount += Math.Abs(rooks[i][1] - i);
        }

        return movesCount;
    }
}