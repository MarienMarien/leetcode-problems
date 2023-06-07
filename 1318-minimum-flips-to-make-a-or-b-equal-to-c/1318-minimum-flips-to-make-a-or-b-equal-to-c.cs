public class Solution {
    public int MinFlips(int a, int b, int c) {
        var flipCount = 0;
        while (c > 0) {
            var curr = c & 1;
            if (curr == 0)
            {
                if((a & 1) != curr)
                    flipCount++;
                if ((b & 1) != curr)
                    flipCount++;
            }
            else {
                if ((a & 1) != curr && ((b & 1) == (a & 1)))
                    flipCount++;
            }
            a >>= 1;
            b >>= 1;
            c >>= 1;
        }
        while (a > 0) {
            if ((a & 1) == 1)
                flipCount++;
            a >>= 1;
        }
        while (b > 0)
        {
            if ((b & 1) == 1)
                flipCount++;
            b >>= 1;
        }

        return flipCount;
    }
}