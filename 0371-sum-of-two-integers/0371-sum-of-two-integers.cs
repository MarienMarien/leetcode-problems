public class Solution {
    public int GetSum(int a, int b) {
        while(b != 0)
        {
            var xor = a ^ b;
            var carry = (a & b) << 1;
            a = xor;
            b = carry;
        }
        return a;
    }
}