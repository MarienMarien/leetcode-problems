public class Solution {
    public int GetFood(char[][] grid) {
        var rowsLen = grid.Length;
        var colsLen = grid[0].Length;
        var startRow = -1;
        var startCol = -1;
        for (var row = 0; row < rowsLen; row++)
        {
            if (startRow >= 0 && startCol >= 0)
                break;
            for (var col = 0; col < colsLen; col++)
            {
                if (grid[row][col] != '*')
                    continue;
                startRow = row;
                startCol = col;
                break;
            }
        }

        var q = new Queue<(int row, int col)>();
        q.Enqueue((startRow, startCol));

        var directions = new int[][] { [0, 1], [1, 0], [0, -1], [-1, 0] };
        var skipEnqueueCells = new HashSet<char> { 'X', 'V' };
        const char FOODCELL = '#';
        var level = 1;
        var levelSize = 1;
        grid[startRow][startCol] = 'V';

        while (q.Count > 0)
        {
            var currCell = q.Dequeue();
            levelSize--;
            foreach (var d in directions)
            {
                var nextRow = currCell.row + d[0];
                var nextCol = currCell.col + d[1];
                if (nextRow < 0 || nextRow >= rowsLen || nextCol < 0 || nextCol >= colsLen
                    || skipEnqueueCells.Contains(grid[nextRow][nextCol]))
                    continue;
                if (grid[nextRow][nextCol] == FOODCELL)
                {
                    return level;
                }
                q.Enqueue((nextRow, nextCol));
                grid[nextRow][nextCol] = 'V';
            }
            
            if (levelSize == 0)
            {
                levelSize = q.Count;
                level++;
            }
        }

        return -1;
    }
}