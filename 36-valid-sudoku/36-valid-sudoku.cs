public class Solution {
    public bool IsValidSudoku(char[][] board) {
        var rowsSet = new Dictionary<int, HashSet<char>>();
            var colsSet = new Dictionary<int, HashSet<char>>();
            var squaresSet = new Dictionary<int, HashSet<char>>();

            for (var row = 0; row < board.Length; row++) {
                for (var col = 0; col < board[0].Length; col++) {
                    var el = board[row][col];
                    if (!Char.IsDigit(el))
                        continue;
                    // row check
                    if (!rowsSet.ContainsKey(row))
                        rowsSet.Add(row, new HashSet<char>());
                    if (rowsSet[row].Contains(el)) {
                        return false;
                    }
                    rowsSet[row].Add(el);

                    // col check
                    if (!colsSet.ContainsKey(col))
                        colsSet.Add(col, new HashSet<char>());
                    if (colsSet[col].Contains(el))
                    {
                        return false;
                    }
                    colsSet[col].Add(el);

                    // sq check
                    var sqNumber = (row / 3) * 3 + (col / 3);
                    if (!squaresSet.ContainsKey(sqNumber))
                        squaresSet.Add(sqNumber, new HashSet<char>());
                    if (squaresSet[sqNumber].Contains(el))
                    {
                        return false;
                    }
                    squaresSet[sqNumber].Add(el);

                }
            }
            return true;
    }
}