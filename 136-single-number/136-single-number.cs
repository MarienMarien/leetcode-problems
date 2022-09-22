public class Solution {
    public int SingleNumber(int[] nums) {
        var res = 0;
        foreach (var n in nums) {
            res ^= n;
        }
        return res;
    }
}