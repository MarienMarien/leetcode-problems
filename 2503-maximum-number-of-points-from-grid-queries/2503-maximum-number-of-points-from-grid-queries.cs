public class Solution {
    public int[] MaxPoints(int[][] grid, int[] queries) {
        var m = grid.Length;
        var n = grid[0].Length;
        var sortedQueries = new (int val, int id)[queries.Length];
        for(var i = 0; i < queries.Length; i++)
        {
            sortedQueries[i] = (queries[i], i);
        }
        Array.Sort(sortedQueries);

        var answer = new int[queries.Length];
        var q = new PriorityQueue<(int row, int col, int val), int>();
        q.Enqueue((0, 0, grid[0][0]), grid[0][0]);
        var visited = new HashSet<int>() { 0 };
        var directions = new int[][] { [0, 1], [1, 0], [0, -1], [-1, 0] };
        var points = 0;
        
        for(var i = 0; i < sortedQueries.Length; i++)
        {
            var queryId = sortedQueries[i].id;
            var query = sortedQueries[i].val;

            while(q.Count > 0 && q.Peek().val < query)
            {
                var curr = q.Dequeue();
                points++;
                foreach(var d in directions)
                {
                    var nextRow = curr.row + d[0];
                    var nextCol = curr.col + d[1];
                    var key = nextRow * n + nextCol;
                    if(nextRow < 0 || nextRow >= m || nextCol < 0 || nextCol >= n || visited.Contains(key))
                        continue;
                    q.Enqueue((nextRow, nextCol, grid[nextRow][nextCol]), grid[nextRow][nextCol]);
                    visited.Add(key);
                }
            }

            answer[queryId] = points;
        }

        return answer;
    }
}