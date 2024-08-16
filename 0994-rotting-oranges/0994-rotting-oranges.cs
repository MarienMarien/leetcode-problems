public class Solution {
    public int OrangesRotting(int[][] grid) {
        var q = new Queue<(int row, int col)>();
        var minMinutes = 0;
        var goodOrangesCount = 0;
        int[][] neighbours =
        {
            new int[] { 0, 1 },
            new int[] { 0, -1 },
            new int[] { 1, 0 },
            new int[] { -1, 0 }
        };

        for (var row = 0; row < grid.Length; row++)
        {
            for (var col = 0; col < grid[0].Length; col++)
            {
                if (grid[row][col] == 2)
                    q.Enqueue((row, col));
                else if (grid[row][col] == 1)
                    goodOrangesCount++;
            }
        }

        var layerSize = q.Count;

        while (q.Count > 0)
        {
            var curr = q.Dequeue();
            layerSize--;

            foreach (var n in neighbours)
            {
                var currRow = curr.row + n[0];
                var currCol = curr.col + n[1];
                if (currRow < 0 || currRow >= grid.Length || currCol < 0 || currCol >= grid[0].Length)
                    continue;
                if (grid[currRow][currCol] == 1)
                {
                    grid[currRow][currCol] = 2;
                    goodOrangesCount--;
                    q.Enqueue((currRow, currCol));
                }
            }

            if (layerSize == 0)
            {
                if(q.Count > 0)
                    minMinutes++;
                layerSize = q.Count;
            }
        }

        return goodOrangesCount > 0 ? -1 : minMinutes;
    }
}