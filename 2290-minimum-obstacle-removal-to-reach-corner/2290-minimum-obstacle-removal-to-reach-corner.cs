public class Solution {
    public int MinimumObstacles(int[][] grid) {
        var gridRows = grid.Length;
        var gridCols = grid[0].Length;
        var directions = new int[][] { [0, 1], [1, 0], [0, -1], [-1, 0] };
        var pq = new PriorityQueue<(int row, int col, int obstaclesRem), int>();
        pq.Enqueue((0, 0, grid[0][0]), grid[0][0]);
        var currCell = pq.Peek();

        while (pq.Count > 0)
        {
            currCell = pq.Dequeue();
            if(grid[currCell.row][currCell.col] > 1)
                continue;
            grid[currCell.row][currCell.col] += 2;
            foreach (var dir in directions)
            {
                var nextRow = currCell.row + dir[0];
                var nextCol = currCell.col + dir[1];
                
                if (nextRow < 0 || nextRow >= gridRows
                    || nextCol < 0 || nextCol >= gridCols)
                    continue;
                var obstacleToRem = currCell.obstaclesRem + grid[nextRow][nextCol];
                if (nextRow == gridRows - 1 && nextCol == gridCols - 1)
                {
                    return obstacleToRem;
                }
                pq.Enqueue((nextRow, nextCol, obstacleToRem), obstacleToRem);
            }
        }

        return 0;
    }
}