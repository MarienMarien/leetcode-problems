public class Solution {
    public bool Exist(char[][] board, string word) {
        var boardWidth = board[0].Length;
        var boardHeigh = board.Length;
        var wordId = 0;
        for (var row = 0; row < boardHeigh; row++) {
            for (var col = 0; col < boardWidth; col++) {
                if (board[row][col] == word[wordId]) { 
                    if(SearchWordDfs(board, word, wordId, row, col))
                        return true;
                }
            }
        }
        return false;
    }

    private static bool SearchWordDfs(char[][] board, string word, int wordId, int row, int col)
    {
        if (wordId >= word.Length)
            return true;
        if (col < 0 || col >= board[0].Length || row < 0 ||row >= board.Length || board[row][col] != word[wordId] )
            return false;

        board[row][col] = '-';
        var found = SearchWordDfs(board, word, wordId + 1, row, col + 1);
        if (!found)
        {
            found = SearchWordDfs(board, word, wordId + 1, row + 1, col);
        }
        if (!found)
        {
            found = SearchWordDfs(board, word, wordId + 1, row, col - 1);
        }
        if (!found)
        {
            found = SearchWordDfs(board, word, wordId + 1, row - 1, col);
        }

        if (!found)
            board[row][col] = word[wordId];

        return found;
    }
}