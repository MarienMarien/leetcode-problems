public class Solution {
    public void SetZeroes(int[][] matrix) {
        var isColZero = false;
        var isRowZero = false;
        for (var row = 0; row < matrix.Length; row++) {
            for (var col = 0; col < matrix[0].Length; col++) {
                if (row == 0 && matrix[row][col] == 0)
                {
                    isRowZero = true;
                    continue;
                }
                if (col == 0 && matrix[row][col] == 0)
                {
                    isColZero = true;
                    continue;
                }
                if (matrix[row][col] == 0) {
                    matrix[0][col] = 0;
                    matrix[row][0] = 0;
                }
            }
        }

        for (var row = matrix.Length - 1; row >= 0; row--)
        {
            for (var col = matrix[0].Length - 1; col >= 0; col--)
            {
                if (matrix[0][col] == 0 || matrix[row][0] == 0)
                    matrix[row][col] = 0;
                if((col == 0 && isColZero) || (row == 0 && isRowZero))
                    matrix[row][col] = 0;
            }
        }
    }
}