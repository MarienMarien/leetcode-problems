public class Solution {
    private int[,] _preCount;
    private int _rows;
    private int _cols;
    private const int MOD = 1_000_000_007;
    public int Ways(string[] pizza, int k)
    {
        _rows = pizza.Length;
        _cols = pizza[0].Length;
        _preCount = new int[_rows + 1, _cols + 1];
        for (var row = _rows - 1; row >= 0; row--)
            for (var col = _cols - 1; col >= 0; col--)
            {
                _preCount[row, col] = _preCount[row, col + 1] + _preCount[row + 1, col] - _preCount[row + 1, col + 1];
                if (pizza[row][col] == 'A')
                    _preCount[row, col]++;
            }
        return Dfs(k - 1, 0, 0, new Dictionary<string, int>());
    }

    private int Dfs(int k, int r, int c, Dictionary<string, int> memo)
    {
        if (_preCount[r, c] == 0) 
            return 0;
        if (k == 0) 
            return 1;
        var key = k + ":" + r + ":" + c;
        if (memo.ContainsKey(key)) 
            return memo[key];

        long res = 0;
        for (var row = r + 1; row < _rows; row++)
            if (_preCount[r, c] - _preCount[row, c] > 0)
                res += Dfs(k - 1, row, c, memo);

        for (var col = c + 1; col < _cols; col++)
            if (_preCount[r, c] - _preCount[r, col] > 0)
                res += Dfs(k - 1, r, col, memo);

        return memo[key] = (int)(res % MOD);
    }
}