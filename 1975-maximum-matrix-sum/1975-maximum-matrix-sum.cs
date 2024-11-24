public class Solution {
    public long MaxMatrixSum(int[][] matrix) {
        var minAbsVal = Int32.MaxValue;
        var negativeCount = 0;
        var totalSum = 0L;
        for(var row = 0; row < matrix.Length; row++)
        {
            for(var col = 0; col < matrix[0].Length; col++)
            {
                if(matrix[row][col] < 0)
                {
                    negativeCount++;
                }
                var absCellVal = Math.Abs(matrix[row][col]);
                minAbsVal = Math.Min(minAbsVal, absCellVal);
                totalSum += absCellVal;
            }
        }
        return negativeCount % 2 == 1 ? totalSum - minAbsVal * 2 : totalSum;
    }
}