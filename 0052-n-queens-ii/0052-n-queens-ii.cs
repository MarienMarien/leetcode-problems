public class Solution {
    private ISet<int> _colsSet;
    private ISet<int> _diagonalSet;
    private ISet<int> _antidiagonalSet;
    private int _solutionsNumber;
    private int _n;

    public int TotalNQueens(int n)
    {
        _n = n;
        _colsSet = new HashSet<int>();
        _diagonalSet = new HashSet<int>();
        _antidiagonalSet = new HashSet<int>();
        _solutionsNumber = 0;
        CountSolutions(0);
        return _solutionsNumber;
    }

    private void CountSolutions(int q)
    {
        if (q == _n)
        {
            _solutionsNumber++;
            return;
        }

        for (var col = 0; col < _n; col++)
        {
            var diagonal = q - col;
            var antidiagonal = q + col;
            if (_colsSet.Contains(col) || _diagonalSet.Contains(diagonal) || _antidiagonalSet.Contains(antidiagonal))
                continue;

            _colsSet.Add(col);
            _diagonalSet.Add(diagonal);
            _antidiagonalSet.Add(antidiagonal);
            CountSolutions(q + 1);
            _colsSet.Remove(col);
            _diagonalSet.Remove(diagonal);
            _antidiagonalSet.Remove(antidiagonal);
        }
    }
}