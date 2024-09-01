public class Solution {
    private int _n;
    private char[][] _board;
    private ISet<int> _cols;
    private ISet<int> _diagonals;
    private ISet<int> _antiDiagonals;
    private IList<IList<string>> _solutions;
    public IList<IList<string>> SolveNQueens(int n)
    {
        _n = n;
        _cols = new HashSet<int>();
        _diagonals = new HashSet<int>();
        _antiDiagonals = new HashSet<int>();
        _solutions = new List<IList<string>>();
        _board = new char[n][];
        for (var row = 0; row < n; row++)
        {
            _board[row] = new char[n];
            for (var col = 0; col < n; col++)
            {
                _board[row][col] = '.';
            }
        }

        Backtrack(0);
        return _solutions;
    }

    private void Backtrack(int row)
    {
        if (row == _n)
        {
            _solutions.Add(GetBoardForSolution());
            return;
        }

        for (var col = 0; col < _n; col++)
        {
            var diagonal = row - col;
            var antidiagonal = row + col;
            if (_cols.Contains(col) || _diagonals.Contains(diagonal) || _antiDiagonals.Contains(antidiagonal))
            {
                continue;
            }

            _board[row][col] = 'Q';
            _cols.Add(col);
            _diagonals.Add(diagonal);
            _antiDiagonals.Add(antidiagonal);
            
            Backtrack(row + 1);

            _board[row][col] = '.';
            _cols.Remove(col);
            _diagonals.Remove(diagonal);
            _antiDiagonals.Remove(antidiagonal);
        }
    }

    private IList<string> GetBoardForSolution()
    {
        var board = new List<string>();
        foreach (var r in _board)
        {
            board.Add(new string(r));
        }

        return board;
    }
}