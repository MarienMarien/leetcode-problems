public class Solution {
    public class Data 
    {
        public Data()
        {
            TotalSteps = 0;
            HousesCovered = 0;
        }
        public int TotalSteps;
        public int HousesCovered;
    }
    private int[][] _directions = new int[][] { [0, 1], [1, 0], [0, -1], [-1, 0] };
    public int ShortestDistance(int[][] grid) {
        var totalHouses = 0;
        var m = grid.Length;
        var n = grid[0].Length;
        var distanceData = new Data[m, n];
        for(var row = 0; row < m; row++)
        {
            for(var col = 0; col < n; col++)
            {
                if(grid[row][col] != 1)
                    continue;
                totalHouses++;
                FillDistances(row, col, distanceData, grid);
            }
        }
        var minDistance = -1;
        for(var row = 0; row < m; row++)
        {
            for(var col = 0; col < n; col++)
            {
                if(distanceData[row,col] == null || distanceData[row,col].HousesCovered != totalHouses)
                    continue;
                if(minDistance == -1 || minDistance > distanceData[row,col].TotalSteps)
                    minDistance = distanceData[row,col].TotalSteps;
            }
        }
        return minDistance;
    }

    private void FillDistances(int startRow, int startCol, Data[,] distanceData, int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var visited = new HashSet<int>() { startRow * n + startCol };
        var q = new Queue<(int row, int col)>();
        q.Enqueue((startRow, startCol)); 
        var currLevel = 1;       
        while(q.Count > 0)
        {
            var levelSize = q.Count;
            for(var i = 0; i < levelSize; i++)
            {
                var curr = q.Dequeue();
                foreach(var d in _directions)
                {
                    var newRow = curr.row + d[0];
                    var newCol = curr.col + d[1];
                    var key = newRow * n + newCol;
                    if(newRow < 0 || newRow >= m || newCol < 0 || newCol >= n 
                        || grid[newRow][newCol] != 0 || visited.Contains(key))
                        continue;
                    
                    visited.Add(key);
                    if(distanceData[newRow, newCol] == null)
                        distanceData[newRow, newCol] = new Data();
                    distanceData[newRow, newCol].TotalSteps += currLevel;
                    distanceData[newRow, newCol].HousesCovered += 1;
                    q.Enqueue((newRow, newCol));
                }
            }
            currLevel++;
        }
    }
}