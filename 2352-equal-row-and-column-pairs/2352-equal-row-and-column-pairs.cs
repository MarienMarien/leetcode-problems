public class Solution {
    public int EqualPairs(int[][] grid) {
        var set = new Dictionary<string, int>();
        for (var row = 0; row < grid.Length; row++) {
            var rowLabel = string.Join("-", grid[row]);
            if (!set.TryAdd(rowLabel, 1))
                set[rowLabel]++;
        }
        var count = 0;
        for (var col = 0; col < grid.Length; col++) {
            var sb = new StringBuilder();
            for (var row = 0; row < grid[0].Length; row++) {
                if (sb.Length > 0)
                    sb.Append('-');
                sb.Append(grid[row][col]);
            }
            var colLabel = sb.ToString();
            if (set.ContainsKey(colLabel)) {
                count += set[colLabel];
            }
        }
        return count;
    }
}