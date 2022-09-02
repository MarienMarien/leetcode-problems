public class Solution {
    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        IList<IList<int>> res = new List<IList<int>>();

        var rows = heights.Length;
        var cols = heights[0].Length;
        var pacific = new bool[rows,cols];
        var atlantic = new bool[rows,cols];

        for (var row = 0; row < rows; row++) {
            DfsP(0, row, pacific, heights, 0, 0, 0);
            DfsP(cols - 1, row, atlantic, heights, 0, cols - 1, rows - 1);
        }

        for (var row = 0; row < rows; row++) {
            for (var col = 0; col < cols; col++) {
                if (pacific[row, col] && atlantic[row, col]) {
                    res.Add(new List<int> { row, col });
                }
            }
        }

        return res;
    }

    private void DfsP(int col, int row, bool[,] pacific, int[][] heights, int prevHeight, int colLimit, int rowLimit)
    {
        if (col < 0 || row < 0 || col >= heights[0].Length || row >= heights.Length || pacific[row, col] == true)
            return;
        if (col == colLimit || row == rowLimit || prevHeight <= heights[row][col])
        {
            pacific[row, col] = true;
            // down
            DfsP(col, row + 1, pacific, heights, heights[row][col], colLimit, rowLimit);
            // right
            DfsP(col + 1, row, pacific, heights, heights[row][col], colLimit, rowLimit);
            // top
            DfsP(col, row - 1, pacific, heights, heights[row][col], colLimit, rowLimit);
            // left
            DfsP(col - 1, row, pacific, heights, heights[row][col], colLimit, rowLimit);
        }
    }
}