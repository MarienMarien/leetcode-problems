public class Solution {
    public int MaxEqualRowsAfterFlips(int[][] matrix) {
        var patterns = new Dictionary<string, int>();
        var maxNumberOfEqRows = 0;

        for(var row = 0; row < matrix.Length; row++)
        {
            var rowPattern = new StringBuilder();
            for(var col = 0; col < matrix[0].Length; col++)
            {
                if(col == 0 || matrix[row][col] == matrix[row][0])
                    rowPattern.Append('f');
                else
                    rowPattern.Append('s');
            }
            var rowPatternStr = rowPattern.ToString();
            if(!patterns.TryAdd(rowPatternStr, 1))
                patterns[rowPatternStr]++;
            maxNumberOfEqRows = Math.Max(maxNumberOfEqRows, patterns[rowPatternStr]);
        }

        return maxNumberOfEqRows;
    }
}