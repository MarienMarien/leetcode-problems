public class Solution {
    public int FindNumbers(int[] nums) {
        var count = 0;
        foreach(var n in nums)
        {
            if(n > 10 && (n < 100 || (n > 999 && n < 10000) || n == 100000))
                count++;
        }
        return count;
    }
}