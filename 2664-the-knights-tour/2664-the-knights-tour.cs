public class Solution {
    private int[][] _moves = { 
        [-2, 1], [-1, 2], [1, 2], [2, 1],
        [2, -1], [1, -2], [-1, -2], [-2, -1]
    };
    private int _totalCells;

    private int[][] _board;

    public int[][] TourOfKnight(int m, int n, int r, int c)
    {
        _totalCells = m * n;
        _board = new int[m][];
        for (var i = 0; i < m; i++)
        {
            var row = new int[n];
            Array.Fill(row, -1);
            _board[i] = row;
        }

        var cellsProcessed = 0;

        BuildBoard(r, c, cellsProcessed);

        return _board;
    }

    private bool BuildBoard(int r, int c, int cellsProcessed)
    {
        if (r < 0 || r >= _board.Length || c < 0 || c >= _board[0].Length 
            || _board[r][c] != -1)
            return false;

        _board[r][c] = cellsProcessed;
        cellsProcessed++;

        if (cellsProcessed == _totalCells)
            return true;

        var canProcess = false;
        foreach (var move in _moves)
        {
            var nextRow = r + move[0];
            var nextCol = c + move[1];
            
            canProcess = BuildBoard(nextRow, nextCol, cellsProcessed);
            if (canProcess)
                break;
        }

        if (!canProcess)
        {
            _board[r][c] = -1;
            cellsProcessed--;
        }

        return canProcess;
    }
}