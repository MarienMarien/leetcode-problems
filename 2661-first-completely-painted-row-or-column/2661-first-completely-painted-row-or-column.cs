public class Solution {
    public int FirstCompleteIndex(int[] arr, int[][] mat) {
        var m = mat.Length;
        var n = mat[0].Length;
        var paintedRows = new Dictionary<int, int>();
        var paintedCols = new Dictionary<int, int>();
        var matElements = new Dictionary<int, (int row, int col)>();

        for (var row = 0; row < m; row++)
        {
            for (var col = 0; col < n; col++)
            {
                matElements.Add(mat[row][col], (row, col));
            }
        }

        var i = 0;
        for(; i < arr.Length; i++)
        {
            var curr = matElements[arr[i]];
            if (!paintedRows.TryAdd(curr.row, 1))
                paintedRows[curr.row]++;
            if (paintedRows[curr.row] == n)
                break;
            if (!paintedCols.TryAdd(curr.col, 1))
                paintedCols[curr.col]++;
            if (paintedCols[curr.col] == m)
                break;
        }

        return i;
    }
}