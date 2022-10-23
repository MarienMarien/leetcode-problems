public class Solution {
    public void Solve(char[][] board) {
        // process rows (0 and last)
        var m = 0;
        while (m < board.Length) {
            for (var col = 0; col < board[0].Length; col++) {
                if(board[m][col] == 'O')
                    TryFlip(board, m, col);
            }
            if (m == board.Length - 1)
                break;
            m += board.Length - 1;
        }

        // process rows (0 and last)
        var n = 0;
        while (n < board[0].Length)
        {
            for (var row = 0; row < board.Length; row++)
            {
                if (board[row][n] == 'O')
                    TryFlip(board, row, n);
            }
            if (n == board[0].Length - 1)
                break;
            n += board[0].Length - 1;
        }

        for (var row = 0; row < board.Length; row++)
        {
            for (var col = 0; col < board[0].Length; col++)
            {
                if (board[row][col] == 'n')
                {
                    board[row][col] = 'O';
                } else if (board[row][col] == 'O')
                {
                    board[row][col] = 'X';
                }
            }
        }
    }

    private void TryFlip(char[][] board, int row, int col)
    {
        if (row < 0 || row >= board.Length || col < 0 || col >= board[0].Length || board[row][col] == 'X' || board[row][col] == 'n')
            return;
        board[row][col] = 'n';
        TryFlip(board, row, col + 1);
        TryFlip(board, row + 1, col);
        TryFlip(board, row, col - 1);
        TryFlip(board, row - 1, col);
    }
}