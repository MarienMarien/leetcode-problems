public class Solution {
    public int MinOperations(int[][] grid, int x) {
        var m = grid.Length;
        var n = grid[0].Length;
        var nums = new int[m*n];
        var id = 0;
        for(var row = 0; row < m; row++)
        {
            for(var col = 0; col < n; col++)
            {
                nums[id++] = grid[row][col];
            }
        }

        Array.Sort(nums);
        var len = nums.Length;
        var median = nums[len / 2];
        var opCount = 0;
        foreach(var num in nums)
        {
            if(num % x != median % x)
                return -1;
            opCount += Math.Abs(num - median) / x;
        }

        return opCount;
    }
}