public class Solution {
    public int SnakesAndLadders(int[][] board) {
        var n = board.Length;
        var cells = new KeyValuePair<int, int>[n * n + 1];
        var idx = 1;
        var columns = new int[n];
        for (int i = 0; i < n; i++)
        {
            columns[i] = i;
        }
        for (int row = n - 1; row >= 0; row--)
        {
            foreach (int col in columns)
            {
                cells[idx++] = new KeyValuePair<int, int>(row, col);
            }
            Array.Reverse(columns);
        }
        var visited = new int[n * n + 1];
        Array.Fill(visited, -1);
        var q = new Queue<int>();
        visited[1] = 0;
        q.Enqueue(1);
        while (q.Count > 0)
        {
            var curr = q.Dequeue();
            for (var next = curr + 1; next <= Math.Min(curr + 6, n * n); next++)
            {
                var row = cells[next].Key;
                var col = cells[next].Value;
                var currIdx = board[row][col] != -1 ? board[row][col] : next;
                if (visited[currIdx] == -1)
                {
                    visited[currIdx] = visited[curr] + 1;
                    q.Enqueue(currIdx);
                }
            }
        }
        return visited[^1];
    }
}