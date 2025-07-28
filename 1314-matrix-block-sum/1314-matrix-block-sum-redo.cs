public class Solution {
    public int[][] MatrixBlockSum(int[][] mat, int k) {
        var rows = mat.Length;
        var cols = mat[0].Length;
        var prefSums = new int[rows, cols];
        var elSums = new int[rows][];

        for (var row = 0; row < rows; row++)
        {
            elSums[row] = new int[cols];
            for (var col = 0; col < cols; col++)
            {
                prefSums[row, col] = mat[row][col];
                if (col > 0)
                {
                    prefSums[row, col] += prefSums[row, col - 1];
                }
                if (row > 0)
                {
                    prefSums[row, col] += prefSums[row - 1, col];
                }
                if (col > 0 && row > 0)
                {
                    prefSums[row, col] -= prefSums[row - 1, col - 1];
                }
            }
        }

        for (var row = 0; row < rows; row++)
        {
            for (var col = 0; col < cols; col++)
            {
                var bottomRow = Math.Min(row + k, rows - 1);
                var rightmostCol = Math.Min(col + k, cols - 1);
                var sum = prefSums[bottomRow, rightmostCol];

                var leftmostCol = col - k;
                var topRow = row - k;

                var leftBottom = leftmostCol <= 0 ? 0 :
                    prefSums[bottomRow, leftmostCol - 1];
                var rightUp = topRow <= 0 ? 0 :
                    prefSums[topRow - 1, rightmostCol];
                var diagonal = topRow <= 0 || leftmostCol <= 0 ? 0 :
                    prefSums[topRow - 1, leftmostCol - 1];

                elSums[row][col] = sum - leftBottom - rightUp + diagonal;
            }
        }
        return elSums;
    }
}