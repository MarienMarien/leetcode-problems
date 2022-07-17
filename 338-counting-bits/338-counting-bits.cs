public class Solution {
    public int[] CountBits(int n) {
        var bitsCounted = new int[n + 1];
        for (var i = 1; i <= n; i++)
        {
            var prevIdx = i & (i - 1);
            bitsCounted[i] = bitsCounted[prevIdx] + 1;
        }

        return bitsCounted;   
    }
}