public class Solution {
    public int Fib(int n) {
        var first = 1;
        if(n < 3)
            return n == 0 ? 0 : first;
        var second = 1;
        n -= 2;
        while(n > 0){
            var next = first + second;
            first = second;
            second = next;
            n--;
        }
        return second;
    }
}