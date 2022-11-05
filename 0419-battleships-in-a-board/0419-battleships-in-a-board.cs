public class Solution {
    public int CountBattleships(char[][] board) {
        var count = 0;
        for (var row = 0; row < board.Length; row++) {
            for (var col = 0; col < board[0].Length; col++) {
                if (board[row][col] == 'X')
                {
                    count++;
                    DeMarkShip(board, row, col);
                }
            }
        }
        return count;
    }

    private void DeMarkShip(char[][] board, int row, int col)
    {
        if (col < board[0].Length - 1 && board[row][col + 1] == 'X') {
            while (col < board[0].Length && board[row][col] == 'X')
            {
                board[row][col] = '.';
                col++;
            }
            return;
        }
        if (row < board.Length - 1 && board[row + 1][col] == 'X')
        {
            while (row < board.Length && board[row][col] == 'X')
            {
                board[row][col] = '.';
                row++;
            }
            return;
        }
    }
}