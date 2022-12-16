public class Solution {
    public int[][] Multiply(int[][] mat1, int[][] mat2) {
        var res = new int[mat1.Length][];
        for(var row = 0; row < res.Length; row++){
            res[row] = new int[mat2[0].Length];
            for(var col = 0; col < mat2[0].Length; col++){
                for(var m2Row = 0; m2Row < mat2.Length; m2Row++){
                    res[row][col] += mat1[row][m2Row] * mat2[m2Row][col];
                }
            }
        }
        return res;
    }
}