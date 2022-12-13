public class Solution {
    public int MinFallingPathSum(int[][] matrix) {
        if(matrix.Length == 1)
            return matrix[0][0];
        var rowsLen = matrix.Length;
        var colsLen = matrix[0].Length;
        for (var row = 1; row < rowsLen - 1; row++) {
            for (var col = 0; col < colsLen; col++) {
                var currMin = Int32.MaxValue;
                if (col > 0) {
                    currMin = Math.Min(currMin, matrix[row][col] + matrix[row - 1][col - 1]);
                }
                currMin = Math.Min(currMin, matrix[row][col] + matrix[row - 1][col]);
                if (col < colsLen - 1) {
                    currMin = Math.Min(currMin, matrix[row][col] + matrix[row - 1][col + 1]);
                }
                matrix[row][col] = currMin;
            }
        }
        var minSum = Int32.MaxValue;
        for (var col = 0; col < colsLen; col++)
        {
            var currMin = Int32.MaxValue;
            if (col > 0)
            {
                currMin = Math.Min(currMin, matrix[rowsLen - 1][col] + matrix[rowsLen - 1 - 1][col - 1]);
            }
            currMin = Math.Min(currMin, matrix[rowsLen - 1][col] + matrix[rowsLen - 1 - 1][col]);
            if (col < colsLen - 1)
            {
                currMin = Math.Min(currMin, matrix[rowsLen - 1][col] + matrix[rowsLen - 1 - 1][col + 1]);
            }
            minSum = Math.Min(minSum, currMin);
        }
        return minSum;
    }
}