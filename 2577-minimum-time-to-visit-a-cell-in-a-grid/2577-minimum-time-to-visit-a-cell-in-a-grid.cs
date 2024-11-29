public class Solution {
    public int MinimumTime(int[][] grid) {
        if (grid[0][1] > 1 && grid[1][0] > 1)
            return -1;

        var gridRows = grid.Length;
        var gridCols = grid[0].Length;
        var directions = new int[][] { [0, 1], [1, 0], [0, -1], [-1, 0] };
        var pq = new PriorityQueue<(int row, int col, int time), int>();
        pq.Enqueue((0, 0, 0), 0);
        var visited = new bool[gridRows, gridCols];

        while (pq.Count > 0)
        {
            var curr = pq.Dequeue();
            if (curr.row == gridRows - 1 && curr.col == gridCols - 1)
                return curr.time;
            if (visited[curr.row, curr.col])
                continue;
            visited[curr.row, curr.col] = true;
            foreach (var d in directions)
            {
                var nextRow = curr.row + d[0];
                var nextCol = curr.col + d[1];
                if (nextRow < 0 || nextRow >= gridRows || nextCol < 0 || nextCol >= gridCols
                    || visited[nextRow, nextCol])
                    continue;
                var waitTime = (grid[nextRow][nextCol] - curr.time) % 2 == 0 ? 1 : 0;
                var nextTime = Math.Max(curr.time + 1, grid[nextRow][nextCol] + waitTime);
                pq.Enqueue((nextRow, nextCol, nextTime), nextTime);
            }
        }

        return -1;
    }
}