public class Solution {
    public bool FindSafeWalk(IList<IList<int>> grid, int health) {
        var m = grid.Count;
        var n = grid[0].Count;
        var pq = new PriorityQueue<(int row, int col, int healthSpent), int>();
        pq.Enqueue((0, 0, grid[0][0]), grid[0][0]);
        var directions = new int[][] { [0, 1], [1, 0] , [0, -1], [-1, 0] };
        var visited = new Dictionary<int, int>();
        visited.Add(0, grid[0][0]);

        while(pq.Count > 0)
        {
            var currCell = pq.Dequeue();
            var currRow = currCell.row;
            var currCol = currCell.col;
            var healthSpent = currCell.healthSpent;
            if(currRow == m - 1 && currCol == n - 1)
                return true;
            foreach(var d in directions)
            {
                var newRow = currRow + d[0];
                var newCol = currCol + d[1];
                if(newRow < 0 || newRow >= m || newCol < 0 || newCol >= n)
                    continue;
                var newHealthSpent = healthSpent + grid[newRow][newCol];
                if(newHealthSpent >= health)
                    continue;
                var cellKey = newRow * n + newCol;
                if(visited.ContainsKey(cellKey) && visited[cellKey] <= newHealthSpent)
                    continue;
                visited[cellKey] = newHealthSpent;
                pq.Enqueue((newRow, newCol, newHealthSpent), newHealthSpent);
            }
        }

        return false;
    }
}