public class Solution {
    public int[] FindDiagonalOrder(int[][] mat) {
        var colsCount = mat[0].Length;
        var rowsCount = mat.Length;
        var totalElementsCount = colsCount * rowsCount;
        var res = new int[totalElementsCount];
        var resId = 0;
        var col = 0;
        var row = 0;
        while (resId < totalElementsCount) {
            // up
            while (row >= 0 && col < colsCount)
            {
                res[resId] = mat[row][col];
                row--;
                col++;
                resId++;
            }
            row++;
            if (col >= colsCount)
            {
                col--;
                row++;
            }
            // down
            while (row < rowsCount && col >= 0)
            {
                res[resId] = mat[row][col];
                row++;
                col--;
                resId++;
            }
            col++;
            if (row >= rowsCount)
            {
                row--;
                col++;
            }
        }
        return res;
    }
}