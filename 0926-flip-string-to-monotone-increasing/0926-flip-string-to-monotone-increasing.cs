public class Solution {
    public int MinFlipsMonoIncr(string s) {
        var onesCount = 0;
        var flipCount = 0;
        foreach (var ch in s) {
            if (ch == '0')
            {
                flipCount = Math.Min(onesCount, flipCount + 1);
            }
            else
                onesCount++;
        }
        return flipCount;
    }
}