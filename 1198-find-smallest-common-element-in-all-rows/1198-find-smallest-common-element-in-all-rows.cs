public class Solution {
    public int SmallestCommonElement(int[][] mat) {
        var set = new Dictionary<int, int>();
        var lastRow = mat.Length - 1;
        for (var row = 0; row < mat.Length; row++) {
            for (var col = 0; col < mat[0].Length; col++) {
                if (col > 0 && mat[row][col] == mat[row][col - 1])
                    continue;
                if (set.ContainsKey(mat[row][col]))
                {
                    if (set[mat[row][col]] == lastRow - 1)
                        return mat[row][col];
                    set[mat[row][col]]++;
                }
                else if (row == 0){
                    set.Add(mat[row][col], 0);
                }
            }
        }
        return -1;
    }
}