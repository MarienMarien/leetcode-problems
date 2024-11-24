public class Solution {
    public int[][] MinScore(int[][] grid) {
        var pq = new PriorityQueue<(int val, int row, int col), int>(
            Comparer<int>.Create((x, y) => { return x <= y ? -1 : 1; }));

        for (var row = 0; row < grid.Length; row++)
        {
            for (var col = 0; col < grid[0].Length; col++)
            {
                pq.Enqueue((grid[row][col], row, col), grid[row][col]);
            }
        }

        var rowsMinVals = new int[grid.Length];
        var colsMinVals = new int[grid[0].Length];

        while (pq.Count > 0)
        {
            var curr = pq.Dequeue();
            var newVal = Math.Max(Math.Max(rowsMinVals[curr.row], colsMinVals[curr.col]), 1);
                
            grid[curr.row][curr.col] = newVal;
            rowsMinVals[curr.row] = newVal + 1;
            colsMinVals[curr.col] = newVal + 1;
        }

        return grid;
    }
}