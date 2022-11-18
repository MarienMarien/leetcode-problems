public class Solution {
    public bool IsUgly(int n) {
        if(n <= 0)
            return false;
        foreach(var num in new int[]{2, 3, 5} ){
            while(n % num == 0)
                n /= num;
        }
        return n == 1;
    }
}