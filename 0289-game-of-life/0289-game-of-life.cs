public class Solution {
    public void GameOfLife(int[][] board) {
        var changed = new Dictionary<int, HashSet<int>>();
        for (var row = 0; row < board.Length; row++) {
            for (var col = 0; col < board[0].Length; col++) {
                var live = CountNeighbours(board, row, col, changed);
                switch (live) {
                    case 0:
                    case 1:
                        if (board[row][col] == 1) {
                            board[row][col] = 0;
                            if(!changed.ContainsKey(row))
                                changed.Add(row, new HashSet<int>());
                            changed[row].Add(col);
                        }
                        break;
                    case 2:
                        break;
                    case 3:
                        if (board[row][col] == 0)
                        {
                            board[row][col] = 1;
                            if (!changed.ContainsKey(row))
                                changed.Add(row, new HashSet<int>());
                            changed[row].Add(col);
                        }
                        break;
                    // if  live > 3
                    default:
                        if (board[row][col] == 1)
                        {
                            board[row][col] = 0;
                            if (!changed.ContainsKey(row))
                                changed.Add(row, new HashSet<int>());
                            changed[row].Add(col);
                        }
                        break;
                }
            }
        }
    }

    private static int CountNeighbours(int[][] board, int row, int col, Dictionary<int, HashSet<int>> changed)
    {
        var live = 0;
        for (var i = row - 1; i <= row + 1; i++) {
            if (i < 0 || i >= board.Length)
                continue;
            for (var j = col - 1; j <= col + 1; j++) {
                if (j < 0 || j >= board[0].Length || (i == row && j == col))
                    continue;
                var hasChanged = changed.ContainsKey(i) && changed[i].Contains(j);
                if ((board[i][j] == 1 && !hasChanged) || (board[i][j] == 0 && hasChanged))
                    live++;
            }
        }
        return live;
    }
}