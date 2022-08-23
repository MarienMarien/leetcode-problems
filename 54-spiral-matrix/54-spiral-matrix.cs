public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        IList<int> res = new List<int>();
        var resSize = matrix.Length * matrix[0].Length;
        var up = 0;
        var down = matrix.Length - 1;
        var left = 0;
        var right = matrix[0].Length - 1;
        while (res.Count < resSize) {
            // top row
            for (var col = left; col <= right; col++) {
                res.Add(matrix[up][col]);
            }
            // right
            for (var row = up + 1; row <= down; row++) { 
                res.Add(matrix[row][right]);
            }
            //down
            if(up != down)
                for (var col = right - 1; col >= left; col--) {
                    res.Add(matrix[down][col]);
                }
            //left
            if(left != right)
                for (var row = down - 1; row > up; row--) {
                    res.Add(matrix[row][left]);
                }

            up++;
            down--;
            left++;
            right--;
        }

        return res;
    }
}