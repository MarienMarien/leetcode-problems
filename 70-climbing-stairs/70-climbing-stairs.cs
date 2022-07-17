public class Solution {
    public int ClimbStairs(int n) {
        if (n < 0)
                return 0;
            if (n  < 3)
                return n;
            var n1 = 1;
            var n2 = 2;
            var climbWaysCount = 0;
            for (var i = 3; i <= n; i++) {
                climbWaysCount = n1 + n2;
                n1 = n2;
                n2 = climbWaysCount;
            }
            return climbWaysCount;
    }
}