public class Solution {
    ISet<int> colSet = new HashSet<int>();
    ISet<int> rowSet = new HashSet<int>();
    public void SetZeroes(int[][] matrix) {
        for (var row = 0; row < matrix.Length; row++)
        {
            for (var col = 0; col < matrix[0].Length; col++)
            {
                if (!rowSet.Contains(row) && !colSet.Contains(col) && matrix[row][col] == 0)
                {
                    rowSet.Add(row);
                    colSet.Add(col);
                    ProcessZeroEncounterCol(matrix, col);// rem row
                    ProcessZeroEncounterRow(matrix, row);// rem col
                }
            }
        }
    }
    
    private void ProcessZeroEncounterCol(int[][] matrix, int zeroCol)
    {
        for (var row = 0; row < matrix.Length; row++) {
            if (!rowSet.Contains(row) && matrix[row][zeroCol] == 0) {
                rowSet.Add(row);
                ProcessZeroEncounterRow(matrix, row);
            }
            matrix[row][zeroCol] = 0;
        }
    }

    private void ProcessZeroEncounterRow(int[][] matrix, int zeroRow)
    {
        for (var col = 0; col < matrix[0].Length; col++) {
            if (!colSet.Contains(col) && matrix[zeroRow][col] == 0) {
                colSet.Add(col);
                ProcessZeroEncounterCol(matrix, col);
            }
            matrix[zeroRow][col] = 0;
        }
    }
}