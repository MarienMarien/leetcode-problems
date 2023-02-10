public class Solution {
    public int MaxDistance(int[][] grid) {
        if (grid == null || grid.Length == 0)
        {
            return 0;
        }

        var res = -1;
        var queue = new Queue<int[]>();
        var rows = grid.Length;
        var cols = grid[0].Length;
        var visited = new bool[rows, cols];
        int[][] direction = 
        {
            new int[] { 0, 1 },
            new int[] { 0, -1 },
            new int[] { 1, 0 },
            new int[] { -1, 0 }
        };

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                if (grid[i][j] == 1)
                {
                    queue.Enqueue(new int[] { i, j });
                }
            }
        }

        while (queue.Count > 0)
        {
            var count = queue.Count;
            res++;
            while (count > 0)
            {
                var current = queue.Dequeue();
                for (var d = 0; d < direction.Length; d++)
                {
                    var nextRow = current[0] + direction[d][0];
                    var nextColumn = current[1] + direction[d][1];
                    if (nextRow > -1 && nextRow < rows && nextColumn > -1 && nextColumn < cols && !visited[nextRow, nextColumn] && grid[nextRow][nextColumn] == 0)
                    {
                        queue.Enqueue(new int[] { nextRow, nextColumn });
                        visited[nextRow, nextColumn] = true;
                    }
                }
                count--;
            }
        }
        return res == 0 ? -1 : res;
    }
}