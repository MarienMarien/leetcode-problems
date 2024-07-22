public class Solution {
    public int[][] RestoreMatrix(int[] rowSum, int[] colSum) {
        var sortedRowSum = new PriorityQueue<(int sum, int row), int>();
        var sortedColSum = new PriorityQueue<(int sum, int col), int>();

        var res = new int[rowSum.Length][];

        for (var i = 0; i < rowSum.Length; i++)
        {
            sortedRowSum.Enqueue((rowSum[i], i), rowSum[i]);
            res[i] = new int[colSum.Length];
        }

        for (var i = 0; i < colSum.Length; i++)
        {
            sortedColSum.Enqueue((colSum[i], i), colSum[i]);
        }

        while(sortedRowSum.Count > 0 && sortedColSum.Count > 0)
        {
            var currRow = sortedRowSum.Dequeue();
            var currCol = sortedColSum.Dequeue();
            var cellVal = Math.Min(currRow.sum, currCol.sum); ;
            res[currRow.row][currCol.col] = cellVal;
            var newRowSum = currRow.sum - cellVal;
            if (newRowSum > 0)
            {
                sortedRowSum.Enqueue((newRowSum, currRow.row), newRowSum);
            }
            var newColSum = currCol.sum - cellVal;
            if (newColSum > 0)
            {
                sortedColSum.Enqueue((newColSum, currCol.col), newColSum);
            }
        }

        return res;
    }
}