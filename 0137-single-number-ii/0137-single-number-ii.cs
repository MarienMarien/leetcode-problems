public class Solution {
    public int SingleNumber(int[] nums) {
        var seemOnce = 0;
        var seemTwice = 0;
        foreach (var n in nums) {
            seemOnce = ~seemTwice & (seemOnce ^ n);
            seemTwice = ~seemOnce & (seemTwice ^ n);
        }
        return seemOnce;
    }
}