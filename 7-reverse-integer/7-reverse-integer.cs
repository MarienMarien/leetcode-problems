public class Solution {
    public int Reverse(int x) {
        if (x == 0)
            return x;
        if (x == Int32.MinValue || x == Int32.MaxValue)
            return 0;
        while (x % 10 == 0)
            x /= 10;
        int res = 0;
        while (x != 0) {
            if (res > Int32.MaxValue / 10 || res < Int32.MinValue / 10)
                return 0;
            if ((res == Int32.MaxValue / 10 && x > 7) || (res == Int32.MinValue / 10 && x > 8))
                return 0;
            res = res * 10 + (x % 10);
            x /= 10;
        }
        return res;
    }
}