public class Solution {
    public int RangeBitwiseAnd(int left, int right) {
        if (right - left == 0)
            return left;
            var sh = 0;
        while (left != right) {
            left >>= 1;
            right >>= 1;
            sh++;
            
        }
        return left << sh;
    }
}