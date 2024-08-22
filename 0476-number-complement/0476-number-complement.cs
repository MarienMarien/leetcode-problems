public class Solution {
    public int FindComplement(int num) {
        var copy = num;
        var curr = 1;
        while (copy != 0)
        {
            num ^= curr;
            curr <<= 1;
            copy >>= 1;
        }

        return num;
    }
}