public class Solution {
    public int KthSmallest(int[][] matrix, int k) {
        var len = matrix.Length;
        var pq = new PriorityQueue<(int val, int row, int col), int>();
        for (var row = 0; row < Math.Min(len, k); row++) {
            pq.Enqueue((matrix[row][0], row, 0), matrix[row][0]);
        }
        var curr = pq.Peek();
        while (k-- > 0) {
            curr = pq.Dequeue();
            if (curr.col < len - 1) {
                pq.Enqueue((matrix[curr.row][curr.col + 1], curr.row, curr.col + 1), matrix[curr.row][curr.col + 1]);
            }
        }
        return curr.val;
    }
}