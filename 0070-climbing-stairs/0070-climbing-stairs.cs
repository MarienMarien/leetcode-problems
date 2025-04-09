public class Solution {
    public int ClimbStairs(int n) {
        if(n < 3)
            return n;
        var one = 1;
        var two = 2;
        for(var stair = 3; stair <= n; stair++)
        {
            var next = two + one;
            one = two;
            two = next;
        }
        return two;
    }
}