public class Solution {
    public uint reverseBits(uint n) {
        uint ans = 0;
        int bit = 31;
        while(n != 0)
        {
            ans += (n & 1) << bit;
            bit -= 1;
            n = n >>> 1;
        }

        return ans;
    }
}