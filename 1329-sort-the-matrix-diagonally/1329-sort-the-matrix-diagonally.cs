public class Solution {
    public int[][] DiagonalSort(int[][] mat) {
       var matWidth = mat[0].Length;
        var matHeight = mat.Length;
        int row = 0;
        int col;
        for (col = matWidth - 2; col >= 0; col--) {
            var diagonal = new List<int>();
            var currRow = row;
            for (var currcol = col; currcol < matWidth && currRow < matHeight; currcol++) {
                diagonal.Add(mat[currRow][currcol]);
                currRow++;
            }
            diagonal.Sort();
            var i = 0;
            currRow = row;
            for (var currcol = col; currcol < matWidth && currRow < matHeight; currcol++)
            {
                mat[currRow][currcol] = diagonal[i++];
                currRow++;
            }
        }
        col = 0;
        for (row = 1; row < matHeight - 1; row++) {
            var diagonal = new List<int>();
            var currRow = row;
            for (var currcol = col; currcol < matWidth && currRow < matHeight; currcol++)
            {
                diagonal.Add(mat[currRow][currcol]);
                currRow++;
            }
            diagonal.Sort();
            var i = 0;
            currRow = row;
            for (var currcol = col; currcol < matWidth && currRow < matHeight; currcol++)
            {
                mat[currRow][currcol] = diagonal[i++];
                currRow++;
            }
        }
        return mat;
    }
}