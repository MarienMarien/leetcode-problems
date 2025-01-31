public class Solution {
    private int[][] _directions = { [0, 1], [1, 0], [0, -1], [-1, 0] };
    private IDictionary<int, ISet<int>> _zeroToIslands;
    private int _m;
    private int _n;
    public int LargestIsland(int[][] grid)
    {
        _m = grid.Length;
        _n = grid[0].Length;
        _zeroToIslands = new Dictionary<int, ISet<int>>();
        var islandNo = 0;
        var islandsSize = new Dictionary<int, int>();
        var maxIsland = 0;
        Console.Write($"Islands: ");
        for (var row = 0; row < _m; row++)
        {
            for (var col = 0; col < _n; col++)
            {
                if (grid[row][col] > 0)
                {
                    var islandSize = GetIslandSize(grid, row, col, islandNo);
                    islandsSize.Add(islandNo, islandSize);
                    maxIsland = Math.Max(maxIsland, islandSize);
                    islandNo++;
                    Console.Write($"{islandSize}, ");
                }
            }
        }

        foreach (var closeIslands in _zeroToIslands)
        {
            if (closeIslands.Value.Count < 2)
                continue;
            var mergedIslandSize = 0;
            foreach (var island in closeIslands.Value)
            {
                mergedIslandSize += islandsSize[island];
            }
            maxIsland = Math.Max(maxIsland, mergedIslandSize);
        }

        maxIsland = Math.Min(_n * _m, maxIsland + 1);
        return maxIsland;
    }

    private int GetIslandSize(int[][] grid, int row, int col, int islandNo)
    {
        if (row < 0 || row >= _m || col < 0 || col >= _n || grid[row][col] < 0)
            return 0;
        if (grid[row][col] == 0)
        {
            var cellNo = row * _n + col;
            if (!_zeroToIslands.TryAdd(cellNo, new HashSet<int>() { islandNo }))
                _zeroToIslands[cellNo].Add(islandNo);
            return 0;
        }

        grid[row][col] *= -1;
        var islandSize = 1;
        foreach (var d in _directions)
        {
            var adjRow = row + d[0];
            var adjCol = col + d[1];
            islandSize += GetIslandSize(grid, adjRow, adjCol, islandNo);
        }

        return islandSize;
    }
}