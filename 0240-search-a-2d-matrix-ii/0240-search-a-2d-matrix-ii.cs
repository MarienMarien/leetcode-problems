public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        var rows = matrix.Length;
        var row = 0;
        var col = matrix[0].Length - 1;
        while (row < rows & col >= 0) {
            if (matrix[row][col] == target)
                return true;
            if (matrix[row][col] > target)
            {
                col--;
            }
            else {
                row++;
            }
        }
        return false;
    }
}