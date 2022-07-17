public class Solution {
    public void Rotate(int[][] matrix) {
         for (var row = 0; row <= matrix.Length / 2; row++) {
            var rowLastId = matrix.Length - 1 - row;
            var rowFirstId = row;
            var shift = 0;
            for (var col = row; col < matrix.Length - 1 - row; col++) {
                var tmp = matrix[row + shift][rowLastId];
                matrix[row + shift][rowLastId] = matrix[row][col];
                matrix[row][col] = matrix[rowLastId - shift][rowFirstId];
                matrix[rowLastId - shift][rowFirstId] = matrix[rowLastId][rowLastId - shift];
                matrix[rowLastId][rowLastId - shift] = tmp;
                shift++;
            }
        }
    }
}