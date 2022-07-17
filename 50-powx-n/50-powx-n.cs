public class Solution {
    public double MyPow(double x, int n) {
        long n1 = n;
            if (n1 < 0) {
                x = 1 / x;
                n1 = -n1;
            }
            double res = 1;
            double currRes = x;
            for (long i = n1; i > 0; i /= 2) {
                if (i % 2 == 1) {
                    res *= currRes;
                }
                currRes = currRes * currRes;
            }
            return res;
    }
}