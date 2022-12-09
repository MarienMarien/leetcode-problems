public class Solution {
    public int MySqrt(int x) {
        if (x < 2)
            return x;
        var left = 2;
        var right = x / 2;
        long currSq;
        int currRes;
        while (left <= right) {
            currRes = left + (right - left) / 2;
            currSq = (long)currRes * currRes;
            if (currSq > x)
                right = currRes - 1;
            else if (currSq < x)
                left = currRes + 1;
            else
                return currRes;
        }
        return right;
    }
}
