public class Solution {
    public int AddDigits(int num) {
        var ans = num;
        while (ans / 10 > 0) {
            var sum = 0;
            while (ans > 0) {
                sum += ans % 10;
                ans /= 10;
            }
            ans = sum;
        }
        return ans;
    }
}