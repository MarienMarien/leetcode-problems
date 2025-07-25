public class Solution {
    public int MaxSum(int[] nums) {
        var seen = new bool[101];
        var positiveSum = 0;
        var max = -100;

        foreach(var n in nums)
        {
            if(n >= 0 && !seen[n])
            {
                positiveSum += n;
                seen[n] = true;
            }
            max = Math.Max(max, n);
        }
        
        return max < 0 ? max : positiveSum;
    }
}