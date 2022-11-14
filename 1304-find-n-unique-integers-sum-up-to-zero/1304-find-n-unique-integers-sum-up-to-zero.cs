public class Solution {
    public int[] SumZero(int n) {
        var ans = new int[n];
        var counter = 0;
        if(n % 2 > 0)
        ans[counter++] = 0;
        for(var i = 1; i <= n / 2; i++){
            ans[counter++] = i;
            ans[counter++] = -i;
        }
        return ans;
    }
}