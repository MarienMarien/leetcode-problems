public class Solution {
    public record struct HeightMapEntry(int row, int col, int height);    
    public int TrapRainWater(int[][] heightMap)
    {
        var m = heightMap.Length;
        var n = heightMap[0].Length;
        var pq = new PriorityQueue<HeightMapEntry, int>();
        var visited = new bool[m, n];
        for (var col = 0; col < n; col++)
        {
            pq.Enqueue(new HeightMapEntry(0, col, heightMap[0][col]), heightMap[0][col]);
            visited[0, col] = true;
            pq.Enqueue(new HeightMapEntry(m - 1, col, heightMap[m - 1][col]), heightMap[m - 1][col]);
            visited[m - 1, col] = true;
        }

        for (var row = 1; row < m - 1; row++)
        {
            pq.Enqueue(new HeightMapEntry(row, 0, heightMap[row][0]), heightMap[row][0]);
            visited[row, 0] = true;
            pq.Enqueue(new HeightMapEntry(row, n - 1, heightMap[row][n - 1]), heightMap[row][n - 1]);
            visited[row, n - 1] = true;
        }

        var volume = 0;
        var directions = new int[][] { [0, 1], [1, 0], [0, -1], [-1, 0] };
        
        while (pq.Count > 0)
        {
            var curr = pq.Dequeue();
            foreach (var d in directions)
            {
                var adjRow = curr.row + d[0];
                var adjCol = curr.col + d[1];
                if (adjRow < 0 || adjRow >= m || adjCol < 0 || adjCol >= n 
                    || visited[adjRow, adjCol])
                    continue;
                if (heightMap[adjRow][adjCol] < curr.height)
                {
                    volume += curr.height - heightMap[adjRow][adjCol];
                    heightMap[adjRow][adjCol] = curr.height;
                }
                pq.Enqueue(new HeightMapEntry(adjRow, adjCol, heightMap[adjRow][adjCol]), heightMap[adjRow][adjCol]);
                visited[adjRow, adjCol] = true;
            }
        }

        return volume;
    }
}