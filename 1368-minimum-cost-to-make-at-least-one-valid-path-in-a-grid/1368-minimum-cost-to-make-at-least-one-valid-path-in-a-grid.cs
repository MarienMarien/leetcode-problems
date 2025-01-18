public class Solution {
    public int MinCost(int[][] grid) {
        var adj = new int[][] { [0, 1], [0, -1], [1, 0], [-1, 0] };
        var n = grid.Length;
        var m = grid[0].Length;

        var minCost = new int[n][];
        for(var i = 0; i < minCost.Length; i++)
        {
            minCost[i] = new int[m];
            Array.Fill(minCost[i], Int32.MaxValue);
        }

        var q = new LinkedList<(int row, int col)>();
        q.AddFirst((0, 0));
        minCost[0][0] = 0;

        while (q.Count > 0)
        {
            var curr = q.First.Value;
            q.RemoveFirst();
            var row = curr.row;
            var col = curr.col;

            for (var d = 0; d < 4; d++)
            {
                var newRow = row + adj[d][0];
                var newCol = col + adj[d][1];
                var cost = (grid[row][col] != (d + 1)) ? 1 : 0;

                if (newRow >= 0 && newRow < n && newCol >= 0 && newCol < m 
                    && minCost[row][col] + cost < minCost[newRow][newCol])
                {
                    minCost[newRow][newCol] = minCost[row][col] + cost;

                    if (cost == 1)
                    {
                        q.AddLast((newRow, newCol));
                    }
                    else
                    {
                        q.AddFirst((newRow, newCol));
                    }
                }
            }
        }

        return minCost[n - 1][m - 1];
    }
}