public class Solution {
    public IList<int> LuckyNumbers (int[][] matrix) {
        var maxInCols = new int[matrix[0].Length];

        for(var col = 0; col < matrix[0].Length; col++)
        {
            var colMax = Int32.MinValue;
            for(var row = 0; row < matrix.Length; row++)
            {
                colMax = Math.Max(colMax, matrix[row][col]);
            }
            maxInCols[col] = colMax;
        }

        var ans = new List<int>();
        
        for(var row = 0; row < matrix.Length; row++)
        {
            var rowMin = Int32.MaxValue;
            var minId = -1;
            for(var col = 0; col < matrix[0].Length; col++)
            {
                if(rowMin > matrix[row][col])
                {
                    rowMin = matrix[row][col];
                    minId = col;
                }
            }

            if(rowMin == maxInCols[minId])
            {
                ans.Add(rowMin);
            }
        }

        return ans;
    }
}