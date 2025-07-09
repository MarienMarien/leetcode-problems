public class Solution {
    public void Rotate(int[][] matrix) {
        var n = matrix.Length;
        for(var row = 0; row < n; row++)
        {
            for(var col = row + 1; col < n; col++)
            {
                var tmp = matrix[row][col];
                matrix[row][col] = matrix[col][row];
                matrix[col][row] = tmp;
            }
        }

        for(var row = 0; row < n; row++)
        {
            var lastId = n - 1;
            for(var col = 0; col < n / 2; col++)
            {
                var tmp = matrix[row][col];
                matrix[row][col] = matrix[row][lastId - col];
                matrix[row][lastId - col] = tmp;
            }
        }
    }
}