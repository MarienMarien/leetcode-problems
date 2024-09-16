public class Solution {
    public int ClimbStairs(int n) {
        if (n < 3)
            return n;
        var take1 = 1;
        var take2 = 2;
        for (var stair = 3; stair <= n; stair++)
        {
            var pathsCount = take1 + take2;
            take1 = take2;
            take2 = pathsCount;
        }

        return take2;
    }
}