public class Solution {
    private int[][] _directions = new int[][] {[0, 1],[1, 0], [0, -1], [-1, 0]};
    public int NumIslands(char[][] grid) {
        var islandsCount = 0;
        for(var row = 0; row < grid.Length; row++)
        {
            for(var col = 0; col < grid[0].Length; col++)
            {
                if(grid[row][col] != '1')
                    continue;
                MarkIsland(grid, row, col);
                islandsCount++;
            }
        }

        return islandsCount;
    }

    private void MarkIsland(char[][] grid, int startRow, int startCol)
    {
        var q = new Queue<(int row, int col)>();
        q.Enqueue((startRow, startCol));
        grid[startRow][startCol] = '2';
        while(q.Count > 0)
        {
            var curr = q.Dequeue();
            foreach(var d in _directions)
            {
                var nextRow = curr.row + d[0];
                var nextCol = curr.col + d[1];
                if(nextRow < 0 || nextRow >= grid.Length || 
                    nextCol < 0 || nextCol >= grid[0].Length || grid[nextRow][nextCol] != '1')
                    continue;
                grid[nextRow][nextCol] = '2';
                q.Enqueue((nextRow, nextCol));
            }
        }
    }
}