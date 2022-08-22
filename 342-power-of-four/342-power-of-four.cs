public class Solution {
    public bool IsPowerOfFour(int n) {
        if (n == 1)
            return true;
        if (n < 1 || n < 4)
            return false;

        while (n > 1)
        {
            if ((n & 1) == 1)
                return false;
            n >>= 1;
            if ((n & 1) == 1)
                return false;
            n >>= 1;
        }
        return true;
    }
}