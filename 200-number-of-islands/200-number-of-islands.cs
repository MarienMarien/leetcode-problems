public class Solution {
    public int NumIslands(char[][] grid) {
         var islandCount = 0;
            var rows = grid.Length;
            var cols = grid[0].Length;
            for (var i = 0; i < rows; i++) {
                for (var j = 0; j < cols; j++) {
                    if (grid[i][j] == '1') {
                        islandCount++;
                        DFS(grid, rows, cols, i, j);
                    }
                }
            }
            return islandCount;
        }

        private static void DFS(char[][] grid, int rows, int cols, int i, int j) {
            if(i < 0 || i >= rows || j < 0 || j >= cols || grid[i][j] != '1')
                return;
            grid[i][j] = '0';
            DFS(grid, rows, cols, i, j + 1);
            DFS(grid, rows, cols, i, j - 1);
            DFS(grid, rows, cols, i + 1, j);
            DFS(grid, rows, cols, i - 1, j);
        }
}