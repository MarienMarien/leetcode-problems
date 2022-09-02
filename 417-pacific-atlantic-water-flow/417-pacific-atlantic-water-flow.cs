public class Solution {
    public IList<IList<int>> PacificAtlantic(int[][] heights) {
        IList<IList<int>> res = new List<IList<int>>();
        var rows = heights.Length;
        var cols = heights[0].Length;
        var pacific = new bool[rows,cols];
        var atlantic = new bool[rows,cols];

        for (var row = 0; row < rows; row++) {
            DfsP(0, row, pacific, heights, 0);
            DfsA(cols - 1, row, atlantic, heights, 0);
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

    private void DfsP(int col, int row, bool[,] pacific, int[][] heights, int prevHeight)
    {
        if (col < 0 || row < 0 || col >= heights[0].Length || row >= heights.Length || pacific[row, col] == true)
            return;
        if (col == 0 || row == 0 || prevHeight <= heights[row][col])
        {
            pacific[row, col] = true;
            // down
            DfsP(col, row + 1, pacific, heights, heights[row][col]);
            // right
            DfsP(col + 1, row, pacific, heights, heights[row][col]);
            // top
            DfsP(col, row - 1, pacific, heights, heights[row][col]);
            // left
            DfsP(col - 1, row, pacific, heights, heights[row][col]);
        }

    }

    private void DfsA(int col, int row, bool[,] atlantic, int[][] heights, int prevHeight)
    {
        if (col < 0 || row < 0 || col >= heights[0].Length || row >= heights.Length || atlantic[row, col] == true)
            return;
        if (col == heights[0].Length - 1 || row == heights.Length - 1 || prevHeight <= heights[row][col])
        {
            atlantic[row, col] = true;
            // down
            DfsA(col, row + 1, atlantic, heights, heights[row][col]);
            // left
            DfsA(col - 1, row, atlantic, heights, heights[row][col]);
            // top
            DfsA(col, row - 1, atlantic, heights, heights[row][col]);
            // right
            DfsA(col + 1, row, atlantic, heights, heights[row][col]);
        }
    }
}