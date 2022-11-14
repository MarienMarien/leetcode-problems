public class Solution {
    public int[][] GenerateMatrix(int n) {
        var lastDigit = n * n;
        var matrix = new int[n][];
        var len = n;
        var curr = 1;
        for (var i = 0; i < n; i++)
                matrix[i] = new int[n];
        var up = 0;
        var right = len - 1;
        var down = len - 1;
        var left = 0;
        while (curr <= lastDigit) { 
            for (var col = left; col <= right; col++) {
                matrix[up][col] = curr++;
            }
            if(curr > lastDigit)
                break;
            for (var row = up + 1; row <= down; row++) {
                matrix[row][right] = curr++;
            }
            if(curr > lastDigit)
                break;
            for (var col = right - 1; col >= left; col--)
            {
                matrix[down][col] = curr++;
            }
            if(curr > lastDigit)
                break;  
            for (var row = down - 1; row > up; row--) {
                matrix[row][left] = curr++;
            }
            len--;
            up++;
            right--;
            down--;
            left++;
        }

        return matrix;
    }
}