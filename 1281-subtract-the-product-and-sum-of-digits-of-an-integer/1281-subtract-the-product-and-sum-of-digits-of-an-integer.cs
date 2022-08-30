public class Solution {
    public int SubtractProductAndSum(int n) {
        var digit = n % 10;
        var sum = digit;
        var product = digit;
        n /= 10;
        while (n > 0) {
            digit = n % 10;
            sum += digit;
            product *= digit;
            n /= 10;
        }

        return product - sum;
    }
}