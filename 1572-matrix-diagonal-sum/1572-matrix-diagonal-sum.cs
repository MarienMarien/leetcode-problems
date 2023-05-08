public class Solution {
    public int DiagonalSum(int[][] mat) {
        int lastCol = mat[0].Length - 1;
        int sum = 0;
        int row = 0;
        for (int col = 0; col < mat[0].Length; col++) {
            int col1 = lastCol - col;
            sum += mat[row][col];
            if (col1 != col) {
                sum += mat[row][col1];
            }
            row++;
        }
        return sum;
    }
}