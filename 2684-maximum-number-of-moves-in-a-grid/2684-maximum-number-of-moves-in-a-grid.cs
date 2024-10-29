public class Solution {
    public int MaxMoves(int[][] grid) {
        var gridWidth = grid[0].Length;
        var possibleMoves = new int[][] { [-1, 1], [0, 1], [1, 1] };
        var maxMoves = 0;
        var moves = new int[grid.Length, grid[0].Length];
        for (var col = 0; col < grid[0].Length; col++)
        {
            for (var row = 0; row < grid.Length; row++)
            {
                foreach (var move in possibleMoves)
                {
                    var nextRow = row + move[0];
                    var nextCol = col + move[1];
                    if (nextRow < 0 || nextCol < 0 || nextRow >= grid.Length || nextCol >= grid[0].Length 
                        || (col > 0 && moves[row, col] == 0) || moves[nextRow, nextCol] > 0)
                        continue;
                    if (grid[nextRow][nextCol] > grid[row][col])
                    {
                        moves[nextRow, nextCol] = moves[row, col] + 1;
                        maxMoves = Math.Max(maxMoves, moves[nextRow, nextCol]);
                        if (maxMoves == gridWidth - 1)
                            return maxMoves;
                    }
                }
            }
        }

        return maxMoves;
    }
}