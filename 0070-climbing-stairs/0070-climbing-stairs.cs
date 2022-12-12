public class Solution {
    public int ClimbStairs(int n) {
        if(n < 2)
            return n;
        var n1 = 1;
        var n2 = 2;
        for(var i = 3; i <= n; i++){
            var next = n1 + n2;
            n1 = n2;
            n2 = next;
        }
        return n2;
    }
}