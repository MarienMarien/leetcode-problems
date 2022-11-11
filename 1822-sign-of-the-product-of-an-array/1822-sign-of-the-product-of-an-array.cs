public class Solution {
    public int ArraySign(int[] nums) {
         var negativeCount = 0;
        foreach (var n in nums) {
            if (n == 0)
                return 0;
            if (n < 0)
                negativeCount++;
        }
        return negativeCount % 2 == 0 ? 1 : -1;
    }
}