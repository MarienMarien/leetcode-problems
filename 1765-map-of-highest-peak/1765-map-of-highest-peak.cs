public class Solution {
    public int[][] HighestPeak(int[][] isWater) {
        var m = isWater.Length;
        var n = isWater[0].Length;
        var q = new Queue<(int row, int col)>();
        var height = new int[m][];
        for (var row = 0; row < m; row++)
        {
            height[row] = new int[n];
            for (var col = 0; col < n; col++)
            {
                if (isWater[row][col] == 1)
                {
                    q.Enqueue((row, col));
                    height[row][col] = 0;
                }
                else
                {
                    height[row][col] = -1;
                }
            }
            
        }

        var levelSize = q.Count;
        var currHeight = 1;
        var directions = new int[][] { [0, 1], [1, 0], [0, -1], [-1, 0] };

        while (q.Count > 0)
        {
            var currCell = q.Dequeue();
            levelSize--;
            var currRow = currCell.row;
            var currCol = currCell.col;
            foreach (var d in directions)
            {
                var adjRow = currRow + d[0];
                var adjCol = currCol + d[1];
                if (adjRow >= 0 && adjRow < m && adjCol >= 0 && adjCol < n && height[adjRow][adjCol] == -1)
                {
                    q.Enqueue((adjRow, adjCol));
                    height[adjRow][adjCol] = currHeight;
                }
            }
            if (levelSize == 0)
            {
                levelSize = q.Count;
                currHeight++;
            }
        }

        return height;
    }
}