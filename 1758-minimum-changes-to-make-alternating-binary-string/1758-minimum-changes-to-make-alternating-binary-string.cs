public class Solution {
    public int MinOperations(string s) {
        var startOneCount = 0;
        var startZeroCount = 0;
        const char ZERO = '0';
        const char ONE = '1';

        bool isZero = true;
        bool isOne = true;

        foreach (var ch in s)
        {
            if ((ch == ZERO) != isZero) {
                startZeroCount++;
            }
            isZero = !isZero;

            if ((ch == ONE) != isOne)
            {
                startOneCount++;
            }
            isOne = !isOne;
        }

        return Math.Min(startZeroCount, startOneCount);
    }
}