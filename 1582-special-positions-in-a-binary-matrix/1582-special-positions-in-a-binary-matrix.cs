public class Solution {
    public int NumSpecial(int[][] mat) {
        var specRows = new Dictionary<int, int>();
        var specCols = new Dictionary<int, int>();
        var count = 0;
        for(var row = 0; row < mat.Length; row++){
            for(var col = 0; col < mat[0].Length; col++){
                if(mat[row][col] == 1){
                    count += IsOnly(mat, row, col)? 1 : 0;
                }
            }
        }
        return count;
    }

    private bool IsOnly(int[][]mat, int row, int col) {
        for(var i = 0; i < mat[0].Length; i++){
            if(i == col)
                continue;
            if(mat[row][i] == 1)
                return false;
        }
        for(var i = 0; i < mat.Length; i++) {
            if(i == row)
                continue;
            if(mat[i][col] == 1)
                return false;
        }
        return true;
    }
}