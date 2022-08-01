public class Solution {
    public int[][] CandyCrush(int[][] board) {
         var hasCrush = true;
        var rowsCount = board.Length;
        var colsCount = board[0].Length;
        while (hasCrush) {
            hasCrush = false;
            for (var row = 0; row < rowsCount; row++) {
                for (var col = 0; col < colsCount; col++) {
                    var curr = Math.Abs(board[row][col]);
                    if (curr == 0)
                        continue;
                    if (col < colsCount - 2 && Math.Abs(board[row][col + 1]) == curr && Math.Abs(board[row][col + 2]) == curr) { 
                        hasCrush = true;
                        var id = col;
                        while (id < colsCount && Math.Abs(board[row][id]) == curr)
                        {
                            board[row][id] = -curr;
                            id++;
                        }
                    }
                    if (row < rowsCount - 2 && Math.Abs(board[row + 1][col]) == curr && Math.Abs(board[row + 2][col]) == curr) { 
                        hasCrush=true;
                        var id = row;
                        while (id < rowsCount && Math.Abs(board[id][col]) == curr) {
                            board[id][col] = -curr;
                            id++;
                        }
                    }
                }
            }
            if (hasCrush) {
                ApplyGravity(board);
            }
        }
        return board;
    }

    private void ApplyGravity(int[][] board)
    {
        for (var col = 0; col < board[0].Length; col++) {
            var lastCrushedIdx = board.Length - 1;
            for (var row = board.Length - 1; row >= 0; row--)
            {
                if (board[row][col] > 0)
                {
                    board[lastCrushedIdx][col] = board[row][col];
                    if(lastCrushedIdx != row)
                        board[row][col] = 0;
                    lastCrushedIdx--;
                }
                else
                {
                    board[row][col] = 0;
                }
            }

        }
    }
}