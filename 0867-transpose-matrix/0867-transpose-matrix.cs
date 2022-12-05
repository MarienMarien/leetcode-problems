public class Solution {
    public int[][] Transpose(int[][] matrix) {
        var res = new int[matrix[0].Length][];

        for(var row = 0; row < matrix.Length; row++){
            for(var col = 0; col < matrix[0].Length; col++){
                if(row == 0){
                    res[col] = new int[matrix.Length];
                }
                res[col][row] = matrix[row][col];
            }
        }
        return res;
    }
}