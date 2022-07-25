public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) {
        var targetRow = GetTargetRow(matrix, target);
        if (targetRow < 0)
            return false;
        var start = 0;
        var end = matrix[0].Length - 1;
        var mid = end / 2;
        do {
            if (matrix[targetRow][mid] == target)
                return true;
            if (target < matrix[targetRow][mid])
                end = mid;
            if (target > matrix[targetRow][mid])
                start = mid + 1;
            mid = start + ((end - start) / 2);
       } while (end > start);
       if (matrix[targetRow][end] == target)
            return true;
        return false;
    }

    private int GetTargetRow(int[][] matrix, int target)
    {
        var col = 0;
        var end = matrix.Length - 1;
        if (target < matrix[0][col])
            return -1;
        if (target > matrix[end][col])
            return end;
        var start = 0;
        var mid = end / 2;
        while (end > start)
        {

            if (target < matrix[mid][col])
            {
                end = mid;
            }
            if (target >= matrix[mid][col])
            {
                start = mid;
            }
            mid = start + (end - start) / 2;
            if (start == mid)
                break;
        }
        if (target >= matrix[end][col])
            return end;
        return start;
    }
}