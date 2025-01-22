public class Solution {
    private IDictionary<int, int> _adjMap;
    private int[][] _directions = { [0, 1], [1, 0], [0, -1], [-1, 0] };
    private int _m;
    private int _n;
    private ISet<int> _visited;

    public long SumRemoteness(int[][] grid)
    {
        _m = grid.Length;
        _n = grid[0].Length;
        _visited = new HashSet<int>();
        _adjMap = new Dictionary<int, int>();
        var totalSum = 0L;
        var setSums = new Dictionary<int, long>();

        for (var row = 0; row < _m; row++)
        {
            for (var col = 0; col < _n; col++)
            {
                var key = _n * row + col;
                if (grid[row][col] == -1 || _visited.Contains(key))
                    continue;
                
                _adjMap.Add(key, 0);
                var sum = GetAdjSum(grid, row, col, key, 0);
                setSums.Add(key, sum);
                totalSum += sum;
            }
        }

        var remotenessSum = 0L;

        foreach (var subSet in _adjMap)
        {
            remotenessSum += subSet.Value * (totalSum - setSums[subSet.Key]);
        }

        return remotenessSum;
    }

    private long GetAdjSum(int[][] grid, int row, int col, int groupKey, long sum)
    {
        var key = _n * row + col;
        if (row < 0 || row >= _m || col < 0 || col >= _n || _visited.Contains(key) || grid[row][col] == -1)
            return sum;

        sum += grid[row][col];
        _visited.Add(key);
        _adjMap[groupKey]++;

        foreach (var d in _directions)
        {
            var nextRow = row + d[0];
            var nextCol = col + d[1];
            sum = GetAdjSum(grid, nextRow, nextCol, groupKey, sum);
        }
        
        return sum;
    }
}